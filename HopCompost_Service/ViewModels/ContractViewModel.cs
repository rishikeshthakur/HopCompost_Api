namespace HopCompost_Service.ViewModels
{
    public class ContractViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int GreenBinCount { get; set; }
        public int GreyBinCount { get; set; }
        public int BlueBinCount { get; set; }
        public string ClientName { get; set; }
    }
}