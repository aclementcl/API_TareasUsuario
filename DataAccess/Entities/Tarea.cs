using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Tarea
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
    }
}
