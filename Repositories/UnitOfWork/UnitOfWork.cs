using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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

        IOrderDetailRepository OrderDetail { get; }
        void Update<T>(T entity) where T : class;

        void SaveChanges();
    }
        public class UnitOfWork : IUnitOfWork
        {
            public IBirdRepository Products { get; private set; }

            public IUserRepository User { get; private set; }

            public IWardRepository Wards { get; private set; }

            public IDistrictRepository Districts { get; private set; }

            public IOrderRepository Order { get;private set; }

            public IOrderDetailRepository OrderDetail { get; private set; }

            private readonly BirdFarmShop2Context _context;

        public UnitOfWork(IBirdRepository birdRepository, IUserRepository userRepository
                            , IWardRepository wardRepository, IDistrictRepository districtRepository
                            ,IOrderRepository orderRepository,
                            IOrderDetailRepository orderDetailRepository
            )
            {
                Products = birdRepository;
                User = userRepository;
                Wards = wardRepository;
                Districts = districtRepository;
                Order = orderRepository;
                OrderDetail = orderDetailRepository;
                _context = new BirdFarmShop2Context();
        }

        public void SaveChanges() => _context.SaveChanges();
        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
    }

