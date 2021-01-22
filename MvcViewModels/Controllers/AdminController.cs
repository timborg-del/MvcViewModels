using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcViewModels.Model.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcViewModels.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //public string Username { get; set; }

        //[TempData]
        //public string StatusMessage { get; set; }

        //[BindProperty]
        //public IdentityCreateViewModel identityCreate { get; set; }


        //public class IdentityCreateViewModel

        //{
        //    [Required]
        //    [DataType(DataType.Text)]
        //    [Display(Name = "Full name")]
        //    public string Name { get; set; }

        //    [Required]
        //    [Display(Name = "Birth Date")]
        //    [DataType(DataType.Date)]
        //    public DateTime DateOfBirth { get; set; }
        //}

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
        public async Task<IActionResult> AddAdmin(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser != null)
            {
                var reslut = await _userManager.AddToRoleAsync(appUser, "Admin");

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveAdmin(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser != null && appUser.UserName != "SuperAdmin")
            {
                var reslut = await _userManager.RemoveFromRoleAsync(appUser, "Admin");

            }
            return RedirectToAction("Index");
        }
    }
}
