using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetEmployees();
    }
}
