using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace WebApplication1.Models
{
    public class Products
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string ProductName { get; set; }
        public string Model { get; set; }

        public string Brand { get; set; }
        public double Size { get; set; }
        public string Colour { get; set; }

        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }

        public IEnumerable<Comments> Comment { get; set; }
       


    }
}

