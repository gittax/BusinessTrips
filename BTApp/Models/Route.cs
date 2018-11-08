using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTripsBackend.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public RouteType RouteType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        public TicketType TicketType { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string FlightNumber { get; set; }
        public ClassType ClassType { get; set; }
        public double Budget { get; set; }

        public virtual Request Request { get; set; }
        public ICollection<EmployeeRouteAssign> EmployeeRouteAssigns { get; set; }
    }
    public enum RouteType
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Flight")]
        Flight = 1,
        [Display(Name = "Train")]
        Train = 2
    }

    public enum TicketType
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Departure")]
        Departure = 1,
        [Display(Name = "Arrival")]
        Arrival = 2,
        [Display(Name = "Transit")]
        Transit = 3
    }
    public enum ClassType
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Econom")]
        Eco = 1,
        [Display(Name = "Sit")]
        Sit = 2,
        [Display(Name = "Coupe")]
        Coupe = 3,
        [Display(Name = "CB")]
        CB = 4,
        [Display(Name = "Business class")]
        Business = 5
    }
}
