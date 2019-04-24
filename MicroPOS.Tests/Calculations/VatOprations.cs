using MicroPOS.DAL.DTO;
using NUnit.Framework;
using Shouldly;

namespace MicroPOS.Tests.Calculations
{
   //https://vatcalconline.com/ checked with this site

   [TestFixture]
   public class VatOperations
   {
      [Test]
      public void CalculateVatRate()
      {
         var productDto=  new ProductDto("Test",1,29,34.8 ,null, null);
         productDto.VatRate.ShouldBe(20);
      }

      [Test]
      public void CalculatePrice()
      {
         var productDto = new ProductDto("Test", 1, null, 34.8, 20, null);
         productDto.Price.ShouldBe(29);
      }

      [Test]
      public void CalculatePriceWithVat()
      {
         var productDto = new ProductDto("Test", 1, 29, null, 20, null);
         productDto.PriceWithVat.ShouldBe(34.8);
      }
   }
}
