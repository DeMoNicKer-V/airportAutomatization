using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Passenger
    {
        public Passenger()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int PassengerId { get; set; }
        public string FullName { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
