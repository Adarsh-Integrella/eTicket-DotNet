using eTickets.Base;
using eTickets.Data;
using eTickets.Services;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService (AppDbContext context) : base(context){ }
    }
}