using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class WardRepository : BaseRepository<TblWard, string>, IWardRepository
    {
        public WardRepository(IBaseDAO<TblWard, string> baseDAO) : base(baseDAO)
        {
        }
    }
}
