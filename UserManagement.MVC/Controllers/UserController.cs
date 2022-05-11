using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakeAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

             var result = await _userManager.AddToRoleAsync(user, "Admin");


            if (result.Succeeded is false)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            return RedirectToAction("AllUsers", "Home");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakeUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user is null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, "Admin");


            if (result.Succeeded is false)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            return RedirectToAction("AllUsers", "Home");
        }

        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> LockUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var result = await _userManager.SetLockoutEndDateAsync(user, System.DateTimeOffset.MaxValue);
            
            if (result.Succeeded is false)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            return RedirectToAction("AllUsers", "Home");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> UnlockUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var result = await _userManager.SetLockoutEndDateAsync(user, System.DateTimeOffset.MinValue);
            if (result.Succeeded is false)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            return RedirectToAction("AllUsers", "Home");
        }

        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user is null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var result = await _userManager.DeleteAsync(user);

            if(result.Succeeded is false)
            {

                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            return RedirectToAction("AllUsers", "Home");
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}