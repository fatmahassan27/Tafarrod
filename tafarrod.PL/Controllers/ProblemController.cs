using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using tafarrod.BLL.DTOs;
using tafarrod.BLL.UnitOfWork;
using tafarrod.DAL.Entities;

namespace tafarrod.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProblemController(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> createProblem([FromBody] ProblemDTO problem)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = mapper.Map<Problem>(problem);
                    await unitOfWork.ProblemRepo.CreateAsync(data);
                    await unitOfWork.saveAsync();
                    return Ok("data add Successfully");
                }
                return BadRequest(problem);
            }catch(Exception ex)
            {
                Console.Error.WriteLine("Error creating object: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
