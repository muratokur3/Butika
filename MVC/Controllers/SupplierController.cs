using Application.Models.DTOs;
using Application.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers;

[Authorize(Roles = "SupplyAdmin")]
public class SupplierController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public SupplierController(IHttpClientFactory httpClientFactory)
    {
        this._httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index(int pageNumber = 1)
    {
        int pageSize = 10;
        var httpClient = _httpClientFactory.CreateClient("api");
        var response1 = await httpClient.GetAsync("Supplier/GetData");
        var response = await httpClient.GetAsync("Supplier/GetAllSuppliers");
		if (response.IsSuccessStatusCode)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            var suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierVM>>(apiResponse);

            var paginatedSuppliers = suppliers.Reverse().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)suppliers.Count() / pageSize);

            return View(paginatedSuppliers);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Supplier bilgilerine erişilemedi.");
            return View("Error");
        }
    }

    public IActionResult AddSupplier()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddSupplier(SupplierDTO supplierDTO)
    {
        var httpClient = _httpClientFactory.CreateClient("api");
        var content = new StringContent(JsonConvert.SerializeObject(supplierDTO), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("Supplier/AddSupplier", content);
        if (response.IsSuccessStatusCode)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
        else
        {
            TempData["ErrorMessage"] = "Bu tedarikçi zaten var.";
        }

        return View(supplierDTO);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateSupplier(int id)
    {
        var httpClient = _httpClientFactory.CreateClient("api");

        using (var response = await httpClient.GetAsync($"Supplier/GetSupplierById/{id}"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            var supplier = JsonConvert.DeserializeObject<UpdateSupplierDTO>(apiResponse);

            return View(supplier);
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSupplier(UpdateSupplierDTO updateSupplierDTO)
    {
        var httpClient = _httpClientFactory.CreateClient("api");

        var response = await httpClient.GetAsync($"Supplier/GetSupplierById/{updateSupplierDTO.Id}");
        if (response.IsSuccessStatusCode)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            var existingSupplier = JsonConvert.DeserializeObject<UpdateSupplierDTO>(apiResponse);
            if (existingSupplier.SupplierCode == updateSupplierDTO.SupplierCode &&
            existingSupplier.SupplierName == updateSupplierDTO.SupplierName &&
            existingSupplier.NotificationTo == updateSupplierDTO.NotificationTo &&
            existingSupplier.Active == updateSupplierDTO.Active)
            {
                TempData["WarningMessage"] = "Değişiklik yapılmadı.";
                return RedirectToAction("UpdateSupplier", new { id = updateSupplierDTO.Id });
            }

            var content = new StringContent(JsonConvert.SerializeObject(updateSupplierDTO), Encoding.UTF8, "application/json");
            var updateResponse = await httpClient.PutAsync("Supplier/UpdateSupplier", content);
            if (updateResponse.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Tedarikçi başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tedarikçi güncellenemedi.");
            }
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Tedarikçi bilgilerine erişilemedi.");
        }

        return View(updateSupplierDTO);
    }
}
