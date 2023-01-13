using DB.Models;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Converters
{
    public static class VisitConverter
    {
        public static Visit? ToDomain(this VisitModel model)
        {
            return new Visit
            {
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                Start_Time = model.Start_Time,
                End_Time = model.End_Time
        };
        }

        public static VisitModel? ToModel(this Visit model)
        {
            return new VisitModel
            {

                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                Start_Time = model.Start_Time,
                End_Time = model.End_Time
            };
        }
    }
}
