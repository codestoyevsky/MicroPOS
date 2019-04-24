using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Transactions;
using MicroPOS.DAL;
using MicroPOS.DAL.Interfaces;
using MicroPOS.DAL.RDS;

namespace MicroPOS.BLL
{
   public class StoreRepository : IStoreRepository
   {
      public int Create(Store entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });

         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.Stores.Add(entity);
               db.SaveChanges();
            }

            scope.Complete();
            return entity.Id;
         }
      }

      public void Update(Store entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });
         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.Stores.AddOrUpdate(entity);
               db.SaveChanges();
            }

            scope.Complete();
         }
      }

      public List<Store> Get()
      {
         using (var db = new MicroPOSDbContext())
         {
            return db.Stores.Include(x => x.Stocks).ToList();
         }
      }

      public Store Get(int id)
      {
         using (var db = new MicroPOSDbContext())
         {
            return db.Stores.Include(x => x.Stocks).FirstOrDefault(x => x.Id == id);
         }
      }
   }
}
