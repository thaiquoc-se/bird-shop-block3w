using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Services;

namespace BirdFramShop.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public TblUser user { get; set; } = default!;

        public IActionResult OnPost()
        {

            if (!string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Pass))
            {
                try
                {
                    var check = _userService.checkLogin(user.UserName, user.Pass);
                    if (check != null)
                    {
                        if (check.UserStatus != true)
                        {
                            ViewData["notification"] = "You are not allowed access into system";
                            return Page();
                        }
                        if (check.RoleId.Equals("US"))
                        {
                            try
                            {
                                var cart = HttpContext.Session.GetString("cart");
                                if (cart != null)
                                {
                                    HttpContext.Session.SetInt32("UserID", check.UserId);
                                    return RedirectToPage("Cart");
                                }
                            }
                            catch
                            {
                                HttpContext.Session.SetInt32("UserID", check.UserId);
                                return RedirectToPage("HomePage");
                            }
                            HttpContext.Session.SetInt32("UserID", check.UserId);
                            return RedirectToPage("HomePage");
                        }
                        if (check.RoleId.Equals("AD"))
                        {
                            HttpContext.Session.SetInt32("UserID", check.UserId);
                            HttpContext.Session.SetString("isAdmin", check.RoleId);
                            return RedirectToPage("Admin/UserManagement/ShowUserList");
                        }
                        if (check.RoleId.Equals("MN"))
                        {
                            HttpContext.Session.SetInt32("UserID", check.UserId);
                            HttpContext.Session.SetString("isManager", check.RoleId);
                            return RedirectToPage("Manager/StaffManagement/Index");
                        }
                        if (check.RoleId.Equals("ST"))
                        {
                            HttpContext.Session.SetInt32("UserID", check.UserId);
                            HttpContext.Session.SetString("isStaff", check.RoleId);
                            return RedirectToPage("Staff/BirdManagement/Index");
                        }
                    }
                    ViewData["notification"] = "Incorect User Name or Password Please Try Again";
                    return Page();
                }
                catch
                {
                    ViewData["notification"] = "Incorect User Name or Password Please Try Again";
                    return Page();
                }
            }
            return Page();
        }
    }
}
