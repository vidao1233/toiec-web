using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using toiec_web.Models;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Payment;

namespace toiec_web.Controllers
{
    public class PaymentController : BaseAPIController
    {
        private readonly ToiecDbContext _dbContext;
        private readonly IPaymentService _paymentService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IVipStudentService _vipStudentService;
        private readonly IVipPackageService _vipPackageService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IPaymentMethodService paymentMethodService
            , IMapper mapper, IVipPackageService vipPackageService, UserManager<IdentityUser> userManager
            , IVipStudentService vipStudentService, ToiecDbContext dbContext, IStudentService studentService)
        {
            _paymentService = paymentService;
            _paymentMethodService = paymentMethodService;
            _vipStudentService = vipStudentService;
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
            _vipPackageService = vipPackageService;
            _studentService = studentService;
        }
        [HttpPost]
        [Route("CreateMoMoPayment")]
        public async Task<IActionResult> CreateMoMoPayment(PaymentInfoModel model)
        {
            var student = await _studentService.GetStudentByUserId(model.UserId.ToString());
            var vipPackage = await _vipPackageService.GetVipPackageById(model.IdPackage.ToString());
            if(student == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                        new Response { Status = "Error", Message = "UserId of student invalid" });
            if (vipPackage == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                        new Response { Status = "Error", Message = "Vip package invalid" });
            var response = await _paymentService.CreatePaymentAsync(student.idStudent, vipPackage.idPackage, vipPackage.price);
            return Ok(new { PayUrl = response.PayUrl });
        }

        [HttpGet]
        [Route("MomoPaymentCallBack")]
        public async Task<IActionResult> MomoPaymentCallBack()
        {
            Guid paymentMethodId = Guid.Empty;
            var listData = await _paymentMethodService.GetAllPaymentMethods();
            if(listData != null)
            {
                foreach (var paymentMethod in listData)
                {
                    if (paymentMethod.name.Equals("MOMO"))
                    {
                        paymentMethodId = paymentMethod.idMethod;
                        Console.WriteLine(paymentMethod.idMethod);
                    }
                }
                if (paymentMethodId.Equals(Guid.Empty))
                {
                    paymentMethodId = new Guid();
                    var method = new PaymentMethodModel
                    {
                        idMethod = paymentMethodId,
                        name = "MOMO"
                    };
                    await _paymentMethodService.AddPaymentMethod(method);
                }
            }    
            else
            {
                paymentMethodId = new Guid();
                var method = new PaymentMethodModel
                {
                    idMethod = paymentMethodId,
                    name = "MOMO"
                };
                await _paymentMethodService.AddPaymentMethod(method);
            }
            
            var response = await _paymentService.MoMoPaymentExecuteAsync(HttpContext.Request.Query, paymentMethodId);
            if (response != null)
            {
                var user = await _userManager.FindByIdAsync(response.UserId);
                await _userManager.AddToRoleAsync(user, "VipStudent");
                var vipPackage = await _vipPackageService.GetVipPackageById(response.PaymentInfo);
                var vipStudent = await _vipStudentService.GetVipStudentByStudentId(response.StudentId);
                if (vipStudent != null)
                {
                    await _vipStudentService.UpdateVipStudent(vipStudent, vipPackage.duration);

                }
                else
                    await _vipStudentService.AddVipStudent(response.StudentId, vipPackage.duration);
                return Redirect("http://localhost:3000/vippackage-checkout/success");
            }
            return Redirect("http://localhost:3000/vippackage-checkout/fail");
        }
        [HttpGet]
        [Route("GetAllPaymentsOrderByDate")]
        public async Task<IActionResult> GetAllPaymentsOrderByDate()
        {
            var data = await _paymentService.GetAllPayment();
            if(data != null)
            {
                return Ok(data);
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "Internal Server Error" });
        }

        [HttpGet]
        [Route("GetAllPaymentsByUserIdOrderByDate/{userId}")]
        public async Task<IActionResult> GetAllPaymentsByUserIdOrderByDate(string userId)
        {
            var data = await _paymentService.GetAllPaymentByUserId(userId);
            if (data != null)
            {
                return Ok(data);
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "Internal Server Error" });
        }

        [HttpGet]
        [Route("GetExpireTimeVipStudent/{userId}")]
        public async Task<IActionResult> GetExpireTimeVipStudent(string userId)
        {
            var data = await _paymentService.GetExpireTimeVipStudent(userId);
            if (data != null)
            {
                return Ok(new {vipExpire = data});
            }
            return Ok(null);
        }
    }
}
