

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //private List<Player> _players;
        //public void MockPlayerRepository()
        //{
        //    _players = new List<Player>()
        //    {

        //        new Player() {Id=1, Name="Martin", Age=18, Country=EnumCountries.Bulgaria},
        //        new Player() {Id=2, Name="Peter", Age=20, Country=EnumCountries.Germany }
        //    };
        //}
        //public IEnumerable<Player> GetAllPlayers()
        //{
        //    return _players;
        //}

        //public Player GetPlayer(int id)
        //{
        //    var player = _players.FirstOrDefault(p => p.Id == id);
        //    return player;
        //}
      


    }
}

