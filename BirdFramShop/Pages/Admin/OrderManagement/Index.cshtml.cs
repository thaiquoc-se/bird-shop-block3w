﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services;

namespace BirdFarmShop.Pages.Admin.OrderManagement
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public string isAdmin;

        public IndexModel(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public IList<TblOrder> TblOrder { get;set; } = default!;
        public int UserId { get; private set; }
        public TblUser TblUserDTO { get; set; }
        public async Task<IActionResult> OnGet()
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
            TblOrder = _orderService.GetAllOrders().OrderByDescending(p => p.OrderId).ToList();
            UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = await _userService.GetUserByID(UserId);
            return Page();
        }
    }
}
