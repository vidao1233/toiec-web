using toiec_web.Models;

namespace toiec_web.Repository.IRepository
{
    public interface IVipPackageRepository
    {
        Task<IEnumerable<VipPackageModel>> GetAllVipPackages();
        Task<VipPackageModel> GetVipPackageById(Guid idPackage);
        Task<bool> AddVipPackage(VipPackageModel model, string userId);
        Task<bool> UpdateVipPackage(VipPackageModel model, Guid idPackage, string userId);
        Task<bool> DeleteVipPackage(Guid idPackage);
    }
}
