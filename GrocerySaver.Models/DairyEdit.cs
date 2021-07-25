using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Models
{
    public class DairyEdit
    {
        public int DairyId { get; set; }
        public string Name { get; set; }
        public int ShelfLifeInDays { get; set; }
        public int AmountInOunces { get; set; }
        public int Count { get; set; }
    }
}
