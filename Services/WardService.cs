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
    public class WardService : IWardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WardService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TblWard> GetAll() => _unitOfWork.Wards.GetAll().ToList();
       
    }
}
