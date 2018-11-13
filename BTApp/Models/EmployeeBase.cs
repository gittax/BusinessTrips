using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class EmployeeBase
    {
        public int EmployeeBaseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual Employee Employee { get; set; }
        public ICollection<EmployeeBaseProjectAssign> EmployeeProjectAssigns { get; set; }
    }
}
