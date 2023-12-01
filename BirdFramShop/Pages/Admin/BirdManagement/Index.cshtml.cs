using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services;

namespace BirdFarmShop.Pages.Admin.BirdManagement
{
    public class IndexModel : PageModel
    {
        private readonly IBirdService _birdService;
        private string isAdmin;

        public IndexModel(IBirdService birdService)
        {
            _birdService = birdService;
        }

        public IList<Bird> Bird { get;set; } = default!;

        public IActionResult OnGet()
        {
            try
            {
                isAdmin = HttpContext.Session.GetString("isAdmin")!;
                if (isAdmin != "AD")
                {
                    return NotFound();
                }
                if (isAdmin == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }

            Bird = _birdService.GetAllBirds();
            return Page();
        }
    }
}
