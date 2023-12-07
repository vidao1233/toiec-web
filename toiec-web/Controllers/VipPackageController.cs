using Microsoft.AspNetCore.Mvc;
using toiec_web.Services.IService;
using toiec_web.ViewModels.VipPackage;

namespace toiec_web.Controllers
{
    public class VipPackageController : BaseAPIController
    {
        private readonly IVipPackageService _vipPackageService;

        public VipPackageController(IVipPackageService vipPackageService) 
        {
            _vipPackageService = vipPackageService;
        }

        [HttpGet]
        [Route("GetAllVipPackages")]
        public async Task<IActionResult> GetAllVipPackages()
        {
            var listpackage = await _vipPackageService.GetAllVipPackages();
            if (listpackage == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(listpackage);
        }

    }
}
