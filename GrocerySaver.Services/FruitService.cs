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
        public FruitDetail GetFruitById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fruits
                        .Single(e => e.FruitId == id && e.OwnerId == _userId);
                return
                    new FruitDetail
                    {
                        FruitId = entity.FruitId,
                        Name = entity.Name,
                        ShelfLifeInDays = entity.ShelfLifeInDays,
                        AmountInOunces = entity.AmountInOunces,
                        Count = entity.Count,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateFruit(FruitEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fruits
                        .Single(e => e.FruitId == model.FruitId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.ShelfLifeInDays = model.ShelfLifeInDays;
                entity.AmountInOunces = model.AmountInOunces;
                entity.Count = model.Count;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFruit(int fruitId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fruits
                        .Single(e => e.FruitId == fruitId && e.OwnerId == _userId);

                ctx.Fruits.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
