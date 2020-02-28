using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Models.AdminPanel;


namespace OneMits.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly ICategory _categoryImplementation;
        private readonly IApplicationUser _applicationUserImplementation;
        private readonly IQuestion _questionImplementation;
        private readonly ApplicationDbContext _context;
        public AdminPanelController(ApplicationDbContext context, ICategory categoryImplementation, IApplicationUser applicationUserImplementation, IQuestion questionImplementation)
        {
            _categoryImplementation = categoryImplementation;
            _applicationUserImplementation = applicationUserImplementation;
            _questionImplementation = questionImplementation;
            _context = context;
        }
        public IActionResult Index()
        {
            int SumQuestions = 0;
            //int SumAnswers = 0;
            var Categories = _categoryImplementation.GetAll();
            foreach (var category in Categories)
            {
                SumQuestions += category.Questions.Count();
            }
            //foreach (var category in Categories)
            //{
            //    var Questions = category.Questions;
            //    foreach (var question in Questions)
            //    {
            //        SumAnswers += question.Answers.Count();
            //    }
            //}

            var model = new PanelIndexModel
            {
                NumberForums = _categoryImplementation.GetAll().Count(),
                NumberQuestions = SumQuestions,
                NumberMember = _applicationUserImplementation.GetAll().Count(),
                NumberUser = _context.Visits.Count(),
                NumberReplies = _questionImplementation.GetAllAnswers().Count(),
                //NumberLike = _categoryImplementation.GetAll().Count(),
            };

            return View(model);
        }

    }
}