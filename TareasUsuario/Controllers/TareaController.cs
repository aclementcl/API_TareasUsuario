using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }
        // GET: api/<TareaController>
        [HttpGet]
        public IActionResult GetTaks()
        {
            var entity = _tareaService.Get().Select(p => new { p.TaskName, p.Description, p.State });
            if (entity.Count() > 0)
            {
                return Ok(entity);
            }
            else
            {
                return NotFound("No existen tareas en BD");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TareaViewModel request)
        {
            Tarea tarea = new Tarea
            {
                TaskId = request.TaskId,
                UserId = request.UserId,
                TaskName = request.TaskName,
                State = request.State == true ? "Resuelto" : "No Resuelto",
                Description = request.Description
            };

            bool save = await _tareaService.Add(tarea);

            if (save)
            {
                return Ok("Tarea agregada");
            }
            else
            {
                return NotFound("No se pudo agregar tarea");
            }

        }

        [HttpPut]
        public IActionResult CheckTask([FromBody] TareaViewModel request)
        {
            var tarea = new Tarea
            {
                TaskId = request.TaskId,
                TaskName = request.TaskName,
                Description = request.Description,
                State = request.State == true ? "Resuelto" : "No Resuelto"
            };

            bool result = _tareaService.Update(tarea);

            if (result)
            {
                return Ok("Tarea actualizada");
            }
            else
            {
                return NotFound("La tarea no se pudo actualizar");
            }
        }
    }
}
