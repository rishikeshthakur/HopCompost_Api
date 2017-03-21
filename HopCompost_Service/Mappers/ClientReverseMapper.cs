using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Mappers
{
    public class ClientReverseMapper : MapperBase, IMapper<ClientViewModel, Client>
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientReverseMapper(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Map(ClientViewModel source)
        {
            var client = source.Id == default(int) ? _clientRepository.NewObject() : _clientRepository.Single(p => p.Id == source.Id);

            client.Name = source.Name;
            client.Address = source.Address;
            client.EmergencyContact = source.EmergencyContact;

            return client;
        }
    }
}