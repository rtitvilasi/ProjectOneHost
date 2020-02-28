
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.ApplicationUser;
using OneMits.Models.Search;
using System.Threading.Tasks;

namespace OneMits.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _profileManager;
        private readonly IApplicationUser _profileImplementation;
        private readonly IApplicationUser _userImplementation;
        public ProfileController(IApplicationUser profileImplementation, IApplicationUser userImplementation,UserManager<ApplicationUser> profileManager)
        {
            _profileImplementation = profileImplementation;
            _profileManager = profileManager;
            _userImplementation = userImplementation;
        }

        public IActionResult Details(string id)
        {
            var user = _profileImplementation.GetById(id);
            var userRoles = _profileManager.GetRolesAsync(user).Result;

            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating,
                MemberSince = user.MemberSince,
                Email = user.Email,
                IsAdmin = userRoles.Contains("Admin")
            };
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
           
            await _userImplementation.Delete(id);
            
            return RedirectToAction("Index", "AdminPanel");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnDelete(string id)
        {

            await _userImplementation.UnDelete(id);

            return RedirectToAction("Index", "AdminPanel");
        }

    }
}