using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.Answer;

namespace OneMits.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IQuestion _questionImplementation;
        private readonly IAnswer _answerImplementation;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _applicationUserImplementation;
        public AnswerController(IQuestion questionImplementation, IAnswer answerImplementation, UserManager<ApplicationUser> userManager, IApplicationUser applicationUserImplementation)
        {
            _questionImplementation = questionImplementation;
            _answerImplementation = answerImplementation;
            _userManager = userManager;
            _applicationUserImplementation = applicationUserImplementation;
        }


        

    }
}