using ChalupaHaj.Data.Models;
using ChalupaHaj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChalupaHaj.Controllers
{
    //AccountController manages users accounts
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        //displays registration form
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        //validates and collects data from registration form -> creates new user
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                //if user is not found, it creates new one
                if (await userManager.FindByEmailAsync(model.Email) is null)
                {
                    //creates new user
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await userManager.CreateAsync(user, model.Password);

                    //attempt to sign in
                    if (result.Succeeded)
                    { 
                        await signInManager.SignInAsync(user, isPersistent: false);

                        return string.IsNullOrWhiteSpace(returnUrl) ?
                            RedirectToAction("Index", "Cs") :
                            RedirectToLocal(returnUrl);
                    }

                    AddErrors(result);
                }

                //error in case account already exists
                AddErrors(IdentityResult.Failed(new IdentityError() { Description = $"Email {model.Email} je již zaregistrován" }));
            }

            return View(model);
        }


        //displays log-in form
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        //validates data -> signs in user
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;


            //checks if all sended data are included in viewmodel
            if (!ModelState.IsValid)
                return View(model);


            //attempt to log-in user
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);


            //if invalid data are recived, returns user to sign-in form
            if (result.Succeeded)
            {
                return string.IsNullOrWhiteSpace(returnUrl) ?
                    RedirectToAction("Administration") :
                    RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "Neplatné přihlašovací údaje");
            return View(model);

        }


        //Logs out user
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Cs");
        }


        //displays form for password change
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await userManager.GetUserAsync(User) ??
                    throw new ApplicationException($"Nepodařilo se načíst uživatele {userManager.GetUserId(User)}.");

            var model = new ChangePasswordViewModel();
            return View(model);
        }


        //changes password and signs in user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await userManager.GetUserAsync(User) ??
                throw new ApplicationException($"Nepodařilo se načíst uživatele {userManager.GetUserId(User)}.");

            var changePasswordResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Administration");
        }


        //returns administration site
        public IActionResult Administration()
        {
            return View();
        }
    

        #region Helpers

        //redirects to local address
        private IActionResult RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) ?
                Redirect(returnUrl) :
                RedirectToAction("Inex", "Cs");
        }


        //sends errors during validation to view
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(String.Empty, error.Description);
        }

        #endregion
    }
}
