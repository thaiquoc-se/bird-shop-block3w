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

        IWardRepository Wards { get; }

        IDistrictRepository Districts { get; }

        IOrderRepository Order { get; }
    }
        public class UnitOfWork : IUnitOfWork
        {
            public IBirdRepository Products { get; private set; }

            public IUserRepository User { get; private set; }

            public IWardRepository Wards { get; private set; }

            public IDistrictRepository Districts { get; private set; }

            public IOrderRepository Order { get;private set; }

        public UnitOfWork(IBirdRepository birdRepository, IUserRepository userRepository
                            , IWardRepository wardRepository, IDistrictRepository districtRepository
                            ,IOrderRepository orderRepository
            )
            {
                Products = birdRepository;
                User = userRepository;
                Wards = wardRepository;
                Districts = districtRepository;
                Order = orderRepository;
            }


        }
    }

