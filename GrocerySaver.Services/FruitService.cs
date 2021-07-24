using GrocerySaver.Data;
using GrocerySaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Services
{
    public class FruitService
    {
        private readonly Guid _userId;
        public FruitService(Guid userId)
        {
            _userId = userId;
        }

        // Creates instance of beverage
        public bool CreateFruit(FruitCreate model)
        {
            var entity =
                new Fruit()
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
                ctx.Fruits.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FruitListItem> GetFruits() // Shows fruits from a specific user
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Fruits
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FruitListItem
                                {
                                    FruitId = e.FruitId,
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
