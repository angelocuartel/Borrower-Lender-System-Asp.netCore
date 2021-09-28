using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Web_Application.Data;
using MVC_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ExpenseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public  IActionResult ExpenseList()
        {
            return  View(_dbContext.Expenses.ToList());
        }

        public IActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreateExpense(Expense newExpense)
        {
            _dbContext.Expenses.Add(newExpense);
            _dbContext.SaveChanges();

            return RedirectToAction("ExpenseList");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (_dbContext)
            {
                return View(_dbContext.Expenses.Find(id));
            }
           
        }

        [HttpPost]
        public IActionResult DeleteExpense(int id)
        {
            using (_dbContext)
            {
                _dbContext.Remove(_dbContext.Expenses.Find(id));
                _dbContext.SaveChanges();
                return RedirectToAction("ExpenseList");
            }

            

        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            using (_dbContext)
            {
                return View (_dbContext.Expenses.Find(id));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(Expense expense)
        {
            using (_dbContext)
            {
                _dbContext.Update(expense);
                _dbContext.SaveChanges();
                return RedirectToAction("ExpenseList");
            }
        }






        
    }
}
