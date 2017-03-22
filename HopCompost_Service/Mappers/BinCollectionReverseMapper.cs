using HopCompost_DataAccess;
using HopCompost_DataAccess.Base;
using HopCompost_Service.Base;
using HopCompost_Service.Interfaces;
using HopCompost_Service.ViewModels;

namespace HopCompost_Service.Mappers
{
    public class BinCollectionReverseMapper : MapperBase, IMapper<BinCollectionViewModel, BinCollection>
    {
        private readonly IRepository<BinCollection> _binCollectionRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Client> _clientRepository;

        public BinCollectionReverseMapper(IRepository<BinCollection> binCollectionRepository, IRepository<Employee> employeeRepository, IRepository<Client> clientRepository)
        {
            _binCollectionRepository = binCollectionRepository;
            _employeeRepository = employeeRepository;
            _clientRepository = clientRepository;
        }

        public BinCollection Map(BinCollectionViewModel source)
        {
            var binCollection = source.Id == 0 ? _binCollectionRepository.NewObject() : _binCollectionRepository.Single(p => p.Id == source.Id);
            var employee = _employeeRepository.Single(p => p.Id == source.EmployeeId);
            var client = _clientRepository.Single(p => p.Id == source.ClientId);

            binCollection.Id = source.Id;
            binCollection.GreenBinCount = source.GreenBinCount;
            binCollection.BlueBinCount = source.BlueBinCount;
            binCollection.GreyBinCount = source.GreyBinCount;
            binCollection.CollectionDate = source.CollectionDate;
            binCollection.CollectionTime = source.CollectionTime;

            binCollection.Employee = employee;
            binCollection.Client = client;

            return binCollection;
        }
    }
}