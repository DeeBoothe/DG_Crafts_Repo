using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DGCrafts.Models;
using DGCrafts.Models.ViewModels;

namespace DGCrafts.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<Customer> userManager;
        private SignInManager<Customer> signInManager;
        public AccountController(UserManager<Customer>userMgr, 
            SignInManager<Customer> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Customer user = await userManager.FindByNameAsync(loginModel.UserName);
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    if((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }

            ModelState.AddModelError("","Invalid name or password");
            return View(loginModel);
        }

        public ViewResult Register()
        {
            return View();
        }

       /* public async Task<IActionResult> Register()
        {
            return View();
        }*/


        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }


}
