using HopCompost_Common.Misc;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Interfaces
{
    public interface IContractService
    {
        ContractViewModel GetContract(int id);
        ResultAndMessage TryAddContract(ContractViewModel contractViewModel);
        ResultAndMessage TryModifyContract(ContractViewModel contractViewModel);
        ResultAndMessage TryDeleteContract(int id);
    }
}