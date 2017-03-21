using System;
using HopCompost_Common.Enums;

namespace HopCompost_Service.ViewModels
{
    public class BinCollectionViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int? GreenBinCount { get; set; }
        public int? YellowBinCount { get; set; }
        public int? BlueBinCount { get; set; }
        public Nullable<System.TimeSpan> CollectionTime { get; set; }
        public DateTime CollectionDate { get; set; }
        public CollectionStatusEnum Status { get; set; }
    }
}