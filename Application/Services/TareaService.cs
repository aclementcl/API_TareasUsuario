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
        private readonly ITareaRepo _tareaRepo;
        public TareaService(ITareaRepo tareaRepo)
        {
            _tareaRepo = tareaRepo;
        }

        public async Task<bool> Add(Tarea tarea)
        {
            int tareaId = await _tareaRepo.Add(TareaModelMapper.MapToData(tarea));

            //Agrega relación entre las tablas Tarea y Usuario
            bool result = false;

            if (tareaId > 0)
            {
                result = await _tareaRepo.AddRelationTaskUser(tareaId, tarea.UserId);
            }
            return result;

        }

        public Task<bool> Delete(int id)
        {
            return _tareaRepo.Delete(id);
        }

        public List<Tarea> Get()
        {
            var entity = _tareaRepo.Get();

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
            var entity = await _tareaRepo.Get(id);

            return null;//UsuarioModelMapper.MapToView(entity);
        }

        public async Task Update(Tarea tarea)
        {
            //_usuarioRepo.Update(UsuarioModelMapper.MapToData(tarea));
        }


    }
}
