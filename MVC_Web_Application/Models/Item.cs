using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Models
{
    public class Item
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10,ErrorMessage ="Maxlength is 10 only")]
        public string Borrower { get; set; }
        [Required]
        public string Lender { get; set; }

        [Required]
        public string ItemName { get; set; }
    }
}
