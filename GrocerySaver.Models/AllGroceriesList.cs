using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Models
{
    public class AllGroceriesList
    {
        public int GroceryId { get; set; }
        [Display(Name =("Type of Grocery"))]
        public string GroceryType { get; set; }
    }
}
