using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModel
{
    public class TareaViewModel
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
    }
}
