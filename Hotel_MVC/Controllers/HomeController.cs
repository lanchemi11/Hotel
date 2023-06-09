﻿using Hotel_MVC.Models;
using Hotel_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Diagnostics;
using System.Drawing;

namespace Hotel_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApartmanService _apartmanService;


        public HomeController(ILogger<HomeController> logger, IApartmanService apartmanService)
        {
            _logger = logger;
            _apartmanService = apartmanService;
        }

        public IActionResult Index()
        {
            var apartmani = _apartmanService.Get();
            return View(apartmani);
        }

        public IActionResult Insert()
        {
            return View();
        }

        public IActionResult CreatePost(Apartman apartman, IFormFile slika)
        {
            if (slika != null && slika.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    slika.CopyTo(memoryStream);
                    apartman.Slika = memoryStream.ToArray();
                }
            }
            else
            {
                apartman.Slika = new byte[0];
            }

            _apartmanService.Create(apartman);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            _apartmanService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var apartman = _apartmanService.Get(id);
            return View(apartman);
        }

        public IActionResult Update(string id)
        {
            var apartman = _apartmanService.Get(id);
            if (apartman == null)
            {
                return NotFound();
            }

            return View(apartman);
        }

        public IActionResult UpdatePost(string id, Apartman apartman, IFormFile slika)
        {
            if (slika != null && slika.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    slika.CopyTo(memoryStream);
                    apartman.Slika = memoryStream.ToArray();
                }
            }
            else if (apartman.Slika == null || apartman.Slika.Length == 0)
            {
                // Preserve the existing image if no new image is uploaded
                var existingApartman = _apartmanService.Get(id);
                apartman.Slika = existingApartman.Slika;
            }

            _apartmanService.Update(id, apartman);

            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}