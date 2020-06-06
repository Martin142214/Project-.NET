using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PlayersSearch
    {
       
            private readonly WebApplication1.Models.Player _context;

            public PlayersSearch(WebApplication1.Models.Player context)
            {
                _context = context;
            }

            public IList<Player> Player { get; set; }
            [BindProperty(SupportsGet = true)]
            public string SearchString { get; set; }
            // Requires using Microsoft.AspNetCore.Mvc.Rendering;
            public SelectList Names { get; set; }
            [BindProperty(SupportsGet = true)]
            public string PlayerNames { get; set; }
        
    }
}
