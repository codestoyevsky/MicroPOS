using System.Threading.Tasks;
using MicroPOS.BLL;
using MicroPOS.DAL.RDS;
using System.Web.Http;

namespace MicroPOS.API.Controllers
{
   public class StoreController : ApiController
   {
      public StoreController()
      {
      }

      [HttpPost]
      public async Task<IHttpActionResult> Save(Store product)
      {
         var _storeRepository = new StoreRepository();
         _storeRepository.Create(product);
         return Ok();
      }
   }
}