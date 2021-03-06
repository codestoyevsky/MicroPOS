﻿using System.Linq;
using MicroPOS.DAL.RDS;
using System.Web.Http;
using MicroPOS.BLL;
using MicroPOS.DAL;
using MicroPOS.DAL.Interfaces;

namespace MicroPOS.API.Controllers
{

   [RoutePrefix("api/Store")]
   public class StoreController : ApiController
   {
      private readonly IStoreRepository _iStoreRepository;

      private StoreController()
      {
         _iStoreRepository = new StoreRepository();
      }

      [Route("Save")]
      [HttpPost]
      public IHttpActionResult Save(Store product)
      {
         _iStoreRepository.Create(product);
         return Ok();
      }

      [Route("Get")]
      [HttpGet]
      public IHttpActionResult Get(int? id)
      {

         if (id.IsNullOrDefault())
         {
            var result = _iStoreRepository.Get().ToList();
            return Ok(result);
         }

         else
         {
            var result = _iStoreRepository.Get(id.Value);
            return Ok(result);
         }

      }
   }
}