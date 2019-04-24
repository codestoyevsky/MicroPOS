using System.Collections.Generic;
using MicroPOS.DAL.RDS;

namespace MicroPOS.DAL.Interfaces
{
   public interface IStoreRepository
   {
      int Create(Store entity);

      void Update(Store entity);

      List<Store> Get();

      Store Get(int id);
   }
}
