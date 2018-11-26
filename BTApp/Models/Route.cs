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
        public int? RequestId { get; set; }
        public virtual Request Request { get; set; }
        public ICollection<EmployeeRouteAssign> EmployeeRouteAssigns { get; set; }
    }
    public enum RouteType
    {
        [Display(Name = "Flight")]
        Flight = 0,
        [Display(Name = "Train")]
        Train = 1
    }

    public enum TicketType
    {
        [Display(Name = "Departure")]
        Departure = 0,
        [Display(Name = "Arrival")]
        Arrival = 1,
        [Display(Name = "Transit")]
        Transit = 2
    }
    public enum ClassType
    {
        [Display(Name = "Economy Class")]
        Eco = 0,
        [Display(Name = "Premium Economy Class")]
        PremEco = 1,
        [Display(Name = "Business Class")]
        BC = 2,
        [Display(Name = "First Class")]
        FC = 3,
        [Display(Name = "Coupe")]
        Coupe = 4,
        [Display(Name = "Sit")]
        Sit = 5
    }
}
