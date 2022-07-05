using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Copilot
    {
        public Copilot()
        {
            Aircrews = new HashSet<Aircrew>();
        }

        public short CopilotId { get; set; }
        public string FullName { get; set; } = null!;
        public byte AdmissionGroup { get; set; }
        public short NumberOfFlights { get; set; }

        public virtual ICollection<Aircrew> Aircrews { get; set; }
    }
}
