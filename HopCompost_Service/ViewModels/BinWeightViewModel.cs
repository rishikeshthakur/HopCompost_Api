using System.Collections.Generic;

namespace HopCompost_Service.ViewModels
{
    public class BinWeightViewModel
    {
        public int Id { get; set; }
        public double? Weight { get; set; }
    }

    public class BinWeightCollectionViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int BinCollectionId { get; set; }
        public bool Processed { get; set; }
        public IEnumerable<BinWeightViewModel> BinWeights { get; set; }
    }
}