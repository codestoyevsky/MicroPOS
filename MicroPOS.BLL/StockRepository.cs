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
   public class StockRepository : IStockRepository
   {
      public int Create(Stock entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });

         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.Stocks.Add(entity);
               db.SaveChanges();
            }

            scope.Complete();
            return entity.Id;
         }
      }

      public void Update(Stock entity)
      {
         var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });
         using (scope)
         {
            using (var db = new MicroPOSDbContext())
            {
               db.Stocks.AddOrUpdate(entity);
               db.SaveChanges();
            }

            scope.Complete();
         }
      }

      public List<Stock> Get()
      {
         using (var db = new MicroPOSDbContext())
         {
            return db.Stocks.Include(x => x.Product).Include(x=>x.Store).ToList();
         }
      }

      public Stock Get(int id)
      {
         using (var db = new MicroPOSDbContext())
         {
            return db.Stocks.Include(x => x.Product).Include(x => x.Store).FirstOrDefault(x => x.Id == id);
         }
      }
   }
}
