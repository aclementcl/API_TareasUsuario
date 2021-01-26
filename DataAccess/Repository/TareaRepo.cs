using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ITareaRepo
    {
        IEnumerable<Tarea> Get();
        Task<Tarea> Get(int id);
        Task<int> Add(Tarea usuario);
        Task<bool> AddRelationTaskUser(int taskId, int userId);
        void Update(Tarea usuario);
        Task<bool> Delete(int id);
    }
    public class TareaRepo : ITareaRepo
    {
        private readonly IBdContext _context;

        public TareaRepo(IBdContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Tarea tarea)
        {
            try
            {
                await _context.Tarea.AddAsync(tarea);
                await _context.SaveChangesAsync();
                int tareaId = tarea.ID;
                return tareaId;
            }
            catch(Exception e)
            {
                return 0;
            }
            
        }

        public async Task<bool> AddRelationTaskUser(int taskId, int userId)
        {
            try
            {
                TareaUsuario tareaUsuario = new TareaUsuario();
                tareaUsuario.ID_Task = taskId;
                tareaUsuario.ID_User = userId;

                await _context.TareaUsuario.AddAsync(tareaUsuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Tarea> Get()
        {
            return null;// _context.Usuario;
        }

        public async Task<Tarea> Get(int id)
        {
            return null;
        }
        

        public void Update(Tarea tarea)
        {
            _context.Tarea.Update(tarea);
            _context.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                //var entity = await _context.Usuario.FindAsync(id);
                var entity = Get(id);
                //_context.Usuario.Remove(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
