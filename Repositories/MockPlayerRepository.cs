using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repositories;

namespace WebApplication1.Models
{
    public class MockPlayerRepository : IPlayerRepository
    {

        private List<Player> _PlayerList;

        public MockPlayerRepository()
        {
            _PlayerList = new List<Player>()
            {
                new Player() {Id=1, Name="Martin", Age=18, Country=EnumCountries.Bulgaria},
                new Player() {Id=2, Name="Peter", Age=20, Country=EnumCountries.Germany }
            };
        }

        public Player Add(Player player)
        {
            player.Id = _PlayerList.Max(e => e.Id) + 1;
            _PlayerList.Add(player);
            return player;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _PlayerList;
        }
        public Player GetPlayer(int id)
        {
            return _PlayerList.FirstOrDefault(p => p.Id == id);
        }

        public Player Delete(int id)
        {
            Player player = _PlayerList.FirstOrDefault(e => e.Id == id);
            if (player != null)
            {
                _PlayerList.Remove(player);
            }
            return player;
        }

        public Player Update(Player playerChanges)
        {
            Player player = _PlayerList.FirstOrDefault(e => e.Id == playerChanges.Id);
            if (player != null)
            {
                player.Name = playerChanges.Name;
                player.Points = playerChanges.Points;
            }
            return player;
        }
    }
}
