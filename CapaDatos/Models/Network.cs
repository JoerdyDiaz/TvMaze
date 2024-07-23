using CapaDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models
{
    public class Network
    {
        public int id { get; set; }
        public string name { get; set; }
        public country Country { get; set; }
        public string officialsite { get; set; }
    }
}
