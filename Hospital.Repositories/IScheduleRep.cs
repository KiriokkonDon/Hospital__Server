using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hospital.Repositories
{
    public interface IScheduleRep : IRep<Shedule>
    {
        Shedule? GetSheduleTableByDoctorAndDate(Doctors doctor, DateTime date);
    }
}