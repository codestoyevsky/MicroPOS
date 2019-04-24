using System.Collections.Generic;
using MicroPOS.BLL;
using MicroPOS.DAL.RDS;
using System.Web.Http;
using AutoMapper;
using MicroPOS.DAL.DTO;

namespace MicroPOS.API.Controllers
{
   [RoutePrefix("api/ProductGroup")]
   public class ProductGroupController : ApiController
   {
     
      [HttpPost]
      public IHttpActionResult Save(ProductGroup productGroup)
      {
         var productGroupRepository = new ProductGroupRepository();
         productGroupRepository.Create(productGroup);
         return Ok();
      }


      [Route("Get")]
      [HttpGet]
      public IHttpActionResult Get()
      {
         var productGroupRepository = new ProductGroupRepository();
         var groups =productGroupRepository.Get();
         var result = new List<ProductGroupDto>();
         Mapper.Map(groups, result);
         return Ok(result);
      }
   }
}