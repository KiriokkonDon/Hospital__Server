using DB.Models;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Converters
{
    public static class SpecializationConverter
    {
        public static Specialization ToDomain(this SpecializationModel model)
        {
            return new Specialization
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static SpecializationModel ToModel(this Specialization model)
        {
            return new SpecializationModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
