using System.Collections.Generic;
using MicroPOS.DAL.RDS;

namespace MicroPOS.DAL.Interfaces
{
   public interface IProductGroupRepository
   {
      int Create(ProductGroup entity);

      void Update(ProductGroup entity);

      List<ProductGroup> Get();

      ProductGroup Get(int id);
   }
}
