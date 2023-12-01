using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Microsoft.AspNetCore.SignalR;
using Services;

namespace BirdFarmShop.Pages.User
{
    public class ViewOrderHistoryModel : PageModel
    {
        private readonly IOrderService _orderService;
        public int userId;

        public ViewOrderHistoryModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IList<TblOrder> TblOrder { get;set; } = default!;
        

        public IActionResult OnGet(int? id)
        {
            try
            {
                userId = (int)HttpContext.Session.GetInt32("UserID")!;
            }
            catch
            {
                return NotFound();  
            }
            var tblorder = _orderService.GetAllOrders().Where(o => o.UserId == id).ToList();
            try
            {
                var check = _orderService.GetAllOrders().Where(o => o.UserId == id).FirstOrDefault();
                if (check == null)
                {
                    ViewData["notification"] = "You Not Have Any Order History";
                    return Page();
                }
                if (check.UserId != id)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return NotFound();
            }
            if (tblorder == null)
            {
                ViewData["notification"] = "You Not Have Any Order History";
                return Page();
            }
            else
            {
                TblOrder = tblorder;
            }
            return Page();
        }
    }
}
