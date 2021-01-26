﻿using System;
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
        public IActionResult Get()
        {
            var entity = _tareaService.Get().Select(p => new { p.TaskName, p.Description, p.State });
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TareaViewModel request)
        {
            Tarea tarea = new Tarea
            {
                TaskId = request.TaskId,
                UserId = request.UserId,
                TaskName = request.TaskName,
                State = request.State,
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

        // PUT api/<TareaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
