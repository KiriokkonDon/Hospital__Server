using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class DoctorModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public SpecializationModel Specialization { get; set; }

    }
}
