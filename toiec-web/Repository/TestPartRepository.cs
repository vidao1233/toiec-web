using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Data;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class TestPartRepository : Repository<TestPart>, ITestPartRepository
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public TestPartRepository(ToiecDbContext dbContext, IMapper mapper, IUnitOfWork uow) : base(dbContext)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<TestPartModel>> GetAllTestParts()
        {
            try
            {
                var data = await Entities.ToListAsync();

                var listData = new List<TestPartModel>();
                
                foreach (var item in data)
                {
                    var obj = _mapper.Map<TestPartModel>(item);
                    listData.Add(obj);
                }
                return listData;
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message );
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid> GetPartByUnit(Guid partId)
        {
            var part = await Entities.FirstOrDefaultAsync(u => u.partId == partId);
            if (part != null)
            {
                var data = _mapper.Map<TestPartModel>(part);
                return data.partId;
            }

            return Guid.Empty;
        }
    }
}
