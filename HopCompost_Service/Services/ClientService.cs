using System;
using System.Collections.Generic;
using System.Linq;
using HopCompost_Common.Misc;
using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Services
{
    public class ClientService : ServiceBase, IClientService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IMapper<Client, ClientViewModel> _clientMapper;
        private readonly IMapper<ClientViewModel, Client> _clientReverseMapper;

        public ClientService(IRepository<Client> clientRepository, IMapper<Client, ClientViewModel> clientMapper, IMapper<ClientViewModel, Client> clientReverseMapper)
        {
            _clientRepository = clientRepository;
            _clientMapper = clientMapper;
            _clientReverseMapper = clientReverseMapper;
        }

        public IEnumerable<ClientViewModel> GetClients()
        {
            return _clientRepository.GetAll().Select(p => _clientMapper.Map(p));
        }

        public ClientViewModel GetClient(int id)
        {
            return _clientMapper.Map(_clientRepository.Single(p => p.Id == id));
        }

        public ResultAndMessage TryAddClient(ClientViewModel clientViewModel)
        {
            var client = _clientReverseMapper.Map(clientViewModel);

            try
            {
                _clientRepository.Add(client);

                return _clientRepository.TryToSaveChanges();
            }
            catch (Exception exception)
            {
                return ResultAndMessage.Failed(exception.Message);
            }
        }

        public ResultAndMessage TryModifyClient(ClientViewModel clientViewModel)
        {
            var client = _clientReverseMapper.Map(clientViewModel);

            try
            {
                _clientRepository.Modify(client);

                return _clientRepository.TryToSaveChanges();
            }
            catch (Exception exception)
            {
                return ResultAndMessage.Failed(exception.Message);
            }
        }

        public ResultAndMessage TryDeleteClient(int id)
        {
            var client = _clientRepository.Single(p => p.Id == id);

            try
            {
                _clientRepository.Remove(client);

                return _clientRepository.TryToSaveChanges();
            }
            catch (Exception exception)
            {
                return ResultAndMessage.Failed(exception.Message);
            }
        }
    }
}