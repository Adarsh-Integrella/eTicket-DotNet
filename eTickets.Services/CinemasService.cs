using eTickets.Base;
using eTickets.Data;
using eTickets.Services;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService (AppDbContext context) : base(context){ }
    }
} 