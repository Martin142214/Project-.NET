using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class ProductCreateViewModel
    {

        [StringLength(50)]
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Modell { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public IFormFile Photo { get; set; }
    }
}
