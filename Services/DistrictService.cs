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
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DistrictService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TblDistrict> GetAll() =>  _unitOfWork.Districts.GetAll().ToList();
        
    }
}
