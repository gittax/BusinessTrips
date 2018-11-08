using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class Subproject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Project Project { get; set; }
    }
}
