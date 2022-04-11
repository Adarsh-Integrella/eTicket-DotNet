using eTickets.Data;
using eTickets.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class NewMovieDropDownVM
    {
        public NewMovieDropDownVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }
        public List<Producer> Producers {get; set;}
        public List<Cinema> Cinemas {get;set;}
        public List<Actor> Actors { get; set; }

    }
}