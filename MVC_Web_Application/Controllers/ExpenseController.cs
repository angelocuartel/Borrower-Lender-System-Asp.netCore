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
        public IActionResult DeleteExpense(Expense expense)
        {
            return View(expense);
        }

        [HttpDelete]

        public IActionResult DeleteExpense(int id)
        {
            _dbContext.Remove(_dbContext.Expenses.Find(id));
            return RedirectToAction("ExpenseList");
        }






        
    }
}
