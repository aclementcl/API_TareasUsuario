using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class Tarea
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
    }
}
