using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Ticket
    {
        public long TicketId { get; set; }
        public decimal Price { get; set; }
        public short? CashierId { get; set; }
        public int? PassengerId { get; set; }
        public int FlightId { get; set; }

        public virtual Cashier? Cashier { get; set; }
        public virtual Flight Flight { get; set; } = null!;
        public virtual Passenger? Passenger { get; set; }
    }
}
