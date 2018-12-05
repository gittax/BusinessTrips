using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public int RouteType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        public int TicketType { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string FlightNumber { get; set; }
        public int ClassType { get; set; }
        public double Budget { get; set; }
        public int? RequestId { get; set; }
        public virtual Request Request { get; set; }
        public ICollection<EmployeeRouteAssign> EmployeeRouteAssigns { get; set; }
    }

    public class LookUpClass
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public int? RouteType { get; set; }
    }
}
