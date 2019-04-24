using System.Collections.Generic;

namespace MicroPOS.DAL.DTO
{
   public class ProductGroupDto
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public int ParentId { get; set; }

      public List<ProductGroupDto> SubGroups { get; set; }
   }
}
