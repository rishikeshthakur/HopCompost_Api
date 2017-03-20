using System.Collections.Generic;
using HopCompost_Common.Misc;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientViewModel> GetClients();
        ClientViewModel GetClient(int id);
        ResultAndMessage TryAddClient(ClientViewModel clientViewModel);
        ResultAndMessage TryModifyClient(ClientViewModel clientViewModel);
        ResultAndMessage TryDeleteClient(int id);
    }
}