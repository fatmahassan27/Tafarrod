using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tafarrod.BLL.DTOs;
using tafarrod.BLL.UnitOfWork;
using tafarrod.DAL.Entities;

namespace tafarrod.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NationalityController(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NationalityDTO>>> GetNationalities()
        {
            try
            {
                var nationality = await unitOfWork.NationalityRepo.GetAllAsync();
                var nationalityDTO = mapper.Map<IEnumerable<NationalityDTO>>(nationality);
                if (nationalityDTO != null)
                {
                    return Ok(nationalityDTO);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create([FromBody] NationalityDTO nationality)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = mapper.Map<Nationality>(nationality);
                    await unitOfWork.NationalityRepo.CreateAsync(data);
                    await unitOfWork.saveAsync();
                    return Ok("data Created Successfully");
                }
                return BadRequest(nationality);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id , [FromBody] NationalityDTO nationality)
        {
            try
            {
                var existCountry = await unitOfWork.NationalityRepo.GetByIdAsync(id);
                if(existCountry == null)
                {
                    return NotFound();
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                mapper.Map(nationality,existCountry);
               await  unitOfWork.NationalityRepo.UpdateAsync(existCountry);
                await unitOfWork.saveAsync();
                return Ok("Updated successfully");
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existCountry = await unitOfWork.NationalityRepo.GetByIdAsync(id);
                if(existCountry !=null)
                {
                    await unitOfWork.NationalityRepo.DeleteAsync(id);
                    await unitOfWork.saveAsync();
                    return Ok(new { message = "Deleted successfully" });
                }
                return NotFound(new { message = $"Nationality with ID {id} not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }
    }

}
