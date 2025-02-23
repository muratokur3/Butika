using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MailController : ControllerBase
{
    private readonly IMailService _mailService;

    public MailController(IMailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail()
    {
        var subject = "Hoş geldik!";
        var body = "Merhaba iyi ki sen de katıldın";
        await _mailService.SendmailAsync("notificationTo", subject, body);
        return Ok("Email sent successfully");
    }
}
