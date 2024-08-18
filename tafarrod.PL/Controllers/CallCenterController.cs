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
    public class CallCenterController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CallCenterController(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([FromBody] CallCenterDTO model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data=mapper.Map<CallCenter>(model);
                    await unitOfWork.CallCenterRepo.CreateAsync(data);
                    await unitOfWork.saveAsync();
                    return Ok();
                }
                return BadRequest(ModelState);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CallCenterDTO>>> GetAll()
        {
            try
            {
                var entity=await unitOfWork.CallCenterRepo.GetAllAsync();
                if(entity!=null)
                {
                    var callCenterDTO = mapper.Map<IEnumerable<CallCenterDTO>>(entity);
                    return Ok(callCenterDTO);
                }
                return NotFound();

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }
        [HttpPut("{id :int}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Edit(int id,[FromBody] CallCenterDTO callCenter)
        {
            try
            {
                var existCallCenter = await unitOfWork.CallCenterRepo.GetByIdAsync(id);

                // If the CallCenter is not found, return a NotFound response
                if (existCallCenter == null)
                {
                    return NotFound(new { message = $"CallCenter with ID {id} not found" });
                }

                // If the model state is not valid, return a BadRequest with validation errors
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Map the DTO to the existing entity (update the existing entity with new values)
                mapper.Map(callCenter, existCallCenter);

                // Update the entity in the database
                await unitOfWork.CallCenterRepo.UpdateAsync(existCallCenter);

                // Save changes to the database
                await unitOfWork.saveAsync();

                // Return a success message
                return Ok("Updated successfully");

                //var existCallCenter = await unitOfWork.CallCenterRepo.GetByIdAsync(id);
                //if (existCallCenter == null)
                //{
                //    return NotFound(new { message = $"CallCenter with ID {id} not found" });
                //}
                //else if (existCallCenter !=null)
                //{
                //    if (ModelState.IsValid)
                //    {
                //        var entity = mapper.Map<CallCenter>(callCenter);
                //        await unitOfWork.CallCenterRepo.UpdateAsync(entity);
                //        await unitOfWork.saveAsync();
                //        return Ok("Updated successfully");
                //    }
                //    BadRequest(ModelState);
                //}
                //return NotFound(new { message = $"CallCenter with ID {id} not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var exsit = await unitOfWork.CallCenterRepo.GetByIdAsync(id);
                if(exsit !=null)
                {
                    await unitOfWork.CallCenterRepo.DeleteAsync(id);
                    await unitOfWork.saveAsync();
                    return Ok("Deleted Successfully");
                }
                return NotFound();

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }
        }
    }

}
