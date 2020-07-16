using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CushyTripV1.Class
{
    class Message
    {
        public int agencyId { get; set; }
        public int guestId { get; set; }
        public int sender { get; set; }

        public string message { get; set; }
    }
}
