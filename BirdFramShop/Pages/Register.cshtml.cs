using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Services;
using BirdFramShop.ViewModel;

namespace BirdFramShop.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;
        private readonly IUserService _userService;
        public RegisterModel(IDistrictService districtService, IWardService wardService, IUserService userService)
        {
            _districtService = districtService;
            _wardService = wardService;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            ViewData["DistrictName"] = new SelectList(_districtService.GetAll(), "DistrictId", "DistrictName");
            ViewData["WardName"] = new SelectList(_wardService.GetAll(), "WardId", "WardName");
            return Page();
        }

        [BindProperty]
        public RegisterViewModel TblUser { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (TblUser!.Pass != TblUser.ConfirmPass)
                {
                    ViewData["DistrictName"] = new SelectList(_districtService.GetAll(), "DistrictId", "DistrictName");
                    ViewData["WardName"] = new SelectList(_wardService.GetAll(), "WardId", "WardName");
                    ViewData["notification"] = "Password and Confirm Password do not match.";
                    return Page();
                }

                if (!string.IsNullOrWhiteSpace(TblUser.UserName) && !string.IsNullOrWhiteSpace(TblUser.Pass))
                {
          
                    var user = new TblUser()
                    {
                        UserName = TblUser.UserName,
                        Pass = TblUser.Pass,
                        DistrictId = TblUser.DistrictId,
                        WardId = TblUser.WardId,
                        Image = "https://firebasestorage.googleapis.com/v0/b/birdfarmshop-firebase.appspot.com/o/default-avatar.png?alt=media&token=44c5ecec-0d64-402f-8f58-https://firebasestorage.googleapis.com/v0/b/birdfarmshop-firebase.appspot.com/o/default-avatar.png?alt=media&token=44c5ecec-0d64-402f-8f58-bc67824aff95&_gl=1*1pzluj4*_ga*MTc2MDE3MTQ5NS4xNjY2NDQ2MTgy*_ga_CW55HF8NVT*MTY5NzcwNjg0MS40LjEuMTY5NzcwNzM5Mi42MC4wLjA.",
                        FullName = TblUser.FullName,
                        Phone = TblUser.Phone,
                        UserAddress = TblUser.UserAddress,
                        RoleId = "US",
                        Email = TblUser.Email,
                        UserStatus = true,
                    };
                    await _userService.AddNew(user);
                    return RedirectToPage("./Login");
                }
                ViewData["DistrictName"] = new SelectList(_districtService.GetAll(), "DistrictId", "DistrictName");
                ViewData["WardName"] = new SelectList(_wardService.GetAll(), "WardId", "WardName");
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }
    }
}
