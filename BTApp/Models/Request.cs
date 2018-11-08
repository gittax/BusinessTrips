using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string RequestNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Declarer { get; set; }
        public string BusinessTripNumber { get; set; }
        public double Budget { get; set; }
        public double Cost { get; set; }
        public EmployeeBase Manager { get; set; }
        public StatusType Status { get; set; }
        public EmployeeBase OfficeManager { get; set; }
        public virtual Project Project { get; set; }
    }
    public enum StatusType
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Created")]
        Created = 1,
        [Display(Name = "Awaits for PM approval")]
        PMapprove = 2,
        [Display(Name = "Pending payment")]
        PayPending = 3,
        [Display(Name = "Payment passed")]
        Paid = 4
    }
}
