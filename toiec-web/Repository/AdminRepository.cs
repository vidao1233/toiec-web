using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AdminRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) : base (dbContext) 
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AdminModel> GetAdminByUserId(string userId)
        {
            var Admin = await Entities.FirstOrDefaultAsync(stu => stu.idUser == userId);
            return _mapper.Map<AdminModel>(Admin);
        }
    }
}
