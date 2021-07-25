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

        public MeatDetail GetMeatById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meats
                        .Single(e => e.MeatId == id && e.OwnerId == _userId);
                return
                    new MeatDetail
                    {
                        MeatId = entity.MeatId,
                        Name = entity.Name,
                        ShelfLifeInDays = entity.ShelfLifeInDays,
                        AmountInOunces = entity.AmountInOunces,
                        Count = entity.Count,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateMeat(MeatEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meats
                        .Single(e => e.MeatId == model.MeatId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.ShelfLifeInDays = model.ShelfLifeInDays;
                entity.AmountInOunces = model.AmountInOunces;
                entity.Count = model.Count;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMeat(int meatId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meats
                        .Single(e => e.MeatId == meatId && e.OwnerId == _userId);

                ctx.Meats.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }

}
