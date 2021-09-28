using Microsoft.AspNetCore.Mvc;
using MVC_Web_Application.Data;
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
        public IActionResult CategoryList()
        {
            using (_dbContext)
            {
                return View(_dbContext.ExpenseCategories.ToList());
            }
        }
    }
}
