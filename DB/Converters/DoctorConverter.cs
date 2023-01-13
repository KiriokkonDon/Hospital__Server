using DB.Models;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DB.Converters
{
    public static class DoctorConverter
    {
        public static Doctors? ToDomain(this DoctorModel model)
        {
            return new Doctors
            {
                Id = model.Id,
                Name = model.Name,
                Specialization = model.Specialization.ToDomain()
            };
        }
        public static DoctorModel? ToModel(this Doctors model)
        {
            return new DoctorModel
            {
                Id = model.Id,
                Name = model.Name,
                Specialization = model.Specialization.ToModel()
            };
        }
    }
}
