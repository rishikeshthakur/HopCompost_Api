using System;
using System.Web.Http;
using HopCompost_Common.Enums;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Api.Controllers
{
    public class BinCollectionController : ApiController
    {
        private readonly IBinService _binService;

        public BinCollectionController(IBinService binService)
        {
            _binService = binService;
        }

        [Route("api/BinCollection/GetByDate")]
        public IHttpActionResult GetByDate(DateTime dateTime)
        {
            return Json(_binService.GetBinCollectionByDate(dateTime));
        }

        [Route("api/BinCollection/GetByStatus")]
        public IHttpActionResult GetByStatus(CollectionStatusEnum status)
        {
            return Json(_binService.GetBinCollectionByStatus(status));
        }

        public IHttpActionResult Post([FromBody]BinCollectionViewModel binCollectionViewModel)
        {
            var resultAndMessage = _binService.TryAddBinCollection(binCollectionViewModel);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }

        public IHttpActionResult Put(int id, [FromBody]BinCollectionViewModel binCollectionViewModel)
        {
            var resultAndMessage = _binService.TryModifyBinCollection(binCollectionViewModel);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }
    }
}