using System.Data.Entity.Migrations;
using System.Transactions;
using MicroPOS.DAL;
using MicroPOS.DAL.RDS;

namespace MicroPOS.BLL
{
   public class StoreRepository
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
   }
}
