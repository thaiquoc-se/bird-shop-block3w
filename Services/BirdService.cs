using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    
    public class BirdService : IBirdService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BirdService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void AddNew(Bird bird) => _unitOfWork.Products.Add(bird);


        public List<Bird> GetAllBirds() => _unitOfWork.Products.GetAll().ToList();
        

        public async Task<Bird> GetBirdByID(int id) => await _unitOfWork.Products.Find(b => b.BirdId == id,includes: b => b.User).SingleOrDefaultAsync();


        public void Update(Bird bird) => _unitOfWork.Products.Update(bird);
        
    }
}
