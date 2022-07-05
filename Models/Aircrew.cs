using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Aircrew
    {
        public Aircrew()
        {
            Flights = new HashSet<Flight>();
        }

        public short AircrewId { get; set; }
        public short AdmissionGroup { get; set; }
        public short? PilotId { get; set; }
        public short? CopilotId { get; set; }

        public virtual Copilot? Copilot { get; set; }
        public virtual Pilot? Pilot { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
