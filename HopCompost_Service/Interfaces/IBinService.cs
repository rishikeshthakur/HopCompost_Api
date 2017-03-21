using HopCompost_Common.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HopCompost_Common.Enums;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Interfaces
{
    public interface IBinService
    {
        IEnumerable<BinCollectionViewModel> GetBinCollectionByDate(DateTime dateTime);

        IEnumerable<BinCollectionViewModel> GetBinCollectionByStatus(CollectionStatusEnum collectionStatusEnum);
        ResultAndMessage TryAddBinCollection(BinCollectionViewModel binCollectionViewModel);
        ResultAndMessage TryModifyBinCollection(BinCollectionViewModel binCollectionViewModel);
    }
}
