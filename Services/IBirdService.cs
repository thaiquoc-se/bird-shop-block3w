using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBirdService
    {
        List<Bird> GetAllBirds();
        Task<Bird> GetBirdByID(int id);
        void AddNew(Bird bird);
        void Update(Bird bird);
    }

}
