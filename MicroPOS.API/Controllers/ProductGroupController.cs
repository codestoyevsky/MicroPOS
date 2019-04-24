using System.Collections.Generic;
using MicroPOS.DAL.RDS;
using System.Web.Http;
using AutoMapper;
using MicroPOS.BLL;
using MicroPOS.DAL.DTO;
using MicroPOS.DAL.Interfaces;

namespace MicroPOS.API.Controllers
{
   [RoutePrefix("api/ProductGroup")]
   public class ProductGroupController : ApiController
   {
      private readonly IProductGroupRepository _productGroupRepository;

      public ProductGroupController()
      {
         _productGroupRepository = new ProductGroupRepository();
      }

      [Route("Save")]
      [HttpPost]
      public IHttpActionResult Save(ProductGroup productGroup)
      {
         _productGroupRepository.Create(productGroup);
         return Ok();
      }


      [Route("Get")]
      [HttpGet]
      public IHttpActionResult Get()
      {
         var groups = _productGroupRepository.Get();
         var result = new List<ProductGroupDto>();
         Mapper.Map(groups, result);
         return Ok(result);
      }
   }
}