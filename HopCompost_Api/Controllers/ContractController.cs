using System;
using System.Web.Http;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Api.Controllers
{
    public class ContractController : ApiController
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        public IHttpActionResult Get(int id)
        {
            return Json(_contractService.GetContract(id));
        }

        public IHttpActionResult Post([FromBody]ContractViewModel contractViewModel)
        {
            var resultAndMessage = _contractService.TryAddContract(contractViewModel);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }

        public IHttpActionResult Put(int id, [FromBody]ContractViewModel contractViewModel)
        {
            var resultAndMessage = _contractService.TryModifyContract(contractViewModel);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }

        public IHttpActionResult Delete(int id)
        {
            var resultAndMessage = _contractService.TryDeleteContract(id);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }
    }
}
