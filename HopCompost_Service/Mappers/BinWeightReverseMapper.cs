using System;
using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Mappers
{
    public class BinWeightReverseMapper : MapperBase, IMapper<BinWeightViewModel, BinWeight>
    {
        private readonly IRepository<BinWeight> _binWeightRepository;

        public BinWeightReverseMapper(IRepository<BinWeight> binWeightRepository)
        {
            _binWeightRepository = binWeightRepository;
        }

        public BinWeight Map(BinWeightViewModel source)
        {
            var binWeight = source.Id == 0
                ? _binWeightRepository.NewObject()
                : _binWeightRepository.Single(p => p.Id == source.Id);
            
            binWeight.BinWeight1 = Convert.ToInt32(source.Weight); //ToDo: Update this once the database is updated.

            return binWeight;
        }
    }
}