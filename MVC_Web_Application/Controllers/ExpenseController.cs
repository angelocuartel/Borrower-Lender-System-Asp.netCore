using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Web_Application.Data;
using MVC_Web_Application.Interface;
using MVC_Web_Application.Models;
using MVC_Web_Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _dbContext;

        private readonly IDbService<string> _person;
        public ExpenseController(AppDbContext dbContext, IDbService<string> person)
        {
            _dbContext = dbContext;
            _person = person;
        }



        [HttpGet]
        public  IActionResult ExpenseList()
        {
            using (_dbContext)
            {
                var expenseList = _dbContext.Expenses.ToList();

                foreach (var item in expenseList)
                {
                    item.ExpenseCategory = _dbContext.ExpenseCategories
                        .FirstOrDefault(x => x.CategoryId == item.ExpenseCategoryId);
                }
                return View(_dbContext.Expenses.ToList());
            }
          
        }

        public  IActionResult CreateExpense()
        {
            var expense = new ExpenseVM()
            {
                expense = new Expense(),
                DropDownItems = _dbContext.ExpenseCategories.Select(d => new SelectListItem()
                {
                    Text = d.CategoryName,
                    Value = d.CategoryId.ToString()
                })
            };

       
            
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreateExpense(ExpenseVM newExpense)
        {
            _dbContext.Expenses.Add(newExpense.expense);
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
