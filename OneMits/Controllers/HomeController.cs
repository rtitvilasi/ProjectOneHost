using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.InterfaceImplementation;
using OneMits.Models;
using OneMits.Models.Category;
using OneMits.Models.Home;
using OneMits.Models.Question;


namespace OneMits.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestion _questionImplementation;
        private readonly IHttpContextAccessor _accessor;
        public HomeController(IQuestion questionImplementation, IHttpContextAccessor httpContextAccessor)
        {
            _questionImplementation = questionImplementation;
            _accessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndex();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndex()
        {
            var recentQuestion = _questionImplementation.GetLatestQuestions(10);
            var popularQuestion = _questionImplementation.GetPopularQuestions(10);
            var mostResponseQuestion = _questionImplementation.GetMostResponseQuestions(10);
            var priorityQuestion = _questionImplementation.GetPriorityQuestions(10);
            var recentQuestions = recentQuestion.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                QuestionContent = question.QuestionContent,
                AuthorId = question.User.Id,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                NumberView = question.NumberViews,
                Category = GetCategoryListingForQuestion(question)
            });
            var popularQuestions = popularQuestion.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                QuestionContent = question.QuestionContent,
                AuthorId = question.User.Id,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                NumberView = question.NumberViews,
                Category = GetCategoryListingForQuestion(question)
            });
            var mostResponseQuestions = mostResponseQuestion.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                QuestionContent = question.QuestionContent,
                AuthorId = question.User.Id,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                NumberView = question.NumberViews,
                Category = GetCategoryListingForQuestion(question)
            });
            var priorityQuestions = priorityQuestion.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                QuestionContent = question.QuestionContent,
                AuthorId = question.User.Id,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                NumberView = question.NumberViews,
                Category = GetCategoryListingForQuestion(question)
            });
            var Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return new HomeIndexModel
            {
                IpAddress = Ip,
                RecentQuestion = recentQuestions,
                PopularQuestion = popularQuestions,
                MostResponseQuestion = mostResponseQuestions,
                PriorityQuestion = priorityQuestions,
                
            };
        }

        private CategoryListingModel GetCategoryListingForQuestion(Question question)
        {
            var category = question.Category;
            return new CategoryListingModel
            {
                CategoryId = category.CategoryId,
                CategoryTitle = category.CategoryTitle,
                CategoryImageUrl = category.CategoryImageUrl
            };
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult ConFirm()
        {
            return View();
        }
        public IActionResult Block()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _questionImplementation.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
