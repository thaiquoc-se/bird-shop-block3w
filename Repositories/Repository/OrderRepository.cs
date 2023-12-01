using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class OrderRepository : BaseRepository<TblOrder, int>, IOrderRepository
    {
        public OrderRepository(IBaseDAO<TblOrder, int> baseDAO) : base(baseDAO)
        {
        }
    }
}
