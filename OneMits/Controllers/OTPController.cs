using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System;
using System.Data;
using OneMits.Models.OTP;

namespace OneMits.Controllers
{
    [AllowAnonymous]
    public class OTPController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;


        public OTPController(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            var model = new OTPModel { };


            return View(model);
        }


    }
}