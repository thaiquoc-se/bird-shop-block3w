using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBirdRepository Products { get; }

        IUserRepository User { get; }
    }
    public class UnitOfWork : IUnitOfWork
    {
        public IBirdRepository Products { get; private set; }

        public IUserRepository User { get; private set; }

        public UnitOfWork(IBirdRepository birdRepository, IUserRepository userRepository)
        {
            Products = birdRepository;
            User = userRepository;
        }

        
    }
}
