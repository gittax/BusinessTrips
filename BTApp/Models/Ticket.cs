using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public double Cost { get; set; }
        public RouteType RouteType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Request Request { get; set; }
    }
}
