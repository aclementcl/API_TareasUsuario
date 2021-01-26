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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            var entity =  _usuarioService.Get();
            return Ok(entity);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _usuarioService.Get(id);
            return Ok(entity);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioViewModel request)
        {
            Usuario usuario = new Usuario
            {
                ID= request.ID,
                UserName = request.UserName,
                Password = request.Password,
                Name = request.Name
            };

            bool guardado = await _usuarioService.Add(usuario);

            if (guardado)
            {
                return Ok("Guardado exitoso");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        public void Put([FromBody] UsuarioViewModel request)
        {
            var usuario = new Usuario
            {
                ID = request.ID,
                UserName = request.UserName,
                Password = request.Password,
                Name = request.Name
            };

            _usuarioService.Update(usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usuarioService.Delete(id);
        }
    }
}
