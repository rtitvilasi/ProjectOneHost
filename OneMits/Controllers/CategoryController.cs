using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.InterfaceImplementation;
using OneMits.Models.Category;
using OneMits.Models.Question;

namespace OneMits.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IQuestion _questionImplementation;
        private readonly ICategory _categoryImplementation;
        public CategoryController(IQuestion questionImplementation, ICategory categoryImplementation)
        {
            _questionImplementation = questionImplementation;
            _categoryImplementation = categoryImplementation;
        }
        public IActionResult Index()
        {
            var categories = _categoryImplementation.GetAll().Select(category => new CategoryListingModel
            {
                CategoryId = category.CategoryId,
                CategoryTitle = category.CategoryTitle,
                CategoryDescription = category.CategoryDescription,
                CategoryImageUrl = category.CategoryImageUrl,
                QuestionCount = category.Questions.Count()
            });
            var model = new CategoryIndexModel  
            {
                CategoryList = categories
            };
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var category = _categoryImplementation.GetById(id);
            var questions = new List<Question>();

            questions = _questionImplementation.GetFilteredQuestions(category).ToList();

            var questionListings = questions.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                AuthorName = question.User.UserName,
                QuestionTitle = question.QuestionTitle,
                QuestionContent = question.QuestionContent,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                NumberView = question.NumberViews,
                Category = BuildCategoryListing(question)
            });

            var model = new CategoryTopicModel
            {
                Questions = questionListings,
                Category = BuildForumListing(category)
            };

            return View(model);
        }

        private CategoryListingModel BuildCategoryListing(Question question)
        {
            var category = question.Category;
            return BuildForumListing(category);
        }

        private CategoryListingModel BuildForumListing(Category category)
        {
            return new CategoryListingModel
            {
                CategoryId = category.CategoryId,
                CategoryTitle = category.CategoryTitle,
                CategoryDescription = category.CategoryDescription,
                CategoryImageUrl = category.CategoryImageUrl,
                QuestionCount = category.Questions.Count()
            };
        }
        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new AddCategoryModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(AddCategoryModel model)
        {
            var imageUri = "/images/users/default.png";
            var category = new Category
            {
                CategoryTitle = model.CategoryTitle,
                CategoryDescription = model.CategoryDescription,
                CategoryCreated = DateTime.Now,
                CategoryImageUrl = imageUri
            };
            await _categoryImplementation.Create(category);
            return RedirectToAction("Index", "Category");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryImplementation.Delete(id);
            return RedirectToAction("Index", "Category");
        }
    }
}