using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MicroPOS.DAL.DTO;
using MicroPOS.DAL.RDS;

namespace MicroPOS.API
{
   public class WebApiApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         InitializeMapper();
         GlobalConfiguration.Configure(WebApiConfig.Register);
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
      }


      private static void InitializeMapper()
      {
         Mapper.Initialize(cfg =>
         {
          
            cfg.CreateMap<Product, ProductDto>();
            cfg.CreateMap<ProductDto, Product>();

            cfg.CreateMap<List<Product>, List<ProductDto>>();
            cfg.CreateMap<List<ProductDto>, List<Product>>();

            cfg.CreateMap<ProductDetailsDto, Product>()
               .ForPath(product => product.ProductGroup.Name, productDetail => productDetail.MapFrom(s => s.GroupName));
            cfg.CreateMap<Product, ProductDetailsDto>()
               .ForPath(productDetail => productDetail.GroupName, product => product.MapFrom(s => s.ProductGroup.Name))
               .ForPath(productDetail => productDetail.Stores, product => product.MapFrom(s => s.Stocks.Select(x => x.StoreId).ToArray()));

            cfg.CreateMap<ProductGroup, ProductGroupDto>();
            cfg.CreateMap<ProductGroupDto, ProductGroup>();


         });
      }
   }
}
