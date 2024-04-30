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


        private readonly ApplicationDbContext _context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context )
        {
            _context = context;
            this.entities = context.Set<Order>();
        }


        public List<Order> GetAllOrders()
        {
            return entities
        .Include(o => o.ProductInOrders)
            .ThenInclude(p => p.OrderedProduct)
        .Include(o => o.Owner) // Assuming Owner is another navigation property
        .ToList();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return entities.Include(o => o.ProductInOrders)
                .ThenInclude(p => p.OrderedProduct)
                    .Include(pO => pO.Owner)
                // Change the following line to include the Ticket navigation property in TicketInOrder
                .Include(p => p.ProductInOrders).ThenInclude(p => p.OrderedProduct)
                .SingleOrDefaultAsync(p => p.Id == id.Id)
                .Result;
        }

    }
}
