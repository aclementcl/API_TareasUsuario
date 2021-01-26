using Application.Mappers;
using Application.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITareaService
    {
        List<Tarea> Get();
        Task<Tarea> Get(int id);
        Task<bool> Add(Tarea tarea);
        Task Update(Tarea tarea);
        Task<bool> Delete(int id);
    }
    public class TareaService: ITareaService
    {
        private readonly IUsuarioRepo _usuarioRepo;
        public TareaService(IUsuarioRepo modelItemRepository)
        {
            _usuarioRepo = modelItemRepository;
        }

        public async Task<bool> Add(Tarea tarea)
        {
            return true;//await _usuarioRepo.Add(TareaModelMapper.MapToData(tarea));
        }

        public Task<bool> Delete(int id)
        {
            return _usuarioRepo.Delete(id);
        }

        public List<Tarea> Get()
        {
            var entity = _usuarioRepo.Get();

            //List<Usuario> listUsuario = new List<Usuario>();
            //Usuario usuario = new Usuario();
            //foreach (var item in entity)
            //{
            //    usuario.ID = item.ID;
            //    usuario.UserName = item.UserName;
            //    usuario.Password = item.Password;
            //    usuario.Name = item.Name;

            //    listUsuario.Add(usuario);
            //}

            return null;// listUsuario;
        }

        public async Task<Tarea> Get(int id)
        {
            var entity = await _usuarioRepo.Get(id);

            return null;//UsuarioModelMapper.MapToView(entity);
        }

        public async Task Update(Tarea tarea)
        {
            //_usuarioRepo.Update(UsuarioModelMapper.MapToData(tarea));
        }


    }
}
