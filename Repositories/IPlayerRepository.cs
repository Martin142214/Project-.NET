﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IPlayerRepository
    {
        Player GetPlayer(int id);
        IEnumerable<Player> GetAllPlayers();

        Player Add(Player player);

        Player Update(Player playerChanges);
        Player Delete(int id);

        
    }
}
