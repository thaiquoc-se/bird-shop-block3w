using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAOs
{
    public class UserDAO : BaseDAO<TblUser, int>, IBaseDAO<TblUser, int>
    {
    }
}
