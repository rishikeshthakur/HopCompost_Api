using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
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
        private readonly IMapper<BinCollection, BinCollectionViewModel> _binCollectionMapper;
        private readonly IMapper<BinCollectionViewModel, BinCollection> _binCollectionReverseMapper;

        public BinService(IRepository<BinCollection> binCollectionRepository, IMapper<BinCollection, BinCollectionViewModel> binCollectionMapper, IMapper<BinCollectionViewModel, BinCollection> binCollectionReverseMapper)
        {
            _binCollectionRepository = binCollectionRepository;
            _binCollectionMapper = binCollectionMapper;
            _binCollectionReverseMapper = binCollectionReverseMapper;
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

        public IEnumerable<BinCollectionViewModel> GetFilteredCollection(int? employeeId, int? clientId, DateTime? selectedDate)
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
    }
}