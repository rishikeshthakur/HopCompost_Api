using System;
using System.Linq;
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

        public IHttpActionResult Get(int id)
        {
            return Json(_binService.GetBinCollectionById(id));
        }

        [Route("api/BinCollection/GetPastCollection")]
        public IHttpActionResult GetPastCollection(int? employeeId, int? clientId, DateTime? selectedDate)
        {
            var result = _binService.GetPastCollection(employeeId, clientId, selectedDate);

            return Json(result);
        }

        [Route("api/BinCollection/GetByDate")]
        public IHttpActionResult GetByDate(DateTime dateTime)
        {
            return Json(_binService.GetBinCollectionByDate(dateTime));
        }

        [Route("api/BinCollection/GetBinCollectionByStatus")]
        public IHttpActionResult GetBinCollectionByStatus(CollectionStatusEnum status)
        {
            return Json(_binService.GetBinCollectionByStatus(status));
        }

        [Route("api/BinCollection/GetBinWeightCollection")]
        public IHttpActionResult GetBinWeightCollection(int id)
        {
            return Json(_binService.GetBinWeightCollection(id));
        }

        public IHttpActionResult Post([FromBody] BinWeightCollectionViewModel binWeightCollectionViewModel)
        {
            var resultAndMessage = _binService.TryAddBinWeightCollection(binWeightCollectionViewModel);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }

        //public IHttpActionResult Post([FromBody]BinCollectionViewModel binCollectionViewModel)
        //{
        //    var resultAndMessage = _binService.TryAddBinCollection(binCollectionViewModel);

        //    return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        //}

        public IHttpActionResult Put(int id, [FromBody]BinCollectionViewModel binCollectionViewModel)
        {
            var resultAndMessage = _binService.TryModifyBinCollection(binCollectionViewModel);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }
    }
}