using Application.Mappers;
using Application.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITareaService
    {
        List<Tarea> Get();
        Task<bool> Add(Tarea tarea);
        Task Update(Tarea tarea);
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

        public List<Tarea> Get()
        {
            var entity = _tareaRepo.Get();

            List<Tarea> listTarea = new List<Tarea>();
            Tarea tarea = new Tarea();
            foreach (var item in entity)
            {
                tarea.TaskId = item.ID;
                tarea.TaskName = item.TaskName;
                tarea.Description = item.Description;
                tarea.State = item.State;

                listTarea.Add(tarea);
            }
            return listTarea;
        }

        public async Task Update(Tarea tarea)
        {
            _tareaRepo.Update(TareaModelMapper.MapToData(tarea));
        }


    }
}
