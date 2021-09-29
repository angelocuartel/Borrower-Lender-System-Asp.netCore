using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        [StringLength(10,ErrorMessage ="Maxlength is 10")]
        public string ExpenseName { get; set; }

        [Required]
        public decimal ExpenseAmount { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
}
