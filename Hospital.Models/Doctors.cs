using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialization Specialization { get; set; }

        public Doctors() : this(0, "", new Specialization()) { }

        public Doctors(int id, string name, Specialization specialization)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
        }

        public Result IsValid()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return Result.Fail("Non correct name");
            }
            else if (string.IsNullOrEmpty(Specialization.Name))
            {
                return Result.Fail("Non correct specialization name");
            }
            else
            {
                return Result.Ok();
            }
        }
    }
}
