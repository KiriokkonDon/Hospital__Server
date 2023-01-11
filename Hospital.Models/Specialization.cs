using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialization() : this(0, "") { }
        public Specialization(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Result IsValid()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return Result.Fail("Invalid specialization name");
            }
            else { return Result.Ok(); }
        }
    }
}
