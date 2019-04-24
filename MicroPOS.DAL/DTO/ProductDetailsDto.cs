namespace MicroPOS.DAL.DTO
{
   public class ProductDetailsDto
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string GroupName { get; set; }
      public double? Price { get; set; }
      public double? PriceWithVat { get; set; }
      public double? VatRate { get; set; }
      public int[] Stores { get; set; }
   }
}
