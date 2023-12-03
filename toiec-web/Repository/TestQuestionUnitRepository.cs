using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class TestQuestionUnitRepository : Repository<TestQuestionUnit>, ITestQuestionUnitRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public TestQuestionUnitRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) 
            : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task<bool> AddTestQuestionUnit(TestQuestionUnitModel model)
        {
            try
            {
                var unit = _mapper.Map<TestQuestionUnit>(model);
                unit.idTest = Guid.NewGuid();
                Entities.Add(unit);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTestQuestionUnit(Guid unitId)
        {
            var unit = GetById(unitId);
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            Entities.Remove(unit);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<TestQuestionUnitModel>> GetAllTestQuestionUnitByPart(int partId)
        {
            var listData = new List<TestQuestionUnitModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                if (item.idTestPart == partId)
                {
                    var obj = _mapper.Map<TestQuestionUnitModel>(item);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<IEnumerable<TestQuestionUnitModel>> GetAllTestQuestionUnitByTest(Guid testId)
        {
            var listData = new List<TestQuestionUnitModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                if (item.idTest == testId)
                {
                    var obj = _mapper.Map<TestQuestionUnitModel>(item);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<IEnumerable<TestQuestionUnitModel>> GetAllTestQuestionUnits()
        {
            var listData = new List<TestQuestionUnitModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                var obj = _mapper.Map<TestQuestionUnitModel>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<TestQuestionUnitModel> GetTestQuestionUnitById(Guid unitId)
        {
            IAsyncEnumerable<TestQuestionUnit> units = Entities.AsAsyncEnumerable();
            await foreach (var unit in units)
            {
                if (unit.idQuestionUnit == unitId)
                {
                    TestQuestionUnitModel data = _mapper.Map<TestQuestionUnitModel>(unit);
                    return data;
                }
            }
            return null;
        }

        public Task<bool> UpdateTestQuestionUnit(TestQuestionUnitModel model, Guid unitId)
        {
            try
            {
                var unit = _mapper.Map<TestQuestionUnit>(model);
                unit.idQuestionUnit = unitId;
                Entities.Update(unit);
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
