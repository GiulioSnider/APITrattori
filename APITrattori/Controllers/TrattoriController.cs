using APITrattori.Models;
using APITrattori.Services.Worker.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITrattori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrattoriController : ControllerBase
    {
        private readonly ITrattoriWorkerService _trattoriWorkerService;

        public TrattoriController(ITrattoriWorkerService trattoriWorkerService)
        {
            _trattoriWorkerService = trattoriWorkerService;
        }

        [HttpPost]
        public IActionResult PostTrattore([FromBody] PostTrattore postTrattoreModel)
        {
            Trattore addedTrattore = _trattoriWorkerService.Post(postTrattoreModel);
            return CreatedAtAction(nameof(GetDetail), new { idTrattore = addedTrattore.TrattoreId }, addedTrattore);
        }

        [HttpGet("{idTrattore}")]
        public IActionResult GetDetail(int idTrattore)
        {
            try
            {
                Trattore foundTrattore = _trattoriWorkerService.GetById(idTrattore);
                return Ok(foundTrattore);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{color}")]
        public IActionResult GetAllByFilter(Colore colore)
        {
            try
            {
                List<Trattore> trattoriByColors = _trattoriWorkerService.GetAllByColors(colore);
                return Ok(trattoriByColors);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{idTrattore}")]
        public IActionResult PutTrattore([FromBody] PostTrattore postTrattoreModel, int idTrattore)
        {
            Trattore resultTrattore = _trattoriWorkerService.Put(postTrattoreModel, idTrattore);
            if (resultTrattore == null)
            {
                return NoContent();
            }
            return CreatedAtAction(nameof(GetDetail), new { idTrattore = resultTrattore.TrattoreId }, resultTrattore);
        }

        [HttpDelete("{idTrattore")]
        public IActionResult DeleteTrattore(int idTrattore)
        {
            try
            {
                _trattoriWorkerService.DeleteById(idTrattore);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
