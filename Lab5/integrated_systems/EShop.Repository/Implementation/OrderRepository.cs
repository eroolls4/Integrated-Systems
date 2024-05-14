using EShop.Domain.Domain;
using EShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            //return entities
            //    .Include(z => z.ProductInOrders)
            //        .ThenInclude(x => x.OrderedProduct)
            //    .Include(z => z.Owner)
            //    .ToList();

          //  return context.Orders
          //.Include(o => o.Owner)
          //.Include(o => o.ProductInOrders)
          //    .ThenInclude(pio => pio.OrderedProduct)
          //        .ThenInclude(op => op.Concert)
          //.ToList();
          return context.Orders
                .Include(z=>z.Owner)
                .Include(o => o.ProductInOrders)
                .Include("ProductInOrders.OrderedProduct")
                .Include("ProductInOrders.OrderedProduct.Concert").ToList();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            //return entities
            //    .Include(z => z.ProductInOrders)
            //        .ThenInclude(x => x.OrderedProduct)
            //    .Include(z => z.Owner)
            //    .SingleOrDefaultAsync(z => z.Id == id.Id).Result;

            return entities
         .Include(z => z.ProductInOrders)
             .ThenInclude(x => x.OrderedProduct)
                 .ThenInclude(y => y.Concert)
         .Include(z => z.Owner)
         .SingleOrDefault(z => z.Id == id.Id);
        }
    }
}
