using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.RDS;

namespace MicroPOS.DAL.RDS
{

   [Table("Stores")]
   public class Store : Base
   {
      [Required]
      public string Name { get; set; }
   }
}
