using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcViewModels.Model;
using MvcViewModels.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(IdentityLoginViewModel IdentityLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(IdentityLogin.UserName, IdentityLogin.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "People");
            }

            ViewBag.Msg = "Failed To Login.";

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(IdentityCreateViewModel IdentityCreate)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.FirstName = IdentityCreate.FirstName;
                appUser.LastName = IdentityCreate.LastName;
                appUser.DateOfBirth = IdentityCreate.DateOfBirth;
                appUser.UserName = IdentityCreate.UserName;

                var result = await _userManager.CreateAsync(appUser, IdentityCreate.Password);
                var reslut = await _userManager.AddToRoleAsync(appUser, "Member");
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");

                }

                ViewBag.Msg = "Failed to Login";
            }


            return View();


        }
        public async Task<IActionResult> Logout()
        {
            
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "People");

        }



    }
}
