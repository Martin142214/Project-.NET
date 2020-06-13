using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Products Product { get; set; }
        public string PageTitle { get; set; }
        public double Size { get; set; }
        public IEnumerable<Comments> Comments { get; set; }

    }
}
