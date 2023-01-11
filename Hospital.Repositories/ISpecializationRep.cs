using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public interface ISpecializationRep : IRep<Specialization>
    {
        bool IsSpecializationExist(string name);
        bool IsSpecializationExist(Specialization specialization);
        bool IsSpecializationExistById(int id);
        Specialization? GetSpecialization(string name);
    }
}