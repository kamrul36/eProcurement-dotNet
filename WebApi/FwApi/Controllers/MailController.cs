using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FwCore.DBContext.Model;
using System.Net.Mail;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : Controller
    {

        [HttpPost]
        [Route("AddSubmit")]
        public async Task<IActionResult> SendMail([FromBody] Mail mail)
        {
            MailMessage mm = new MailMessage("hasanmk690@gmail.com", mail.To);
            mm.Subject = mail.Subject;
            mm.Body = mail.Body;
            mm.IsBodyHtml = false;


            SmtpClient sp = new SmtpClient();
            sp.Host = "smtp.gmail.com";
            sp.Port = 587;
            sp.EnableSsl = true;

            NetworkCredential nt = new NetworkCredential("hasanmk690@gmail.com", "mkh..01917");
            sp.UseDefaultCredentials = true;
            sp.Credentials = nt;
            sp.Send(mm);
            return BadRequest();
        }
    }
}
