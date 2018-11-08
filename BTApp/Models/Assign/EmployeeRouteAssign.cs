using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class EmployeeRouteAssign
    {
        public int EmployeeID { get; set; }
        public int RouteID { get; set; }
        public Employee Employee { get; set; }
        public Route Route { get; set; }
    }
}
