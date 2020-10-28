using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWebAPI.Models
{
    public class Project
    {
        public int id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectImage { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
    }
}
