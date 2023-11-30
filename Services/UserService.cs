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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task AddNew(TblUser user) =>await _unitOfWork.User.Add(user);
        

        public TblUser checkLogin(string userName, string password)
        {
            try
            {
                var check = _unitOfWork.User.GetAll().Where(u => u.UserName!.Equals(userName) && u.Pass!.Equals(password)).FirstOrDefault();

                if (check != null)
                {
                    return check;
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblUser> checkUserName(string userName)
        {
                var check = await _unitOfWork.User.GetAll().Where(u => u.UserName.Equals(userName)).FirstOrDefaultAsync();
                return check;
        }

        public async Task Delete(int id) => await _unitOfWork.User.Remove(id);
        

        public async Task<List<TblUser>> GetAllUsers() => await _unitOfWork.User.GetAll().ToListAsync();
        

        public TblUser GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<TblUser> GetUserByID(int id) => await _unitOfWork.User.GetByID(id);
        

        public void Update(TblUser user) =>  _unitOfWork.User.Update(user);
        
    }
}
