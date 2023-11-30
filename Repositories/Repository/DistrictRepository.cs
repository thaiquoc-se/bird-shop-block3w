using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class DistrictRepository : BaseRepository<TblDistrict, string>, IDistrictRepository
    {
        public DistrictRepository(IBaseDAO<TblDistrict, string> baseDAO) : base(baseDAO)
        {
        }
    }
}
