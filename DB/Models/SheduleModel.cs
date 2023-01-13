using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class SheduleModel
    {
        public int DoctorId { get; set; }

        public DateTime Start_Time;
        public DateTime End_Time;
    }
}
