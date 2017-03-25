using System;
using System.ComponentModel.DataAnnotations;
using HopCompost_Common.Enums;

namespace HopCompost_Service.ViewModels
{
    public class BinCollectionViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int? GreenBinCount { get; set; }
        public int? GreyBinCount { get; set; }
        public int? BlueBinCount { get; set; }
        public int CollectionDurationInMinutes { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CollectionDate { get; set; }
        public string Status { get; set; }
        public string ClientName { get; set; }
        public string EmployeeName { get; set; }
    }
}