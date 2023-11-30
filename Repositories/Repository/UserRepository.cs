using BusinessObjects.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UserRepository : BaseRepository<TblUser, int>, IUserRepository
    {
        public UserRepository(IBaseDAO<TblUser, int> baseDAO) : base(baseDAO)
        {
        }

        public override IQueryable<TblUser> GetAll()
        {
            return base.GetAll().Include(u => u.Ward).Include(u => u.District);
        }

        public override Task<TblUser> GetByID(int id)
        {
            return GetAll().Where(u => u.UserId == id).FirstOrDefaultAsync()!;
        }
    }
}
