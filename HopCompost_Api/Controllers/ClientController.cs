using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Api.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IHttpActionResult Get()
        {
            return Json(_clientService.GetClients());
        }
        
        public IHttpActionResult Get(int id)
        {
            return Json(_clientService.GetClient(id));
        }

        [System.Web.Http.Route("api/Client/GetLookup")]
        public IHttpActionResult GetLookup()
        {
            var clients = _clientService.GetClients();
            
            return Json(clients.Select(p => new SelectListItem {  Text = p.Name, Value = p.Id.ToString()}));
        }

        public IHttpActionResult Post([FromBody]ClientViewModel clientViewModel)
        {
            var resultAndMessage = _clientService.TryAddClient(clientViewModel);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }

        public IHttpActionResult Put(int id, [FromBody]ClientViewModel clientViewModel)
        {
            var resultAndMessage = _clientService.TryModifyClient(clientViewModel);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }

        public IHttpActionResult Delete(int id)
        {
            var resultAndMessage = _clientService.TryDeleteClient(id);

            return resultAndMessage.IsSuccessful ? (IHttpActionResult)Ok() : InternalServerError();
        }
    }
}
