using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CushyTripV1.Class
{
    public class RegularPackage
    {
        public string details { get; set; }
		public string packageName { get; set; }
		public string regularPackageID { get; set; }
        public string price { get; set; }
        public string accomodation { get; set; }
        public string inclusions { get; set; }
		public List<string> images { get; set; }

        public List<string> iterinary { get; set; }
    }
}
