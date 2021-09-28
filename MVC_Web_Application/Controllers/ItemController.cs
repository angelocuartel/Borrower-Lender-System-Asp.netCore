using Microsoft.AspNetCore.Mvc;
using MVC_Web_Application.Data;
using MVC_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ItemController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  IActionResult Index()
        {

            return View(_dbContext.Items.ToList());
        }


        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateItem(Item item)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.AddAsync(item);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("CreateItem");
        }


        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            using (_dbContext)
            {
                return View(_dbContext.Items.Find(id));
            }

        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Delete(int? id)
        {
            
            _dbContext.Remove(_dbContext.Items.Find(id));
             _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


         [HttpGet]
        public IActionResult Update(int? id)
        {
            return View(_dbContext.Items.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item item)
        {
            _dbContext.Update(item);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

     

        
    }
}
