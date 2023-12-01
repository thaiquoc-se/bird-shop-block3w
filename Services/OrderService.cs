using BusinessObjects.Models;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddNewOrder(TblOrder order) => await _unitOfWork.Order.Add(order);
        

        public List<TblOrder> GetAllOrders() => _unitOfWork.Order.GetAll().ToList();
       
    }
}
