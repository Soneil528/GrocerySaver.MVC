using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Models
{
    public class MeatEdit
    {
        public int MeatId { get; set; }

        public string Name { get; set; }
        public int ShelfLifeInDays { get; set; }
        public int AmountInOunces { get; set; }
        public int Count { get; set; }
    }
}
