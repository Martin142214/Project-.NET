using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Comments
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IdentityUser User { get; set; }
        public Products Product { get; set; }

    }
}
