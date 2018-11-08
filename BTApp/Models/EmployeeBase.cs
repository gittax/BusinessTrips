using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTripsBackend.Models
{
    public class EmployeeBase
    {
        public int EmployeeBaseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeProjectAssign> EmployeeProjectAssigns { get; set; }
    }
}
