using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public interface IVisitRep : IRep<Visit>
    {
        bool IsVisitExist(Visit visit);
        IEnumerable<Visit?> GetVisitBySpec(Specialization specialization);
        IEnumerable<Visit?> GetVisitByDoctor(Doctors doctors);
    }
}
