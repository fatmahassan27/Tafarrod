using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tafarrod.BLL.UnitOfWork;
using tafarrod.BLL.ViewModel;

namespace tafarrod.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WorkerController(IUnitOfWork unitOfWork ,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetAll()
        {
            try
            {
                var Worker = await unitOfWork.WorkerRepo.GetAllAsync();
                var WorkerDTO = mapper.Map<IEnumerable<WorkerDTO>>(Worker);
                if (WorkerDTO != null)
                {
                    return Ok(WorkerDTO);
                }
                return NotFound();
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }
        
    }
}
