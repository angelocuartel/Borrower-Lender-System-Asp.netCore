using Microsoft.EntityFrameworkCore;
using MVC_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Data
{
    public class AppDbContext : DbContext
    {

   
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }




        public DbSet<Item> Items { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

    }
}
