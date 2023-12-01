using BusinessObjects.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class BirdRepository : BaseRepository<Bird, int>, IBirdRepository
    {
        public BirdRepository(IBaseDAO<Bird, int> baseDAO) : base(baseDAO)
        {
        }

        public override IQueryable<Bird> GetAll()
        {
            return base.GetAll().Include(b => b.User);
        }

       
    }
}
