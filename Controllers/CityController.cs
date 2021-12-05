using folk.Data;
using folk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace folk.Controllers
{
    public class CityController : Controller
    {
        private readonly FolkContext _context;

        public CityController(FolkContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CityModel> city = _context.Cities
                .Include(c => c.Country)
               .ToList();
            return View(city);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "Name");           
            return View();
        }
        [HttpPost]
        public IActionResult Create(CityModel city)
        {
            _context.Add(city);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }     
        [HttpGet]
        public IActionResult Edit(string Id)
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "Name");
            CityModel city = _context.Cities.Where(c => c.Code == Id).FirstOrDefault();

            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(CityModel city)
        {
            _context.Attach(city);
            _context.Entry(city).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(string Id)
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "Name");
            CityModel city = _context.Cities.Include(p => p.Country).Where(c => c.Code == Id).FirstOrDefault();

            return View(city);
        }
        [HttpPost]
        public IActionResult Delete(CityModel city)
        {
            _context.Attach(city);
            _context.Entry(city).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
