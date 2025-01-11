using Application.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Text;

namespace MVC.Controllers
{
    [Authorize]
    public class OperationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OperationsController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<ActionResult> Index(int selectedSupplierId)
        {   
            if (selectedSupplierId == 0 || selectedSupplierId == null)
            {
                TempData["ErrorMessage"] = "Lütfen bir tedarikçi seçiniz.";
                return RedirectToAction("Index", "Home");
            }


            var httpClient = _httpClientFactory.CreateClient("api");

            using (var response = await httpClient.GetAsync($"Supplier/GetSupplierById/{selectedSupplierId}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var supplier = JsonConvert.DeserializeObject<SupplierVM>(apiResponse);

                if (supplier == null)
                {
                    TempData["ErrorMessage"] = "bir hata çıktı.";
                    return RedirectToAction("Index", "Home");
                }

                var model = new OperationsVM
                {
                    SelectedSupplierId = selectedSupplierId,
                    SelectedSupplierName = supplier.SupplierName
                };
                ViewBag.CurrentStep = 2;
                ViewBag.ProductTab = "single";
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel(OperationsVM model)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (model.ExcelFile == null || model.ExcelFile.Length == 0)
            {
                model.ErrorMessages.Add("Lütfen bir Excel dosyası seçin.");
                ViewBag.ProductTab = "excel";
                ViewBag.CurrentStep = 2;
                return View("Index", model);
            }

            var httpClient = _httpClientFactory.CreateClient("api");
            var formData = new MultipartFormDataContent();
            if (model.ExcelFile != null)
            {
                var fileContent = new StreamContent(model.ExcelFile.OpenReadStream());
                formData.Add(fileContent, "excelFile", model.ExcelFile.FileName);
            }
            formData.Add(new StringContent(model.SelectedSupplierId.ToString()), "supplierId");
            var response = await httpClient.PostAsync("Operations/ValidateExcelFile", formData);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();

                var orderVM = JsonConvert.DeserializeObject<OrderVM>(apiResponse) ?? new OrderVM();
                ViewBag.CurrentStep = 3;
                return View("InfoOrder", orderVM);

            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var errorObject = JsonConvert.DeserializeObject<ErrorVM>(errorResponse);

                if (errorObject.ErrorTitle == "ExcelError")
                {
                    model.ErrorMessages.AddRange(errorObject.ValidationResults.Where(x => !x.IsValid).Select(x => x.ErrorMessage));
                    ViewBag.ProductTab = "excel";
                    ViewBag.CurrentStep = 2;
                    return View("Index", model);
                }
                else if (errorObject.ErrorTitle == "SAPError")
                {
                    var resultModel = new OperationsVM
                    {
                        ValidationResults = errorObject.ValidationResults,
                        SelectedSupplierId = model.SelectedSupplierId,
                        SelectedSupplierName = model.SelectedSupplierName
                    };
                    return View("SapValidationResult", resultModel);
                }

                model.ErrorMessages.Add("Bir hata oluştu.");
                ViewBag.ProductTab = "excel";
                ViewBag.CurrentStep = 2;
                return View("Index", model);
            }





        }

        public async Task<IActionResult> singleInputProduct(OperationsVM model)
        {
            //if (string.IsNullOrEmpty(model.SKU))
            //{
            //    ModelState.AddModelError("SKU", "SKU alanı boş olamaz.");
            //}
            //else if (model.SKU.Length > 15)
            //{
            //    ModelState.AddModelError("SKU", "SKU 15 karakterden uzun olamaz.");
            //}
            //if (model.Quantity <= 0)
            //{
            //    ModelState.AddModelError("Quantity", "Quantity 0'dan büyük olmalıdır.");
            //}

            //if (!ModelState.IsValid)
            //{
            //    ViewBag.ProductTab = "single";
            //    return View("Index", model);
            //}
            var httpClient = _httpClientFactory.CreateClient("api");
            var requestContent = new StringContent(JsonConvert.SerializeObject(new ProductValidationResult
            {
                SKU = model.SKU,
                Quantity = model.Quantity,
                SupplierID = model.SelectedSupplierId
            }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("Operations/ValidateSingleProduct", requestContent);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();

                var orderVM = JsonConvert.DeserializeObject<OrderVM>(apiResponse) ?? new OrderVM();
                ViewBag.CurrentStep = 3;
                return View("InfoOrder", orderVM);

            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var errorObject = JsonConvert.DeserializeObject<ErrorVM>(errorResponse);

                if (errorObject.ErrorTitle == "SingleError")
                {
                    model.ErrorMessages.AddRange(errorObject.ValidationResults.Where(x => !x.IsValid).Select(x => x.ErrorMessage));
                    ViewBag.ProductTab = "single";
                    ViewBag.CurrentStep = 2;
                    return View("Index", model);
                }
                else if (errorObject.ErrorTitle == "SAPError")
                {
                    var resultModel = new OperationsVM
                    {
                        ValidationResults = errorObject.ValidationResults,
                        SelectedSupplierId = model.SelectedSupplierId,
                        SelectedSupplierName = model.SelectedSupplierName
                    };
                    return View("SapValidationResult", resultModel);
                }
            }
            ViewBag.ProductTab = "single";
            return View("Index", model);
        }

        public IActionResult SapValidationResult()
        {

            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> SendMailExcelFile(int orderId)
        {
            var httpClient = _httpClientFactory.CreateClient("api");
            var response = await httpClient.PostAsync($"Mail/SendEmail?orderId={orderId}", null);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = $"{orderId} id'li Sipariş Maili başarıyla gönderildi.";
                ViewBag.CurrentStep = 4;
                return RedirectToAction("Index", "Order");
            }
            else
            {
                TempData["ErrorMessage"] = $"{orderId} id'li Sipariş Maili gönderilirken bir hata oluştu.";
                ViewBag.CurrentStep = 4;
                return RedirectToAction("Index", "Order");


            }
        }

    }
}



