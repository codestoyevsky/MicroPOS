using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Transactions;
using MicroPOS.DAL;
using MicroPOS.DAL.RDS;
using System.Data.Entity;
using MicroPOS.DAL.Interfaces;

namespace MicroPOS.BLL
{
   public class ProductRepository : IProductRepository
   {
      public int Create(Product entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });

         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.Products.Add(entity);
               foreach (var storeId in entity.Stores)
               {
                  if (storeId==0) continue;
                  var stock = new Stock { ProductId = entity.Id, StoreId = storeId };
                  db.Stocks.Add(stock);
               }
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
            return db.Products.Include(x => x.ProductGroup).Include(x=>x.Stocks).ToList();
         }
      }

      public Product Get(int id)
      {
         using (var db = new MicroPOSDbContext())
         {
            return db.Products.Include(x=>x.ProductGroup).Include(x => x.Stocks).FirstOrDefault(x => x.Id == id);
         }
      }
   }
}
