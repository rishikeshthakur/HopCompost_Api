using HopCompost_DataAccess;
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
}