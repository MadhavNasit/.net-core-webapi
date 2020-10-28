using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWebAPI.Helpers;
using CRUDWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CRUDWebAPI.Services.EmailService;

namespace CRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult SendMail()
        {
            var message = new Message(new string[] { "madhavnasit29@gmail.com" }, "Test email for forgot password", "This is the content from our email. Which will contain Random Password for forgot password");
            _emailSender.SendEmail(message);

            return Ok("Mail Sent");
        }
    }
}