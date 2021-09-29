using Microsoft.AspNetCore.Mvc;
using MVC_Web_Application.Data;
using MVC_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ExpenseCategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            using (_dbContext)
            {
                return View(_dbContext.ExpenseCategories.ToList());
            }
        }

        public IActionResult AddExpenseCategory()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExpenseCategory(ExpenseCategory category)
        {
            using (_dbContext)
            {
                _dbContext.ExpenseCategories.Add(category);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("CategoryList");
        }


    }
}
