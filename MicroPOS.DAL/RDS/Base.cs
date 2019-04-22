using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.RDS
{
   public class Base
   {
      [Key]
      public int Id { get; set; }

      [Required]
      public DateTime CreatedDate { get; set; }
   }
}
