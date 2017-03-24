using System;
using HopCompost_Common.Enums;
using HopCompost_DataAccess;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Mappers
{
    public class BinCollectionMapper : MapperBase, IMapper<BinCollection, BinCollectionViewModel>
    {
        public BinCollectionViewModel Map(BinCollection source)
        {
            return new BinCollectionViewModel
            {
                Id = source.Id,
                ClientId = source.ClientId,
                EmployeeId = source.EmployeeId,
                GreenBinCount = source.GreenBinCount,
                GreyBinCount = source.GreyBinCount,
                BlueBinCount = source.BlueBinCount,
                CollectionDurationInMinutes = source.CollectionDurationInMinutes,
                CollectionDate = source.CollectionDate,
                ClientName = source.Client.Name,
                EmployeeName = source.Employee.Name,
                Status = (CollectionStatusEnum) Enum.Parse(typeof(CollectionStatusEnum), source.Status, true)
            };
        }
    }
}