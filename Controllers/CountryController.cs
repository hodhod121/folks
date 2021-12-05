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
    public class CountryController : Controller
    {
        private readonly FolkContext _context;

        public CountryController(FolkContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CountryModel> country = _context.Countries.ToList();
            return View(country);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CountryModel country = new CountryModel();
            return View(country);
        }
        [HttpPost]
        public IActionResult Create(CountryModel country)
        {
            _context.Add(country);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }           
        [HttpGet]
        public IActionResult Edit(string Id)
        {
            CountryModel country = _context.Countries.Where(c => c.Code == Id).FirstOrDefault();

            return View(country);
        }
        [HttpPost]
        public IActionResult Edit(CountryModel country)
        {
            _context.Attach(country);
            _context.Entry(country).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(string Id)
        {
            CountryModel country = _context.Countries.Where(c => c.Code == Id).FirstOrDefault();

            return View(country);
        }
        [HttpPost]
        public IActionResult Delete(CountryModel country)
        {
            _context.Attach(country);
            _context.Entry(country).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
