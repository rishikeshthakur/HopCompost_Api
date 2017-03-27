using System;
using System.Collections.Generic;
using System.Linq;
using HopCompost_Common.Enums;
using HopCompost_Common.Misc;
using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Services
{
    public class BinService : ServiceBase, IBinService
    {
        private readonly IRepository<BinCollection> _binCollectionRepository;
        private readonly IRepository<BinWeight> _binWeightRepository;
        private readonly IMapper<BinCollection, BinCollectionViewModel> _binCollectionMapper;
        private readonly IMapper<BinCollectionViewModel, BinCollection> _binCollectionReverseMapper;
        private readonly IMapper<BinWeight, BinWeightViewModel> _binWeightMapper;

        public BinService(IRepository<BinCollection> binCollectionRepository, IMapper<BinCollection, BinCollectionViewModel> binCollectionMapper, IMapper<BinCollectionViewModel, BinCollection> binCollectionReverseMapper, IRepository<BinWeight> binWeightRepository, IMapper<BinWeight, BinWeightViewModel> binWeightMapper)
        {
            _binCollectionRepository = binCollectionRepository;
            _binCollectionMapper = binCollectionMapper;
            _binCollectionReverseMapper = binCollectionReverseMapper;
            _binWeightRepository = binWeightRepository;
            _binWeightMapper = binWeightMapper;
        }

        public IEnumerable<BinCollectionViewModel> GetBinCollectionByDate(DateTime dateTime)
        {
            return _binCollectionRepository.Find(p => p.CollectionDate == dateTime).Select(p => _binCollectionMapper.Map(p));
        }

        public IEnumerable<BinCollectionViewModel> GetBinCollectionByEmployee(int employeeId)
        {
            return
                _binCollectionRepository.Find(p => p.EmployeeId == employeeId).Select(p => _binCollectionMapper.Map(p));
        }

        public IEnumerable<BinCollectionViewModel> GetBinCollectionByStatus(CollectionStatusEnum collectionStatusEnum)
        {
            return _binCollectionRepository.Find(p => p.Status == collectionStatusEnum.ToString()).Select(p => _binCollectionMapper.Map(p));
        }

        public ResultAndMessage TryAddBinCollection(BinCollectionViewModel binCollectionViewModel)
        {
            var binCollection = _binCollectionReverseMapper.Map(binCollectionViewModel);

            try
            {
                _binCollectionRepository.Add(binCollection);

                return _binCollectionRepository.TryToSaveChanges();
            }
            catch (Exception exception)
            {
                return ResultAndMessage.Failed(exception.Message);
            }
        }

        public ResultAndMessage TryModifyBinCollection(BinCollectionViewModel binCollectionViewModel)
        {
            var binCollection = _binCollectionReverseMapper.Map(binCollectionViewModel);

            try
            {
                _binCollectionRepository.Modify(binCollection);

                return _binCollectionRepository.TryToSaveChanges();
            }
            catch (Exception exception)
            {
                return ResultAndMessage.Failed(exception.Message);
            }
        }

        public IEnumerable<BinCollectionViewModel> GetPastCollection(int? employeeId, int? clientId, DateTime? selectedDate)
        {
            var result = selectedDate.HasValue
                ? GetBinCollectionByDate(selectedDate.Value)
                : _binCollectionRepository.GetAll().Select(p => _binCollectionMapper.Map(p));

            result = employeeId.HasValue ? result.Where(p => p.EmployeeId == employeeId.Value) : result;
            result = clientId.HasValue ? result.Where(p => p.ClientId == clientId.Value) : result;

            return result;
        }

        public BinCollectionViewModel GetBinCollectionById(int id)
        {
            return _binCollectionMapper.Map(_binCollectionRepository.Single(p => p.Id == id));
        }

        public BinWeightCollectionViewModel GetBinWeightCollection(int id)
        {
            var binCollection = _binCollectionRepository.Single(p => p.Id == id);
            var binWeightViewModels = new List<BinWeightViewModel>();

            if (binCollection.BinWeights.Count == binCollection.GreenBinCount.GetValueOrDefault())
            {
                foreach (var binWeight in binCollection.BinWeights)
                {
                    binWeightViewModels.Add(_binWeightMapper.Map(binWeight));
                }
            }
            else
            {
                for (var i = 1; i <= binCollection.GreenBinCount.GetValueOrDefault(); i++)
                    binWeightViewModels.Add(new BinWeightViewModel {});
            }
                
            var binWeightCollectionViewModel = new BinWeightCollectionViewModel
            {
                BinCollectionId = binCollection.Id,
                ClientId = binCollection.ClientId,
                ClientName = binCollection.Client.Name,
                Processed = binCollection.Status == CollectionStatusEnum.Processed.ToString(),
                BinWeights = binWeightViewModels
            };

            return binWeightCollectionViewModel;
        }

        public ResultAndMessage TryAddBinWeightCollection(BinWeightCollectionViewModel binWeightCollectionViewModel)
        {
            var binCollection =
                _binCollectionRepository.Single(p => p.Id == binWeightCollectionViewModel.BinCollectionId);

            if (binCollection.BinWeights.Count == binCollection.GreenBinCount.GetValueOrDefault())
            {
                foreach (var binWeightViewModel in binWeightCollectionViewModel.BinWeights)
                {
                    _binWeightRepository.Single(p => p.Id == binWeightViewModel.Id).BinWeight1 = binWeightViewModel.Weight;
                }
            }
            else
            {
                foreach (var binWeightViewModel in binWeightCollectionViewModel.BinWeights)
                {
                    var binWeight = _binWeightRepository.NewObject();

                    binWeight.Id = binWeightViewModel.Id;
                    binWeight.BinCollectionId = binCollection.Id;
                    binWeight.BinWeight1 = binWeightViewModel.Weight;

                    binCollection.BinWeights.Add(binWeight);
                }
            }

            if (binWeightCollectionViewModel.Processed)
                binCollection.Status = CollectionStatusEnum.Processed.ToString();

            return _binCollectionRepository.TryToSaveChanges();
        }
    }
}