using System.Collections.Generic;
using MicroPOS.DAL.RDS;

namespace MicroPOS.DAL.Interfaces
{
   public interface IProductRepository
   {
      int Create(Product entity);

      void Update(Product entity);

      List<Product> Get();

      Product Get(int id);
   }
}
