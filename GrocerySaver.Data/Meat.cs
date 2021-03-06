using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Data
{
    public class Meat
    {
        [Key]
        public int MeatId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ShelfLifeInDays { get; set; }
        [Required]
        public int AmountInOunces { get; set; }
        [Required]
        public int Count { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
        
    }
}
