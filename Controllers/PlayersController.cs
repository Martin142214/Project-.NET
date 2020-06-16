using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class PlayersController : Controller
    {
        private IPlayerRepository _playerRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public PlayersController(IPlayerRepository playerRepository, IHostingEnvironment hostingEnvironment)
        {
            _playerRepository = playerRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Players(string searchString)
        {

            var player = _playerRepository.GetAllPlayers();

            if (!String.IsNullOrEmpty(searchString))
            {
                player = player.Where(s => s.Name.Contains(searchString));
            }

            return View(player);
        }

        public IActionResult FindPlayer(string searchString)
        {

            var players = from p in _playerRepository.GetAllPlayers()
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(p => p.Name.Contains(searchString));
            }
            return View(players);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Player player = _playerRepository.GetPlayer(id);
            PlayerEditViewModel playerEditViewModel = new PlayerEditViewModel
            {
                Id = player.Id,
                Name = player.Name,
                Age = player.Age,
                Points = player.Points,
                Country = player.Country
            };

            return View(playerEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(PlayerEditViewModel model)
        {
            if (ModelState.IsValid)
            {

                Player newPlayer = new Player
                {
                    Id = model.Id,
                    Name = model.Name,
                    Age = model.Age,
                    Points = model.Points,
                    Country = model.Country
                };

                _playerRepository.Update(newPlayer);
                return RedirectToAction("Players", "Home");
            }
            return View(model);
        }


        [HttpGet, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

           _playerRepository.Delete(id);
          
            return RedirectToAction("Players");
        }

        public ViewResult Details(int id)
        {

            HomeDetailsViewModels homeDetailsViewModels = new HomeDetailsViewModels()
            {
                Player = _playerRepository.GetPlayer(id),
                PageTitle = "Player details"
            };

            return View(homeDetailsViewModels);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PlayerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {              
                Player player = new Player
                {

                    Name = model.Name,
                    Age = model.Age,
                    Points = model.Points,
                    Country = model.Country
                };
                Player newPlayer = _playerRepository.Add(player);
                return RedirectToAction("details", new { id = newPlayer.Id });
            }

            return View();

        }
    }
}