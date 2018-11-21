using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Display(Name = "Project Name")]
        public string Name { get; set; }
        
        public int? ManagerId { get; set; }
        [Display(Name = "Project Manager")]
        public EmployeeBase Manager { get; set; }

        [Display(Name = "Employees")]
        public ICollection<EmployeeBaseProjectAssign> EmployeeProjectAssigns { get; set; }
        public ICollection<Subproject> Subprojects { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
