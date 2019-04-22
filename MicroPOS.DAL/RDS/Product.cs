using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using DAL.RDS;
using Newtonsoft.Json;

namespace MicroPOS.DAL.RDS
{
   [Table("Products")]
   public class Product : Base
   {
      [Required]
      public string Name { get; set; }
      [Required]
      public int ProductGroupId { get; set; }
      [Required]
      public decimal Price { get; set; }
      public decimal PriceWithVAT { get; set; }
      public decimal VATRate { get; set; }

      public int[] StoresArray { get; set; }

      [IgnoreDataMember]
      public string Stores => StoresArray.ToString();

      [JsonIgnore]
      [IgnoreDataMember]
      public virtual ProductGroup ProductGroup { get; set; }
   }
}
