using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Cashier
    {
        public Cashier()
        {
            Tickets = new HashSet<Ticket>();
        }

        public short CashierId { get; set; }
        public string FullName { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
