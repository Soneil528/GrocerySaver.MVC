using GrocerySaver.Data;
using GrocerySaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySaver.Services
{
    public class AllGroceriesService
    {
        private readonly Guid _userId;
        public AllGroceriesService(Guid userId)
        {
            _userId = userId;
        }

        // Creates instance of AllGroceries
        public bool CreateAllGroceries(AllGroceriesCreate model)
        {
            var entity =
                new AllGroceries()
                {
                    OwnerId = _userId,
                    GroceryType = model.GroceryType
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.AllGroceriess.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AllGroceriesList> GetAllGroceries() // AllGroceries from a specific user
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .AllGroceriess
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AllGroceriesList
                                {
                                    GroceryId = e.GroceryId,
                                    GroceryType = e.GroceryType
                                }
                        );
                return query.ToArray();
            }
        }

        public AllGroceriesDetail GetAllGroceriesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AllGroceriess
                        .Single(e => e.GroceryId == id && e.OwnerId == _userId);
                return
                    new AllGroceriesDetail
                    {
                        GroceryId = entity.GroceryId,
                        GroceryType = entity.GroceryType
                    };
            }
        }

        public bool UpdateAllGroceries(AllGroceriesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AllGroceriess
                        .Single(e => e.GroceryId == model.GroceryId && e.OwnerId == _userId);

                entity.GroceryType = model.GroceryType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAllGroceries(int groceryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AllGroceriess
                        .Single(e => e.GroceryId == groceryId && e.OwnerId == _userId);

                ctx.AllGroceriess.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
