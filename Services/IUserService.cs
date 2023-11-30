using BusinessObjects.Models;
using DataAccessLayer.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<List<TblUser>> GetAllUsers();
        TblUser GetUserByEmail(string email);
        Task<TblUser> GetUserByID(int id);
        Task AddNew(TblUser user);
        void Update(TblUser user);
        Task Delete(int id);
        TblUser checkLogin(string userName, string password);
    }
}
