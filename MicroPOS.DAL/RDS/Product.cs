using System.Collections.Generic;
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
      /// <summary>
      /// Name of the product
      /// </summary>
      [Required]
      [StringLength(150)]
      public string Name { get; set; }

      /// <summary>
      /// Product group Id which it belongs to
      /// </summary>
      [Required]
      public int ProductGroupId { get; set; }

      /// <summary>
      /// Price of the product
      /// </summary>
      [Required]
      public double? Price { get; set; }


      /// <summary>
      /// Price with VAT included
      /// </summary>
      [Required]
      public double PriceWithVat { get; set; }

      /// <summary>
      /// VAT Rate
      /// </summary>
      [Required]
      public double VatRate { get; set; }
      
      [NotMapped]
      public int[] Stores{ get; set; }

      [JsonIgnore]
      [IgnoreDataMember]
      public virtual ProductGroup ProductGroup { get; set; }


      [JsonIgnore]
      [IgnoreDataMember]
      public virtual List<Stock> Stocks { get; set; }
   }
}
