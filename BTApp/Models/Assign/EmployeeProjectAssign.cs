using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class EmployeeProjectAssign
    {
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }
        public EmployeeBase EmployeeBase { get; set; }
        public Project Project { get; set; }
    }
}
