using System.Runtime.Serialization;
using DAL.RDS;
using Newtonsoft.Json;

namespace MicroPOS.DAL.RDS
{
   public class Stock : Base
   {
      /// <summary>
      /// Id of Product
      /// </summary>
      public int ProductId { get; set; }


      /// <summary>
      /// Id of Store
      /// </summary>
      public int StoreId { get; set; }


      [JsonIgnore]
      [IgnoreDataMember]
      public virtual Product Product { get; set; }


      [JsonIgnore]
      [IgnoreDataMember]
      public virtual Store Store { get; set; }
   }
}
