using GrocerySaver.Data;
using GrocerySaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Services
{
    public class VegetableService
    {
        private readonly Guid _userId;
        public VegetableService(Guid userId)
        {
            _userId = userId;
        }

        // Creates instance of Vegetable
        public bool CreateVegetable(VegetableCreate model)
        {
            var entity =
                new Vegetable()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    ShelfLifeInDays = model.ShelfLifeInDays,
                    AmountInOunces = model.AmountInOunces,
                    Count = model.Count,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vegetables.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VegetableListItem> GetVegetables() // Vegetables from a specific user
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vegetables
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new VegetableListItem
                                {
                                    VegetableId = e.VegetableId,
                                    Name = e.Name,
                                    ShelfLifeInDays = e.ShelfLifeInDays,
                                    Count = e.Count,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
