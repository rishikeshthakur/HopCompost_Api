using System.Collections.Generic;

namespace HopCompost_Service.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }

        public IEnumerable<ContractViewModel> Contracts { get; set; }
    }
}