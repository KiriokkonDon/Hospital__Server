using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Shedule
    {

        public int DoctorId { get; set; }

        public DateTime Start_Time;
        public DateTime End_Time;

        public Shedule() : this(0, new DateTime(), new DateTime()) { }
        public Shedule(int doctorId, DateTime start_Time, DateTime end_Time)
        {
            DoctorId = doctorId;
            Start_Time = start_Time;
            End_Time = end_Time;
        }

        public Result IsValid()
        {
            if (End_Time < Start_Time)
            {
                return Result.Fail("Invalid Time");
            }
            else
            {
                return Result.Ok();
            }
        }
    }
}