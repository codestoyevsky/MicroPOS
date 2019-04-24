using System.Collections.Generic;
using System.Linq;
using MicroPOS.BLL;
using MicroPOS.DAL.RDS;
using System.Web.Http;
using AutoMapper;
using MicroPOS.DAL;
using MicroPOS.DAL.DTO;

namespace MicroPOS.API.Controllers
{
   public class ProductController : ApiController
   {
      [HttpPost]
      public IHttpActionResult Save(ProductDto product)
      {
         if (product.VatRate.IsNullOrDefault() || product.Price.IsNullOrDefault() || product.PriceWithVat.IsNullOrDefault())
         {
            return BadRequest("At least two values from these 3 must be entered : Price, VAT Rate, Price With VAT");
         }

         var entity = new Product();
         Mapper.Map(product, entity);
         var productRepository = new ProductRepository();
         productRepository.Create(entity);
         return Ok();
      }


      [HttpPost]
      public IHttpActionResult Get(int? id)
      {
         var productRepository = new ProductRepository();

         if (id.IsNullOrDefault())
         {
            var products = productRepository.Get();
            var result = new List<ProductDetailsDto>();
            Mapper.Map(products.ToList(), result);
            return Ok(result);
         }

         else
         {
            var product = productRepository.Get(id.Value);
            var result = new ProductDetailsDto();
            Mapper.Map(product, result);
            return Ok(result);
         }

      }
   }
}