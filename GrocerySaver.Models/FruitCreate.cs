using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Models
{
    public class FruitCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Days Left to Expire")]
        public int ShelfLifeInDays { get; set; }
        [Required]
        [Display(Name = "Fluid Ounces")]
        public int AmountInOunces { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
