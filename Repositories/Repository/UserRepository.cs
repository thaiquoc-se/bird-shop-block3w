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

        public override async void Update(TblUser entity)
        {
            var _user = await base.GetByID(entity.UserId);
            {
                if(_user != null)
                {
                    _user.UserName = entity.UserName;
                    _user.Email = entity.Email;
                    _user.UserAddress = entity.UserAddress;
                    _user.FullName = entity.FullName;
                    _user.DistrictId = entity.DistrictId;
                    _user.WardId = entity.WardId;
                    _user.Pass = entity.Pass;
                    _user.UserStatus = true;
                    _user.Image = entity.Image;
                    _user.Phone = entity.Phone;
                    _user.Image = entity.Image;
                    base.Update(_user);
                }
            }       
        }
    }
}
