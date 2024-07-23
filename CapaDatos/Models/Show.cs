using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CapaDatos.Models
{
    public class Show
    {

        
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string language { get; set; }
        public List<string> genres { get; set; }
        public string Status { get; set; }
        public int? runtime { get; set; }
        public int? averageRuntime { get; set; }
        public DateTime? premiered { get; set; }
        public DateTime? ended { get; set; }
        public string officialsite { get; set; }
        public Schedule schedule { get; set; }
        public Rating rating { get; set; }
        public int weight { get; set; }
        public Network network { get; set; }
        public Externals externals { get; set; }
        public Image image { get; set; }
        public string summary { get; set; }
        public long updated { get; set; }


      
    } 
}
