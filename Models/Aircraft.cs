using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Aircraft
    {
        public Aircraft()
        {
            Flights = new HashSet<Flight>();
        }

        public short AircraftId { get; set; }
        public string ModelName { get; set; } = null!;

        public virtual Model ModelNameNavigation { get; set; } = null!;
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
