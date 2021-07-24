using GrocerySaver.Data;
using GrocerySaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Services
{
    public class MeatService
    {
        private readonly Guid _userId;
        public MeatService(Guid userId)
        {
            _userId = userId;
        }
        // Creates instance of meat
        public bool CreateMeat(MeatCreate model)
        {
            var entity =
                new Meat()
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
                ctx.Meats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MeatListItem> GetMeats() // Gets meats from a specific user
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Meats
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MeatListItem
                                {
                                    MeatId = e.MeatId,
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
    }

}
