using System.Linq;
using HopCompost_DataAccess;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Mappers
{
    public class ClientMapper : MapperBase, IMapper<Client, ClientViewModel>
    {
        private readonly IMapper<Contract, ContractViewModel> _contractMapper;

        public ClientMapper(IMapper<Contract, ContractViewModel> contractMapper)
        {
            _contractMapper = contractMapper;
        }

        public ClientViewModel Map(Client source)
        {
            return new ClientViewModel
            {
                Id = source.Id,
                Name = source.Name,
                Address = source.Address,
                EmergencyContact = source.EmergencyContact,
                Contracts = source.Contracts.Select(p => _contractMapper.Map(p))
            };
        }
    }
}