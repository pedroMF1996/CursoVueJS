using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repository { get; }
        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = (await _repository.GetAllProfessorsAsync(true));
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> Get(int ProfessorId)
        {
            try
            {
                var result = (await _repository.GetProfessorByIdAsync(ProfessorId, true));
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/professor/{model.Id}", model);
                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int ProfessorId, Professor model)
        {
            try
            {

                var Professor = await _repository.GetProfessorByIdAsync(ProfessorId, false);

                if(Professor == null)
                {
                    return NotFound();
                }

                 _repository.Update(model);

                if(await _repository.SaveChangesAsync())
                {
                    Professor = await _repository.GetProfessorByIdAsync(ProfessorId, true);
                    return Created($"/api/professor/{model.Id}", Professor);
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int ProfessorId)
        {
            try
            {
                var Professor = await _repository.GetProfessorByIdAsync(ProfessorId, false);

                if(Professor == null) return NotFound();
            
                 _repository.Delete(Professor); 

                if(await _repository.SaveChangesAsync())
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}