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

        public IEnumerable<BeverageListItem> GetBeverages()
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
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
