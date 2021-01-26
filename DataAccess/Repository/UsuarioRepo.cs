using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUsuarioRepo
    {
        IEnumerable<Usuario> Get();
        Task<Usuario> Get(int id);
        Task<bool> Add(Usuario usuario);
        void Update(Usuario usuario);
        Task<bool> Delete(int id);
    }
    public class UsuarioRepo: IUsuarioRepo
    {
        private readonly IBdContext _context;

        public UsuarioRepo(IBdContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Usuario usuario)
        {
            try
            {
                await _context.Usuario.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public IEnumerable<Usuario> Get()
        {
            return _context.Usuario;
        }

        public async Task<Usuario> Get(int id)
        {
            try
            {
                var entity = await _context.Usuario.FindAsync(id);
                entity.Password = "*******";
                return entity;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        

        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
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
