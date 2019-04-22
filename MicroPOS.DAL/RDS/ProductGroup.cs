using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.RDS;

namespace MicroPOS.DAL.RDS
{
   [Table("ProductGroups")]
   public class ProductGroup : Base
   {
      [Required]
      public string Name { get; set; }

      [Required]
      public int ParentId { get; set; }
   }
}
