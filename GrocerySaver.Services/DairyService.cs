using GrocerySaver.Data;
using GrocerySaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Services
{
    public class DairyService
    {
        private readonly Guid _userId;
        public DairyService(Guid userId)
        {
            _userId = userId;
        }

        // Creates instance of dairy
        public bool CreateDairy(DairyCreate model)
        {
            var entity =
                new Dairy()
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
                ctx.Dairies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DairyListItem> GetDairies() // Displays dairies from a specific user
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dairies
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new DairyListItem
                                {
                                    DairyId = e.DairyId,
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
        public DairyDetail GetDairyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dairies
                        .Single(e => e.DairyId == id && e.OwnerId == _userId);
                return
                    new DairyDetail
                    {
                        DairyId = entity.DairyId,
                        Name = entity.Name,
                        ShelfLifeInDays = entity.ShelfLifeInDays,
                        AmountInOunces = entity.AmountInOunces,
                        Count = entity.Count,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateDairy(DairyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dairies
                        .Single(e => e.DairyId == model.DairyId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.ShelfLifeInDays = model.ShelfLifeInDays;
                entity.AmountInOunces = model.AmountInOunces;
                entity.Count = model.Count;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
