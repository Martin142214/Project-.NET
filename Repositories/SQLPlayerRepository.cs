using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repositories;

namespace WebApplication1.Models
{
    public class SQLPlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext context;
        public SQLPlayerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Player Add(Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();
            return player;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return context.Players;
        }

        public Player GetPlayer(int id)
        {
            return context.Players.Find(id);
        }

        public Player Delete(int id)
        {
            Player player = context.Players.Find(id);
            if (player != null)
            {
                context.Players.Remove(player);
                context.SaveChanges();
            }
            return player;
        }

        public Player Update(Player playerChanges)
        {
            var player = context.Players.Attach(playerChanges);
            player.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return playerChanges;
        }
    }
}
