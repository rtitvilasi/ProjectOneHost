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
using OneMits.Models.Like;
using OneMits.Models.Question;

namespace OneMits.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestion _questionImplementation;
        private readonly ICategory _categoryImplementation;
        private readonly IApplicationUser _applicationUserImplementation;

        private static UserManager<ApplicationUser> _userManager;

        public QuestionController(IQuestion questionImplementation, ICategory categoryImplementation, IApplicationUser applicationUserImplementation, UserManager<ApplicationUser> userManager)
        {
            _questionImplementation = questionImplementation;
            _categoryImplementation = categoryImplementation;
            _applicationUserImplementation = applicationUserImplementation;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            _questionImplementation.AddView(id).Wait();
            var question = _questionImplementation.GetById(id);
            var answers = Buildanswers(question.Answers);
            
            var model = new QuestionIndexModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                AuthorId = question.User.Id,
                AuthorName = question.User.UserName,
                AuthorImageUrl = question.User.ProfileImageUrl,
                AuthorRating = question.User.Rating,
                QuestionCreated = question.QuestionCreated,
                QuestionContent = question.QuestionContent,
                Answers = answers,
                AnswerCount = question.Answers.Count(),
                CategoryId = question.Category.CategoryId,
                CategoryTitle = question.Category.CategoryTitle,
                IsAuthorAdmin = IsAuthorAdmin(question.User),
                LikeCount = question.LikeQuestions.Count(),
                NumberView = question.NumberViews

            };

            return View(model);
        }

        private IEnumerable<AnswerModel> Buildanswers(IEnumerable<Answer> answers)
        {
            return answers.Select(answer => new AnswerModel
            {
                AnswerId = answer.AnswerId,
                AuthorName = answer.User.UserName,
                AuthorId = answer.User.Id,
                AuthorImageUrl = answer.User.ProfileImageUrl,
                AuthorRating = answer.User.Rating,
                AnswerCreated = answer.AnswerCreated,
                AnswerContent = answer.AnswerContent,
                IsAuthorAdmin = IsAuthorAdmin(answer.User),
                

            });

        }
        private bool IsAuthorAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user).Result.Contains("Admin");
        }

        public IActionResult Create(int id)
        {
            var category = _categoryImplementation.GetById(id);
            var model = new NewQuestionModel
            {
                CategoryId = category.CategoryId,
                CategoryTitle = category.CategoryTitle,
                CategoryImageUrl = category.CategoryImageUrl,
                AuthorName = User.Identity.Name
            };
            return View(model);
        }
       

        [HttpPost]
        public async Task<IActionResult> AddQuestion(NewQuestionModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var question = BuildPost(model, user);

            string[] censoredWords = System.IO.File.ReadAllLines(@"CensoredWords.txt");
            Censor censor = new Censor(censoredWords);
            question.QuestionTitle = censor.CensorText(question.QuestionTitle);
            question.QuestionContent = censor.CensorText(question.QuestionContent);

            await _questionImplementation.AddQuestion(question);
            await _applicationUserImplementation.UpdateUserRating(userId, typeof(Question));

             return RedirectToAction("Index", "Question", new { id = question.QuestionId });
        }

        private Question BuildPost(NewQuestionModel model, ApplicationUser user)
        {
            var category = _categoryImplementation.GetById(model.CategoryId);
            return new Question
            {
                QuestionTitle = model.QuestionTitle,
                QuestionContent = model.QuestionContent,
                QuestionCreated = DateTime.Now,
                User = user,
                Category = category
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer(QuestionIndexModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var answer = BuildReply(model, user);

            string[] censoredWords = System.IO.File.ReadAllLines(@"CensoredWords.txt");
            Censor censor = new Censor(censoredWords);
            answer.AnswerContent = censor.CensorText(answer.AnswerContent);

            await _questionImplementation.AddAnswer(answer);
            await _applicationUserImplementation.UpdateUserRating(userId, typeof(Answer));

            return RedirectToAction("Index", "Question", new { id = model.QuestionId });
        }

        private Answer BuildReply(QuestionIndexModel model, ApplicationUser user)
        {
            var question = _questionImplementation.GetById(model.QuestionId);
            return new Answer
            {
                Question = question,
                AnswerContent = model.AnswerContent,
                AnswerCreated = DateTime.Now,
                User = user
            };
        }
  
        [Authorize]
        public async Task<IActionResult> AddLike(int questionId)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var likeQuestion = BuildLike(questionId, user);

            await _questionImplementation.AddLike(likeQuestion);
            var question = _questionImplementation.GetById(questionId);
            var model = new QuestionIndexModel
            {
                LikeCount = question.LikeQuestions.Count(),
                QuestionId = question.QuestionId
            };

            return RedirectToAction("Index", "Question", new { id = questionId });
        }

        private LikeQuestion BuildLike(int questionId, ApplicationUser user)
        {
            var question = _questionImplementation.GetById(questionId);
            return new LikeQuestion
            {
                Question = question,
                IsLike = true,
                User = user
            };
        }
        [Authorize]
        public async Task<IActionResult> AddLikeAnswer(AnswerModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var likeAnswer = BuildAnswerLike(model, user);

            await _questionImplementation.AddAnswerLike(likeAnswer);
            

            return RedirectToAction("Index", "Question", new { id = model.QuestionId });
        }

        private LikeAnswer BuildAnswerLike(AnswerModel model, ApplicationUser user)
        {
            var answer = _questionImplementation.GetAnswerById(model.AnswerId);
            return new LikeAnswer
            {
                Answer = answer,
                IsLike = true,
                User = user
            };
        }

        public async Task<IActionResult> Delete(int id)
        {
            var question = _questionImplementation.GetById(id);
            var CategoryId = question.Category.CategoryId;
            await _questionImplementation.Delete(id);
            return RedirectToAction("Index", "Category", new { id = CategoryId });
        }
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = _questionImplementation.GetAnswerById(id);
            var QuestionId = answer.Question.QuestionId;
            await _questionImplementation.DeleteAnswer(id);
            return RedirectToAction("Index", "Question", new { id = QuestionId });
        }
    }
}