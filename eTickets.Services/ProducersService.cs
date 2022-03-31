using eTickets.Base;
using eTickets.Data;
using eTickets.Services;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService (AppDbContext context) : base(context){ }
    }
}