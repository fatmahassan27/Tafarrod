using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tafarrod.BLL.DTOs;
using tafarrod.BLL.UnitOfWork;

namespace tafarrod.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WhatsAppController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("{callCenterId}")]
        public async Task<IActionResult> GetWhatsAppNumber(int callCenterId)
        {
            try
            {
                var callCenter = await unitOfWork.CallCenterRepo.GetByIdAsync(callCenterId);
                if(callCenter!=null)
                {
                    var data = mapper.Map<CallCenterDTO>(callCenter);
                    return Ok(new { PhoneApp = data.PhoneApp });

                }
                return NotFound(new {Message = "Call center not found" });

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }
    }
}
