using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Mappers
{
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