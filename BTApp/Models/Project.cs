using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTripsBackend.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Display(Name = "Project Manager")]
        public EmployeeBase Manager { get; set; }

        [Display(Name = "Employees")]
        public ICollection<EmployeeProjectAssign> EmployeeProjectAssigns { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<Subproject> Subprojects { get; set; }
    }
}
