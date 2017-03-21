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
                //to do map all the fields from source to bin collection view model
            };
        }
    }
}