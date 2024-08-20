using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using tafarrod.BLL.UnitOfWork;
using tafarrod.BLL.ViewModel;
using tafarrod.DAL.Entities;
using tafarrod.DAL.Enums;
using System.IO;
using System;

namespace tafarrod.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WorkerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetAll([FromQuery] string filterType = null, [FromQuery] string filterValue = null)
        //{
        //    try
        //    {
        //        IEnumerable<Worker> workers = filterType switch
        //        {
        //            "Nationality" => await unitOfWork.WorkerRepo.GetByNationalityId(int.Parse(filterValue)),
        //            "Occupation" => await unitOfWork.WorkerRepo.GetByOccupationId(int.Parse(filterValue)),
        //            "Age" => await unitOfWork.WorkerRepo.GetByAge(int.Parse(filterValue)),
        //            "Religion" => await unitOfWork.WorkerRepo.GetByReligion(Enum.Parse<Religion>(filterValue)),
        //            "Experience" => await unitOfWork.WorkerRepo.GetByExperience(Enum.Parse<PracticalExperience>(filterValue)),
        //            _ => await unitOfWork.WorkerRepo.GetAll()
        //        };

        //        var workerDTOs = mapper.Map<IEnumerable<WorkerDTO>>(workers);
        //        if (workerDTOs.Any())
        //        {
        //            return Ok(workerDTOs);
        //        }

        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CreateWorker([FromBody] WorkerDTO workerDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    //string imageBase64 = await FileConverter.ConvertToBase64Async(workerDTO.Image);
                    //string cvBase64 = await FileConverter.ConvertToBase64Async(workerDTO.CV);

                    string imagePath = SaveFile(workerDTO.Image, "Images");
                    string cvPath = SaveFile(workerDTO.CV, "CVs");
                    // Set the Base64 strings in the entity

                    var worker = mapper.Map<Worker>(workerDTO);
                    worker.Image = imagePath;
                    worker.CV = cvPath;


                    await unitOfWork.WorkerRepo.CreateAsync(worker);
                    await unitOfWork.saveAsync();
                    return Ok(worker);

                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetAllWorkers()
        {
            try
            {
                var workers = await unitOfWork.WorkerRepo.GetAll();

                if (workers == null || !workers.Any())
                {
                    return NotFound(new { message = "No workers found" });
                }

                var workerDto = mapper.Map<IEnumerable<WorkerDTO>>(workers);
                return Ok(workerDto);

               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }

        [HttpGet("ByNationality/{NId}")]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetByNationalityId(int NId)
        {
            try
            {
                var worker = await unitOfWork.WorkerRepo.GetByNationalityId(NId);
                var workerDTO = mapper.Map<IEnumerable<WorkerDTO>>(worker);
                if (workerDTO != null)
                {
                    return Ok(workerDTO);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }

        [HttpGet("ByOccupation/{OId}")]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetByOccupationId(int OId)
        {
            try
            {
                var worker = await unitOfWork.WorkerRepo.GetByOccupationId(OId);
                var workerDTO = mapper.Map<IEnumerable<WorkerDTO>>(worker);
                if (workerDTO != null)
                {
                    return Ok(workerDTO);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }

        [HttpGet("{age:int}")]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetByAge(int age)
        {
            try
            {
                var worker = await unitOfWork.WorkerRepo.GetByAge(age);
                var workerDTO = mapper.Map<IEnumerable<WorkerDTO>>(worker);
                if (workerDTO != null)
                {
                    return Ok(workerDTO);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }

        [HttpGet("by-religion")]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetByReligion([FromQuery] string religion)
        {
            try
            {
                if (Enum.TryParse(religion, true, out Religion parsedReligion))
                {
                    var workers = await unitOfWork.WorkerRepo.GetByReligion(parsedReligion);
                    var workerDTO = mapper.Map<IEnumerable<WorkerDTO>>(workers);
                    if (workerDTO.Any())
                    {
                        return Ok(workerDTO);
                    }
                    return NotFound();

                }

                return BadRequest("Invalid religion value");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }



        [HttpGet("by-practicalExperience")]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetByExperience([FromQuery] string practicalExperience)
        {
            try
            {
                if (Enum.TryParse(practicalExperience, true, out PracticalExperience experience))
                {
                    var workers = await unitOfWork.WorkerRepo.GetByExperience(experience);
                    var workerDTO = mapper.Map<IEnumerable<WorkerDTO>>(workers);
                    if (workerDTO.Any())
                    {
                        return Ok(workerDTO);
                    }
                    return NotFound();

                }
                return BadRequest("Invalid practicalExperience value");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var workerExist = await unitOfWork.WorkerRepo.GetByIdAsync(id);
                if(workerExist!=null)
                {
                    await unitOfWork.WorkerRepo.DeleteAsync(id);
                    await unitOfWork.saveAsync();
                    return Ok(new {Message="Worker Deleted Successfully"});
                }
                return NotFound();
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }


        private string SaveFile(string base64String, string folderName)
        {
            if (string.IsNullOrEmpty(base64String))
                return null;
            byte[] fileBytes = Convert.FromBase64String(base64String);
            // Define the file paths

            var baseUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            var folderPath = Path.Combine(baseUploadPath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName = Guid.NewGuid().ToString() + ".png"; // or the appropriate file extension

            var filePath = Path.Combine(folderPath, fileName);
            try
            {
            // Save the bytes to the file
              System.IO.File.WriteAllBytes(filePath, fileBytes);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error writing file: {ex.Message}", ex);
            }

            return filePath;
        }


        private async Task<string> ConvertToBase64Async(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();
                return Convert.ToBase64String(fileBytes);
            }
        }

    }
}

