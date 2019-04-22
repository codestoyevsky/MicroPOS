using System.Threading.Tasks;
using MicroPOS.BLL;
using MicroPOS.DAL.RDS;
using System.Web.Http;

namespace MicroPOS.API.Controllers
{
   public class ProductController : ApiController
   {
      public  ProductController()
      {
      }

      [HttpPost]
      public async Task<IHttpActionResult> Save(Product product)
      {
         var _productRepository = new ProductRepository();
         _productRepository.Create(product);
         return Ok();
      }
   }
}