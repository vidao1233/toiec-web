using toiec_web.Models;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;

namespace toiec_web.Services
{
    public class VipStudentService : IVipStudentService
    {
        private readonly IVipStudentRepository _vipStudentRepository;

        public VipStudentService(IVipStudentRepository VipStudentRepository) 
        {
            _vipStudentRepository = VipStudentRepository;
        }
        public async Task<bool> AddVipStudent(string studentId, int duration)
        {
            var VipStudent = new VipStudentModel
            {
                idVipStudent = Guid.NewGuid(),
                idStudent = Guid.Parse(studentId),
            };
            return await _vipStudentRepository.AddVipStudent(VipStudent, duration);
        }
        public async Task<bool> UpdateVipStudent(VipStudentModel model, int duration)
        {
            return await _vipStudentRepository.UpdateVipStudent(model, duration);
        }
        public async Task<VipStudentModel> GetVipStudentByStudentId(string studentId)
        {
            return await _vipStudentRepository.GetVipStudentByStudentId(studentId);
        }
    }
}
