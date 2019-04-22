using System.Threading.Tasks;
using MicroPOS.BLL;
using MicroPOS.DAL.RDS;
using System.Web.Http;

namespace MicroPOS.API.Controllers
{
   public class ProductGroupController : ApiController
   {
      public ProductGroupController()
      {
      }

      [HttpPost]
      public async Task<IHttpActionResult> Save(ProductGroup productGroup)
      {
         var _productGroupRepository = new ProductGroupRepository();
         _productGroupRepository.Create(productGroup);
         return Ok();
      }
   }
}