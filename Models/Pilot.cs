using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Pilot
    {
        public Pilot()
        {
            Aircrews = new HashSet<Aircrew>();
        }

        public short PilotId { get; set; }
        public string FullName { get; set; } = null!;
        public byte AdmissionGroup { get; set; }
        public short NumberOfFlights { get; set; }

        public virtual ICollection<Aircrew> Aircrews { get; set; }
    }
}
