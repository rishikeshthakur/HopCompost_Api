using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Interfaces
{
    public class BinCollectionReverseMapper : MapperBase, IMapper<BinCollectionViewModel, BinCollection>
    {
        private readonly IRepository<BinCollection> _binCollectionRepository;

        public BinCollectionReverseMapper(IRepository<BinCollection> binCollectionRepository)
        {
            _binCollectionRepository = binCollectionRepository;
        }

        public BinCollection Map(BinCollectionViewModel source)
        {
            var binCollection = source.Id == 0 ? _binCollectionRepository.NewObject() : _binCollectionRepository.Single(p => p.Id == source.Id);
            // to do : map all fields from source to bin collection
            return binCollection;
        }
    }
}