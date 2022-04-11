using System.ComponentModel.DataAnnotations;
using eTickets.Base;
using eTickets.Data.Cart;

namespace eTickets.Models
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}