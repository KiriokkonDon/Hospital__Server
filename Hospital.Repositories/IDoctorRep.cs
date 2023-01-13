
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public interface IDoctorRep : IRep<Doctors>
    {
        bool IsDoctorExist(int id);
        bool IsDoctorExist(Doctors doctor);
        Doctors? GetDoctorById(int id);
        Doctors? GetDoctorBySpecialization(Specialization specialization);

    }
}