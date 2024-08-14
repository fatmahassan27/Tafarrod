using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tafarrod.BLL.UnitOfWork;
using tafarrod.BLL.ViewModel;
using tafarrod.DAL.Entities;
using tafarrod.DAL.Enums;

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
        public async Task<IActionResult> CreateWorker([FromForm] WorkerDTO worker)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var baseUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                    var imagesPath = Path.Combine(baseUploadPath, "Images");
                    var cvsPath = Path.Combine(baseUploadPath, "CVs");
                    if (!Directory.Exists(imagesPath))
                    {
                        Directory.CreateDirectory(imagesPath);

                    }
                    if (!Directory.Exists(cvsPath))
                    {
                        Directory.CreateDirectory(cvsPath);
                    }
                    if (worker.Image !=null)
                    {
                        var imagePath = Path.Combine(imagesPath, Path.GetFileName(worker.Image.FileName));
                        using (var stream = new FileStream(imagePath,FileMode.Create))
                        {
                            await worker.Image.CopyToAsync(stream);
                        }

                    }
                    if(worker.CV !=null)
                    {
                        var cvPath = Path.Combine(cvsPath, Path.GetFileName(worker.CV.FileName));
                        using (var stream = new FileStream(cvPath,FileMode.Create))
                        {
                            await worker.CV.CopyToAsync(stream);
                        }

                    }
                    var Worker = mapper.Map<Worker>(worker);
                    await unitOfWork.WorkerRepo.CreateAsync(Worker);
                    await unitOfWork.saveAsync();
                    return Ok(worker);

                }
                return BadRequest(worker);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred", details = ex.Message });

            }

        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetAll()
        {
            try
            {
                var Worker = await unitOfWork.WorkerRepo.GetAll();
                var WorkerDTO = mapper.Map<IEnumerable<WorkerDTO>>(Worker);
                if (WorkerDTO != null)
                {
                    return Ok(WorkerDTO);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred ", details = ex.Message });

            }
        }

        [HttpGet("ByNationality/{NId:int}")]
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

        [HttpGet("ByOccupation/{OId:int}")]
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

    }
}

