using Application.Mappers;
using Application.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUsuarioService
    {
        List<Usuario> Get();
        Task<Usuario> Get(int id);
        Task<bool> Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task<bool> Delete(int id);
        Task<bool> Login(string userName, string password);
    }
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepo _usuarioRepo;
        public UsuarioService(IUsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<bool> Add(Usuario usuario)
        {
            return await _usuarioRepo.Add(UsuarioModelMapper.MapToData(usuario));
        }

        public Task<bool> Delete(int id)
        {
            return _usuarioRepo.Delete(id);
        }

        public List<Usuario> Get()
        {
            var entity = _usuarioRepo.Get();

            List<Usuario> listUsuario = new List<Usuario>();
            Usuario usuario = new Usuario();
            foreach (var item in entity)
            {
                usuario.ID = item.ID;
                usuario.UserName = item.UserName;
                usuario.Password = item.Password;
                usuario.Name = item.Name;

                listUsuario.Add(usuario);
            }

            return listUsuario;
        }

        public async Task<Usuario> Get(int id)
        {
            var entity = await _usuarioRepo.Get(id);

            return UsuarioModelMapper.MapToView(entity);
        }

        public async Task<bool> Login(string userName, string password)
        {
            return await _usuarioRepo.Login(userName, password);
        }

        public async Task Update(Usuario usuario)
        {
            _usuarioRepo.Update(UsuarioModelMapper.MapToData(usuario));
        }


    }
}
