using System.Collections.Generic;
using MicroPOS.DAL.RDS;
using System.Web.Http;
using MicroPOS.BLL;
using MicroPOS.DAL;
using MicroPOS.DAL.Interfaces;

namespace MicroPOS.API.Controllers
{

   [RoutePrefix("api/Stock")]
   public class StockController : ApiController
   {
      private readonly IStockRepository _stockRepository;

      public StockController()
      {
         _stockRepository = new StockRepository();
      }

      [Route("Save")]
      [HttpPost]
      public IHttpActionResult Save(Stock product)
      {
         _stockRepository.Create(product);
         return Ok();
      }


      [Route("Get")]
      [HttpGet]
      public IHttpActionResult Get(int? id)
      {
         if (id.IsNullOrDefault())
         {
            var result = _stockRepository.Get();
            return Ok(result);
         }
         else
         {
            var result = _stockRepository.Get(id.Value);
            return Ok(result);
         }

      }
   }
}