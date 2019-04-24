using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using DAL.RDS;
using Newtonsoft.Json;

namespace MicroPOS.DAL.RDS
{

   [Table("Stores")]
   public class Store : Base
   {
      [Required]
      public string Name { get; set; }

      [JsonIgnore]
      [IgnoreDataMember]
      [ForeignKey("StoreId")]
      public virtual List<Stock> Stocks { get; set; }


      [NotMapped]
      public virtual int[] Products => Stocks.Select(x =>x.ProductId).ToArray();
   }
}
