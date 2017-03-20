using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Mappers
{
    public class ContractMapper : MapperBase, IMapper<Contract, ContractViewModel>
    {
        public ContractViewModel Map(Contract source)
        {
            return new ContractViewModel
            {
                Id = source.Id,
                ClientId = source.ClientId,
                GreyBinCount = source.GreyBinCount.GetValueOrDefault(),
                GreenBinCount = source.GreenBinCount.GetValueOrDefault(),
                BlueBinCount = source.BlueBinCount.GetValueOrDefault(),
                ClientName = source.Client.Name
            };
        }
    }

    public class ContractReverseMapper : MapperBase, IMapper<ContractViewModel, Contract>
    {
        private readonly IRepository<Contract> _contractRepository;
        public ContractReverseMapper (IRepository<Contract> contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public Contract Map(ContractViewModel source)
        {
            var contract = source.Id == default(int) ? _contractRepository.NewObject() : _contractRepository.Single(p => p.Id == source.Id);

            contract.GreyBinCount = source.GreyBinCount;
            contract.GreenBinCount = source.GreyBinCount;
            contract.BlueBinCount = source.GreyBinCount;

            return contract;
        }
    }
}