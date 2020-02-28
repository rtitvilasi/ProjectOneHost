using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.ApplicationUser;
using OneMits.Models.Category;
using OneMits.Models.Question;
using OneMits.Models.Search;

namespace OneMits.Controllers
{
    public class SearchController : Controller
    {
        private readonly IQuestion _questionImplementation;
        private readonly IApplicationUser _userImplementation;

        private IEnumerable<QuestionListingModel> postListings;
        private IEnumerable<ProfileModel> userListings;

        public SearchController(IQuestion questionImplementation, IApplicationUser userImplementation)
        {
            _questionImplementation = questionImplementation;
            _userImplementation = userImplementation;
        }


        public IActionResult UserResult(string searchQuery)
        {
            var userList = _userImplementation.GetSearchUserName(searchQuery);
            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !userList.Any());

            var profileModel = userList
                .Select(info => new ProfileModel
                {
                    UserId = info.Id,
                    Email = info.Email,
                    UserName = info.UserName,
                    UserRating = info.Rating,
                    MemberSince = info.MemberSince,
                    IsActive = info.IsActive,
                });
            var model = new SearchModel
            {
                UserList = profileModel,
                SearchQuery = searchQuery,
                EmptySearchResults = areNoResults
            };
            return View(model);
        }
        public IActionResult Result(string searchQuery)
        {
            var questions = _questionImplementation.GetFilteredQuestions(searchQuery);
            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !questions.Any());

            var questionListingModel = questions.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                NumberView = question.NumberViews,
                Category = BuildForumListing(question)
            });
            var model = new SearchModel
            {
                Questions = questionListingModel,
                SearchQuery = searchQuery,
                EmptySearchResults = areNoResults
            };
            return View(model);
        }

        private CategoryListingModel BuildForumListing(Question question)
        {
            var catogory = question.Category;
            return new CategoryListingModel
            {
                CategoryId = catogory.CategoryId,
                CategoryTitle = catogory.CategoryTitle,
                CategoryImageUrl = catogory.CategoryImageUrl,
                CategoryDescription = catogory.CategoryDescription
            };

        }


        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Result", new { searchQuery });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UserList(string searchQuery)
        {
            return RedirectToAction("UserResult", new { searchQuery });
        }

    }
}