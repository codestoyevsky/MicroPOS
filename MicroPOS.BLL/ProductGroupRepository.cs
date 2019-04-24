using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Transactions;
using MicroPOS.DAL;
using MicroPOS.DAL.RDS;

namespace MicroPOS.BLL
{
   public class ProductGroupRepository
   {
      public int Create(ProductGroup entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });

         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.ProductGroups.Add(entity);
               db.SaveChanges();
            }

            scope.Complete();
            return entity.Id;
         }
      }

      public void Update(ProductGroup entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });
         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.ProductGroups.AddOrUpdate(entity);
               db.SaveChanges();
            }

            scope.Complete();
         }
      }

      public List<ProductGroup> Get()
      {
         using (var db = new MicroPOSDbContext())
         {
            return db.ProductGroups.Include(x => x.SubGroups).ToList();
         }
      }
   }
}
