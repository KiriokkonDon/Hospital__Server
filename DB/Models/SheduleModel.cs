using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class SheduleModel
    {
        [Key]
        public int DoctorId { get; set; }

        public DateTime Start_Time;
        public DateTime End_Time;
    }
}
