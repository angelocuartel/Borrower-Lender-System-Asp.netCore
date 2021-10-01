using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expense expense { get; set; }
        public IEnumerable<SelectListItem> DropDownItems { get; set; }
    }
}
