using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Objects
{
    public class DateInterval
    {
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }

        public DateInterval()
        {
            startDate = new DateTime();
            endDate = null;
        }
    }
}
