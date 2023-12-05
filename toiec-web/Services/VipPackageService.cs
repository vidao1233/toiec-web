using AutoMapper;
using toiec_web.Models;
using toiec_web.Repository;
using toiec_web.Repository.IRepository;
using toiec_web.Services.IService;
using toiec_web.ViewModels.VipPackage;
using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Services
{
    public class VipPackageService : IVipPackageService
    {
        private readonly IVipPackageRepository _vipPackageRepository;
        private readonly IMapper _mapper;

        public VipPackageService(IVipPackageRepository vipPackageRepository, IMapper mapper)
        {
            _vipPackageRepository = vipPackageRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddVipPackage(VipPackageAddModel model, string userId)
        {
            var data = _mapper.Map<VipPackageModel>(model);
            return await _vipPackageRepository.AddVipPackage(data, userId);
        }

        public async Task<bool> DeleteVipPackage(Guid packageId)
        {
            return await _vipPackageRepository.DeleteVipPackage(packageId);
        }

        public async Task<IEnumerable<VipPackageViewModel>> GetAllVipPackages()
        {
            var data = await _vipPackageRepository.GetAllVipPackages();
            List<VipPackageViewModel> listData = new List<VipPackageViewModel>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    var obj = _mapper.Map<VipPackageViewModel>(item);
                    listData.Add(obj);
                }
                return listData;
            }
            return null;
        }

        public async Task<VipPackageViewModel> GetVipPackageById(Guid packageId)
        {
            var data = await _vipPackageRepository.GetVipPackageById(packageId);
            if (data != null)
            {
                var obj = _mapper.Map<VipPackageViewModel>(data);
                return obj;
            }
            return null;
        }

        public async Task<bool> UpdateVipPackage(VipPackageUpdateModel model, Guid packageId, string userId)
        {
            var data = _mapper.Map<VipPackageModel>(model);
            return await _vipPackageRepository.UpdateVipPackage(data, packageId, userId);
        }
    }
}
