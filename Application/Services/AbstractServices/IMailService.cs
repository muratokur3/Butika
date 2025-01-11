using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AbstractServices;
public interface IMailService
{
    Task SendmailAsync(string to, string subject, string body);
}