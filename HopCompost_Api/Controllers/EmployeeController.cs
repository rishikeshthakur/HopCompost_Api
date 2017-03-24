using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HopCompost_Service.Interfaces;

namespace HopCompost_Api.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [System.Web.Http.Route("api/Employee/GetLookup")]
        public IHttpActionResult GetLookup()
        {
            var employees = _employeeService.GetEmployees();

            return Json(employees.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }));
        }
    }
}