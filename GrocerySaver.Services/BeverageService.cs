using GrocerySaver.Data;
using GrocerySaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Services
{
    public class BeverageService
    {
        private readonly Guid _userId;
        public BeverageService(Guid userId)
        {
            _userId = userId;
        }

        // Creates instance of beverage
        public bool CreateBeverage(BeverageCreate model)
        {
            var entity =
                new Beverage()
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
                ctx.Beverages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BeverageListItem> GetBeverages() // Beverages from a specific user
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Beverages
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new BeverageListItem
                                {
                                    BeverageId = e.BeverageId,
                                    Name = e.Name,
                                    ShelfLifeInDays = e.ShelfLifeInDays,
                                    AmountInOunces = e.AmountInOunces,
                                    Count = e.Count,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public BeverageDetail GetBeverageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beverages
                        .Single(e => e.BeverageId == id && e.OwnerId == _userId);
                return
                    new BeverageDetail
                    {
                        BeverageId = entity.BeverageId,
                        Name = entity.Name,
                        ShelfLifeInDays = entity.ShelfLifeInDays,
                        AmountInOunces = entity.AmountInOunces,
                        Count = entity.Count,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateBeverage(BeverageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beverages
                        .Single(e => e.BeverageId == model.BeverageId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.ShelfLifeInDays = model.ShelfLifeInDays;
                entity.AmountInOunces = model.AmountInOunces;
                entity.Count = model.Count;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBeverage(int beverageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beverages
                        .Single(e => e.BeverageId == beverageId && e.OwnerId == _userId);

                ctx.Beverages.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
