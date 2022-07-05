using System;
using System.Collections.Generic;

namespace airportAutomatization
{
    public partial class Model
    {
        public Model()
        {
            Aircraft = new HashSet<Aircraft>();
        }

        public string ModelName { get; set; } = null!;
        public byte AdmissionGroup { get; set; }
        public string Fuel { get; set; } = null!;
        public short RunLength { get; set; }
        public int TakeoffWeight { get; set; }
        public short Height { get; set; }
        public short NumberOfSeats { get; set; }
        public short Speed { get; set; }

        public virtual ICollection<Aircraft> Aircraft { get; set; }
    }
}
