using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappers
{
    public static class TareaModelMapper
    {
        public static DataAccess.Entities.Tarea MapToData(Application.Models.Tarea tarea)
        {
            return new DataAccess.Entities.Tarea
            {
                ID = tarea.ID,
                TaskName = tarea.TaskName,
                State = tarea.State,
                Description = tarea.Description
            };
        }

        public static Application.Models.Tarea MapToView(DataAccess.Entities.Tarea tarea)
        {
            return new Application.Models.Tarea
            {
                ID = tarea.ID,
                TaskName = tarea.TaskName,
                State = tarea.State,
                Description = tarea.Description
            };
        }
    }
}

