using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Usuario
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
