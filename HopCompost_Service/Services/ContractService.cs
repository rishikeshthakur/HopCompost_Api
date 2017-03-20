using System;
using HopCompost_Common.Misc;
using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Services
{
    public class ContractService : ServiceBase, IContractService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Contract> _contractRepository;
        private readonly IMapper<Contract, ContractViewModel> _contractMapper;
        private readonly IMapper<ContractViewModel, Contract> _contractReverseMapper;

        public ContractService(IRepository<Contract> contractRepository, IMapper<Contract, ContractViewModel> contractMapper, IMapper<ContractViewModel, Contract> contractReverseMapper, IRepository<Client> clientRepository)
        {
            _contractRepository = contractRepository;
            _contractMapper = contractMapper;
            _contractReverseMapper = contractReverseMapper;
            _clientRepository = clientRepository;
        }
        
        public ContractViewModel GetContract(int id)
        {
            return _contractMapper.Map(_contractRepository.Single(p => p.Id == id));
        }

        public ResultAndMessage TryAddContract(ContractViewModel contractViewModel)
        {
            var contract = _contractReverseMapper.Map(contractViewModel);
            var client = _clientRepository.Single(p => p.Id == contractViewModel.ClientId);

            contract.Client = client;

            try
            {
                _contractRepository.Add(contract);

                return _contractRepository.TryToSaveChanges();
            }
            catch (Exception exception)
            {
                return ResultAndMessage.Failed(exception.Message);
            }
        }

        public ResultAndMessage TryModifyContract(ContractViewModel contractViewModel)
        {
            var contract = _contractReverseMapper.Map(contractViewModel);

            try
            {
                _contractRepository.Modify(contract);

                return _contractRepository.TryToSaveChanges();
            }
            catch (Exception exception)
            {
                return ResultAndMessage.Failed(exception.Message);
            }
        }

        public ResultAndMessage TryDeleteContract(int id)
        {
            var contract = _contractRepository.Single(p => p.Id == id);

            try
            {
                _contractRepository.Remove(contract);

                return _contractRepository.TryToSaveChanges();
            }
            catch (Exception exception)
            {
                return ResultAndMessage.Failed(exception.Message);
            }
        }
    }
}