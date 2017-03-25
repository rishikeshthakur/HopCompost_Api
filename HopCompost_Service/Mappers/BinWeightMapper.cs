using HopCompost_DataAccess;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;
using System;

namespace HopCompost_Service.Mappers
{
    public class BinWeightMapper : MapperBase, IMapper<BinWeight, BinWeightViewModel>
    {
        public BinWeightViewModel Map(BinWeight source)
        {
            return new BinWeightViewModel
            {
                Id = source.Id,
                Weight = Convert.ToDecimal(source.BinWeight1)
            };
        }
    }
}