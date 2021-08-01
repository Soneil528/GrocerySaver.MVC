using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Data
{
    public class AllGroceries
    {
        public AllGroceries()
        {
            Meats = new List<Meat>();
            Beverages = new List<Beverage>();
            Dairies = new List<Dairy>();
            Fruits = new List<Fruit>();
            Vegetables = new List<Vegetable>();
        }
        [Key]
        public int GroceryId { get; set; }
        public List<Meat> Meats { get; set; }
        public List<Beverage> Beverages { get; set; }
        public List<Dairy> Dairies { get; set; }
        public List<Fruit> Fruits { get; set; }
        public List<Vegetable> Vegetables { get; set; }
    }
}
