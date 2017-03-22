using HopCompost_DataAccess;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Mappers
{
    public class EmployeeMapper : MapperBase, IMapper<Employee, EmployeeViewModel>
    {
        public EmployeeViewModel Map(Employee source)
        {
            return new EmployeeViewModel
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }
}