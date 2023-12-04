using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class TestTypeRepository : Repository<TestType>, ITestTypeRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public TestTypeRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task<bool> AddTestType(TestTypeModel model)
        {
            try
            {
                var type = _mapper.Map<TestType>(model);
                type.idTestType = Guid.NewGuid();
                Entities.Add(type);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTestType(Guid typeId)
        {
            var type = GetById(typeId);
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            Entities.Remove(type);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<TestTypeModel>> GetAllTestTypes()
        {
            var listData = new List<TestTypeModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                var obj = _mapper.Map<TestTypeModel>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<TestTypeModel> GetTestTypeById(Guid typeId)
        {
            IAsyncEnumerable<TestType> types = Entities.AsAsyncEnumerable();
            await foreach (var type in types)
            {
                if (type.idTestType == typeId)
                {
                    TestTypeModel data = _mapper.Map<TestTypeModel>(type);
                    return data;
                }
            }
            return null;
        }

        public async Task<TestTypeModel> GetTestTypeByTypeName(string typeName)
        {
            IAsyncEnumerable<TestType> types = Entities.AsAsyncEnumerable();
            await foreach (var type in types)
            {
                if (type.typeName == typeName)
                {
                    TestTypeModel data = _mapper.Map<TestTypeModel>(type);
                    return data;
                }
            }
            return null;
        }

        public Task<bool> UpdateTestType(TestTypeModel model, Guid typeId)
        {
            try
            {
                var type = _mapper.Map<TestType>(model);
                type.idTestType = typeId;
                Entities.Update(type);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
