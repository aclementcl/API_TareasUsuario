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
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var entity =  _usuarioService.Get();
        //    if (entity.Count() > 0)
        //    {
        //        return Ok(entity);
        //    }
        //    else
        //    {
        //        return NotFound("No existen usuarios en BD");
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var entity = await _usuarioService.Get(id);
        //    return Ok(entity);
        //}

        [HttpPost("{userName}/{password}")]
        public async Task<string> Login(string userName, string password)
        {
            bool validCredentials = await _usuarioService.Login(userName, password);
            string message;
            if (validCredentials)
            {
                message = "Usuario autentificado correctamente";
            }
            else
            {
                message = "El nombre de usuario o la contraseña es incorrecta";
            }
            return message;

        }

        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] UsuarioViewModel request)
        {
            Usuario usuario = new Usuario
            {
                ID= request.ID,
                UserName = request.UserName,
                Password = request.Password,
                Name = request.Name
            };

            bool save = await _usuarioService.Add(usuario);

            if (save)
            {
                return Ok("Usuario creado");
            }
            else
            {
                return NotFound("No se pudo crear el usuario");
            }
        }
    }
}
