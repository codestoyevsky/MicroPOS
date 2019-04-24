using MicroPOS.BLL;
using MicroPOS.DAL.RDS;
using System.Web.Http;

namespace MicroPOS.API.Controllers
{
   public class StoreController : ApiController
   {

      [HttpPost]
      public IHttpActionResult Save(Store product)
      {
         var storeRepository = new StoreRepository();
         storeRepository.Create(product);
         return Ok();
      }
   }
}