using System.Collections.Generic;
using MicroPOS.DAL.RDS;

namespace MicroPOS.DAL.Interfaces
{
   public interface IStockRepository
   {
      int Create(Stock entity);

      void Update(Stock entity);

      List<Stock> Get();

      Stock Get(int id);
   }
}
