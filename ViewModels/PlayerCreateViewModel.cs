using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class PlayerCreateViewModel
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }

        public int Points { get; set; }
        [Required]
        public EnumCountries Country { get; set; }
        public IFormFile Photo { get; set; }
    }
}
