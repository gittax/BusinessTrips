using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class EmployeeBaseProjectAssign
    {
        public int EmployeeBaseId { get; set; }
        public int ProjectId { get; set; }
        public EmployeeBase EmployeeBase { get; set; }
        public Project Project { get; set; }
    }
}
