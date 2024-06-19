using Fruitable.Models;
using Fruitable.Repositry.Account;
using Fruitable.Repositry.Email;
using Fruitable.Utilities;
using Fruitable.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fruitable.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountRepository _accountRepository;
        private readonly IEmailRepositry _emailRepositry;
        private readonly IJwtTokenService _jwtTokenService;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IAccountRepository accountRepository,
                                 IEmailRepositry emailRepositry,
                                 IJwtTokenService jwtTokenRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountRepository = accountRepository;
            _emailRepositry = emailRepositry;
            _jwtTokenService = jwtTokenRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel();

            // Retrieve cookies if they exist
            if (Request.Cookies.ContainsKey("UserEmail"))
            {
                model.Email = Request.Cookies["UserEmail"]!;
                model.RememberMe = Request.Cookies["RememberMe"] == "True";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return View(model);
            }

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "Please confirm your email.");
                return RedirectToAction("ConfirmEmail", "Account");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName!, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = await _jwtTokenService.GenerateTokenAsync(user.UserName!, roles);

                HttpContext.Session.SetString("jwt", token);

                if (model.RememberMe)
                {
                    var options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30)
                    };
                    Response.Cookies.Append("UserEmail", model.Email, options);
                    Response.Cookies.Append("RememberMe", model.RememberMe.ToString(), options);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Model is valid, proceed with registration logic
                // Here you can implement code to create a new user account
                // For example, you might save the model data to a database

                // Example: Save to database
                // var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                // var result = await _userManager.CreateAsync(user, model.Password);

                // Redirect to a success page or login page
                var isEmailExists = await _userManager.FindByNameAsync(model.Email);
                if (isEmailExists != null)
                {
                    if (!isEmailExists.EmailConfirmed)
                    {
                        return RedirectToAction("ConfirmEmail", "Account");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    EmailConfirmed = false // Mark email as not confirmed initially
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return RedirectToAction("RegisterSuccess", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult ConfirmEmail()
        {
            // Display view for OTP confirmation
            var model = new ConfirmEmailViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find user by email
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                    return View(model);
                }

                // Check if user requested to resend OTP
                if (model.ResendOTP)
                {
                    // Generate new OTP
                    var otp = _accountRepository.GenerateOTP();
                    user.OTP = otp;
                    user.OTPExpiration = DateTime.UtcNow.AddMinutes(10); // OTP expires in 10 minutes

                    var updateResult = await _userManager.UpdateAsync(user);
                    if (updateResult.Succeeded)
                    {
                        // Send new OTP via email
                        await _emailRepositry.SendEmailConfirmationAsync(user, otp.ToString());

                        // Provide feedback to user that OTP has been resent
                        ModelState.AddModelError(string.Empty, "New OTP has been sent to your email.");
                        return View(model);
                    }
                    else
                    {
                        foreach (var error in updateResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }

                // Validate OTP and expiry
                if (user.OTP == model.OTP && user.OTPExpiration > DateTime.UtcNow)
                {
                    // OTP is valid and within expiry time, confirm email
                    user.EmailConfirmed = true;
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        // Redirect to login page or home page after successful email confirmation
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid OTP or OTP has expired.");
                }
            }

            // If we got this far, something failed, redisplay OTP confirmation form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
