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
    public class PersonController : Controller
    {
        private readonly FolkContext _context;

        public PersonController(FolkContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetCities(string CountryCode)
        {
            if(!string.IsNullOrWhiteSpace(CountryCode) && CountryCode.Length == 3)
            {
                List<SelectListItem> citiesSel = _context.Cities
                    .Where(c => c.CountryCode == CountryCode)
                    .OrderBy(n => n.Name)
                    .Select(n => new SelectListItem
                    {
                        Value = n.Code,
                        Text = n.Name
                    }).ToList();
                return Json(citiesSel);
            }
            return null;
        }
        public IActionResult Index(string SearchText = "")
        {
            List<PersonModel> people;
            if (SearchText != "" && SearchText != null)
            {
                people = _context.Peoples
                    .Include(p=>p.Country)
                    .Include(c=>c.City)
                    .Where(p=>(p.City.Name.Contains(SearchText)) || p.PersonName.Contains(SearchText))
                    .ToList();
                              
                return View(people);
            }
            else
            {
                people = _context.Peoples
                    .Include(c => c.Country)
                    .Include(cy => cy.City)
                    .ToList();
            }
            return View(people);
        }
      
        public IActionResult IndexAjax(string SearchText = "")
        {
            List<PersonModel> people;
            if (SearchText != "" && SearchText != null)
            {
                people = _context.Peoples
                    .Include(p => p.Country)
                    .Include(c => c.City)
                    .Where(p => (p.City.Name.Contains(SearchText)) || p.PersonName.Contains(SearchText))
                    .ToList();

                return View(people);
            }
            else
            {
                people = _context.Peoples
                    .Include(c => c.Country)
                    .Include(cy => cy.City)
                    .ToList();
            }
            return View(people);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "Name");

            ViewData["CityCode"] = new SelectList(_context.Cities, "Code", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonModel person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CreateAjax()
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "Name");

            ViewData["CityCode"] = new SelectList(_context.Cities, "Code", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateAjax(PersonModel person)
        {
          
            _context.Add(person);         
            _context.SaveChanges();
            return RedirectToAction("IndexAjax");
        }
        public IActionResult Details(int Id)
        {          

            PersonModel person = _context.Peoples.Include(p => p.Country).Include(c => c.City).Where(p => p.PersonId == Id).FirstOrDefault();
            return View(person);
        }
        public IActionResult ViewPerson(int Id)
        {
            PersonModel person = _context.Peoples.Include(p => p.Country).Include(c => c.City).Where(p => p.PersonId == Id).FirstOrDefault();
            return PartialView("_detail", person);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "Name");

            ViewData["CityCode"] = new SelectList(_context.Cities, "Code", "Name");
            PersonModel person = _context.Peoples.Where(c => c.PersonId == Id).FirstOrDefault();

            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(PersonModel person)
        {
            _context.Attach(person);
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult EditPerson(int Id)
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "Name");

            ViewData["CityCode"] = new SelectList(_context.Cities, "Code", "Name");
            PersonModel per = _context.Peoples.Include(p => p.Country).Include(c => c.City).Where(p => p.PersonId == Id).FirstOrDefault();
            return PartialView("_edit", per);
        }
        public IActionResult UpdatePerson(PersonModel person)
        {
                    
            _context.Attach(person);        
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
            return PartialView("_Person", person);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "Name");

            ViewData["CityCode"] = new SelectList(_context.Cities, "Code", "Name");
            PersonModel person = _context.Peoples.Where(c => c.PersonId == Id).FirstOrDefault();
            return View(person);
        }
        [HttpPost]
        public IActionResult DeletePerson(int Id)
        {
            PersonModel per = _context.Peoples.Where(p => p.PersonId == Id).FirstOrDefault();
            _context.Entry(per).State = EntityState.Deleted;            
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(PersonModel person)
        {
            _context.Attach(person);
            _context.Entry(person).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
