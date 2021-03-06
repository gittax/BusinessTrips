﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public DocType DocType { get; set; }
        public string DocNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidThrough { get; set; }

        public GenderType Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public int EmployeeBaseId { get; set; }
        public virtual EmployeeBase EmployeeBase { get; set; }

        public int? RequestId { get; set; }
        public Request Request { get; set; }

        public virtual Ticket Ticket { get; set; }

        public ICollection<EmployeeRouteAssign> EmployeeRouteAssigns { get; set; }
        public ICollection<EmployeeBaseProjectAssign> EmployeeProjectAssigns { get; set; }
    }
    public enum GenderType
    {
        [Display(Name = "Мale")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1
    }

    public enum DocType
    {
        [Display(Name = "Passport RF")]
        Passport = 0,
        [Display(Name = "International Passport")]
        InterPassport = 1
    }
}
