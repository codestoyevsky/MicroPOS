using System.Collections.Generic;
using System.Linq;
using MicroPOS.BLL;
using MicroPOS.DAL.RDS;
using System.Web.Http;
using AutoMapper;
using MicroPOS.DAL;
using MicroPOS.DAL.DTO;
using MicroPOS.DAL.Interfaces;

namespace MicroPOS.API.Controllers
{
   [RoutePrefix("api/Product")]
   public class ProductController : ApiController
   {
      private readonly IProductRepository _productRepository;
      private readonly IProductGroupRepository _productGroupRepository;
      private readonly IStoreRepository _storeRepository;

      public ProductController()
      {
         _productRepository = new ProductRepository();
         _productGroupRepository = new ProductGroupRepository();
         _storeRepository = new StoreRepository();
      }

      [Route("Save")]
      [HttpPost]
      public IHttpActionResult Save(ProductDto product)
      {
         if (product.VatRate.IsNullOrDefault() || product.Price.IsNullOrDefault() || product.PriceWithVat.IsNullOrDefault())
         {
            return BadRequest("At least two values from these 3 must be entered : Price, VAT Rate, Price With VAT.");
         }

         if (_productGroupRepository.Get(product.ProductGroupId) == null)
         {
            return BadRequest($"Entered Product Group Id:{product.ProductGroupId} does not exist in Database.");
         }

         var stores = _storeRepository.Get();

         foreach (var store in product.Stores)
         {
            if (!stores.Select(x => x.Id).Contains(store))
            {
               return BadRequest($"Store with Id: {store} does not exist in Database");
            }
         }

         var entity = new Product { Id = 0 };
         Mapper.Map(product, entity);
         var id = _productRepository.Create(entity);
         return Ok($"New product added to Database, Id: {id}");
      }


      [Route("Get")]
      [HttpGet]
      public IHttpActionResult Get(int? id)
      {

         if (id.IsNullOrDefault())
         {
            var products = _productRepository.Get();
            var result = new List<ProductDetailsDto>();
            Mapper.Map(products.ToList(), result);
            return Ok(result);
         }

         else
         {
            var product = _productRepository.Get(id.Value);
            var result = new ProductDetailsDto();
            Mapper.Map(product, result);
            return Ok(result);
         }

      }
   }
}