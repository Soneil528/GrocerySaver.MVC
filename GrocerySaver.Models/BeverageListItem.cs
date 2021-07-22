using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Models
{
   public class BeverageListItem
    {
        [Display(Name = "Id")]
        public int BeverageId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Days Left to Expire")]
        public int ShelfLifeInDays { get; set; }
        [Display(Name = "Fluid Ounces")]
        public int AmountInOunces { get; set; }
        [Display(Name = "Quantity")]
        public int Count { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
