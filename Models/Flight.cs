using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Flight
    {
        public Flight()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int FlightId { get; set; }
        public short AircrewId { get; set; }
        public string Destination { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public short AircraftId { get; set; }

        public virtual Aircraft Aircraft { get; set; } = null!;
        public virtual Aircrew Aircrew { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
