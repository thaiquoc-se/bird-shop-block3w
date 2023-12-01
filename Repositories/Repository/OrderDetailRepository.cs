using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class OrderDetailRepository : BaseRepository<TblOrderDetail, int>, IOrderDetailRepository
    {
        public OrderDetailRepository(IBaseDAO<TblOrderDetail, int> baseDAO) : base(baseDAO)
        {
        }
    }
}
