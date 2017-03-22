using System.Collections.Generic;
using System.Linq;
using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Services
{
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        private readonly IMapper<Employee, EmployeeViewModel> _employeeMapper;
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IMapper<Employee, EmployeeViewModel> employeeMapper, IRepository<Employee> employeeRepository)
        {
            _employeeMapper = employeeMapper;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            return _employeeRepository.GetAll().Select(p => _employeeMapper.Map(p));
        }
    }
}