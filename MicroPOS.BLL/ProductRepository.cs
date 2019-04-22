using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Transactions;
using MicroPOS.DAL;
using MicroPOS.DAL.RDS;

namespace MicroPOS.BLL
{
   public class ProductRepository
   {
      public int Create(Product entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });

         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.Products.Add(entity);
               db.SaveChanges();
            }

            scope.Complete();
            return entity.Id;
         }
      }

      public void Update(Product entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });
         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.Products.AddOrUpdate(entity);
               db.SaveChanges();
            }

            scope.Complete();
         }
      }

      public List<Product> Get()
      {
         using (var db = new MicroPOSDbContext())
         {
            return db.Products.ToList();
         }
      }

      public Product Get(int id)
      {
         using (var db = new MicroPOSDbContext())
         {
            return db.Products.FirstOrDefault(x => x.Id == id);
         }
      }
   }
}
