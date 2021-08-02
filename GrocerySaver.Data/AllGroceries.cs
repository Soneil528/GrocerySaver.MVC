using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Data
{
    public class AllGroceries
    {
        
        [Key]
        public int GroceryId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string  GroceryType { get; set; }

        public virtual ICollection<Beverage> ListOfBeverages { get; set; }
        public AllGroceries()
        {
            ListOfBeverages = new HashSet<Beverage>();
        }
        [ForeignKey(nameof(Beverage))]
        public int BeverageId { get; set; }
        public Beverage Beverage { get; set; }
        [ForeignKey(nameof(Dairy))]
        public int DairyId { get; set; }
        public Dairy Dairy { get; set; }
        [ForeignKey(nameof(Fruit))]
        public int FruitId { get; set; }
        public Fruit Fruit { get; set; }
        [ForeignKey(nameof(Meat))]
        public int MeatId { get; set; }
        public Meat Meat { get; set; }
        [ForeignKey(nameof(Vegetable))]
        public int VegetableId { get; set; }
        public Vegetable Vegetable { get; set; }
    }
}
