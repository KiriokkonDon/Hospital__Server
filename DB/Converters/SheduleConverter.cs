using DB.Models;
using Hospital.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DB.Converters
{
    public static class SheduleConverter
    {
        public static Shedule? ToDomain(this SheduleModel model)
        {
            return new Shedule
            {
                DoctorId=model.DoctorId,
                Start_Time=model.Start_Time,
                End_Time=model.End_Time
            };
        
        }

        public static SheduleModel? ToModel(this Shedule model)
        {
            return new SheduleModel
            {
                DoctorId = model.DoctorId,
                Start_Time = model.Start_Time,
                End_Time = model.End_Time
            };
        }
    }
}
