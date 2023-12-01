using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void AddNewOrderDetail(TblOrderDetail orderDetail) => _unitOfWork.OrderDetail.Add(orderDetail);
        

        public async Task<List<TblOrderDetail>> GetOrderDetailByID(int id) => await _unitOfWork.OrderDetail.Find(od => od.OrderId == id).ToListAsync();
        
    }
}
