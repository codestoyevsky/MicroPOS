using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using DAL.RDS;
using Newtonsoft.Json;

namespace MicroPOS.DAL.RDS
{
   [Table("ProductGroups")]
   public class ProductGroup : Base
   {
      [Required]
      public string Name { get; set; }

      public int? ParentId { get; set; }


      [JsonIgnore]
      [IgnoreDataMember]
      [ForeignKey("ParentId")]
      public virtual List<ProductGroup> SubGroups { get; set; }
   }
}
