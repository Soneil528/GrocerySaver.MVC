using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Models
{
    public class AllGroceriesCreate
    {
        [Required]
        public string GroceryType { get; set; }
    }
}
