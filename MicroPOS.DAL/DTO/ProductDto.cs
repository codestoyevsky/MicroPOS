using System.ComponentModel.DataAnnotations;

namespace MicroPOS.DAL.DTO
{
   public class ProductDto
   {
      public ProductDto(string name, int productGroupId, double? price, double? priceWithVat, double? vatRate, int[] stores)
      {
         Name = name;
         ProductGroupId = productGroupId;
         Price = price;
         PriceWithVat = priceWithVat;
         VatRate = vatRate;
         Stores = stores;

         if (Price.IsNullOrDefault()) Price = CalculatePrice();
         if (PriceWithVat.IsNullOrDefault()) PriceWithVat = CalculatePriceWithVat();
         if (VatRate.IsNullOrDefault()) VatRate = CalculateVatRate();
      }

      [Required]
      public string Name { get; set; }


      [Required]
      public int ProductGroupId { get; set; }

      /// <summary>
      /// Price of the product
      /// </summary>
      public double? Price { get; set; }


      /// <summary>
      /// Price with VAT included
      /// </summary>
      public double? PriceWithVat { get; set; }

      /// <summary>
      /// VAT Rate
      /// </summary>
      public double? VatRate { get; set; }

      /// <summary>
      /// Add to stocks
      /// </summary>
      public int[] Stores { get; set; }

      public double? CalculatePriceWithVat()
      {
         if (Price.IsNullOrDefault() || VatRate.IsNullOrDefault()) return null;
         return Price * ((VatRate + 100) / 100);
      }

      public double? CalculatePrice()
      {
         if (PriceWithVat.IsNullOrDefault() || VatRate.IsNullOrDefault()) return null;
         return PriceWithVat / ((VatRate + 100) / 100);
      }

      public double? CalculateVatRate()
      {
         if (PriceWithVat.IsNullOrDefault() || Price.IsNullOrDefault()) return null;
         return (PriceWithVat / Price) * 100 - 100;
      }
   }
}
