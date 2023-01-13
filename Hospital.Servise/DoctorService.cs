using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Servise
{
    public class DoctorService
    {
        private readonly IDoctorRep _db;
        public DoctorService(IDoctorRep db)
        {
            _db = db;
        }

        public Result<bool> IsDoctorExists(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return Result.Fail<bool>("Invalid login");
            }
            else
            {
                return Result.Ok(_db.IsDoctorExist(id));
            }
        }

        public Result<Doctors> CreateDoctor(Doctors doctor)
        {
            if (doctor.IsValid().IsFailure)
            {
                return Result.Fail<Doctors>(doctor.IsValid().Error);
            }
            else if (_db.IsDoctorExist(doctor.Id))
            {
                return Result.Fail<Doctors>("Doctor already exist");
            }
            else
            {
                var success = _db.Create(doctor);
                return success ? Result.Ok(doctor) : Result.Fail<Doctors>("Error Create");
            }
        }

        public Result<Doctors> GetDoctorBySpecialization(Specialization specialization)
        {
            var valid = specialization.IsValid();
            if (valid.IsFailure)
                return Result.Fail<Doctors>(valid.Error);

            var doctor = _db.GetDoctorBySpecialization(specialization);
            return doctor != null ? Result.Ok(doctor) : Result.Fail<Doctors>("Doctor not found");
        }
        public Result<Doctors> GetDoctorById(int id)
        {
            var doctor = _db.GetDoctorById(id);
            return doctor != null ? Result.Ok(doctor) : Result.Fail<Doctors>("Doctor not found");
        }

        public Result<Doctors> DeleteDoctor(Doctors doctor)
        {
            var res = GetDoctorById(doctor.Id);
            if (res.IsFailure)
            {
                return Result.Fail<Doctors>("There is no such doctor");
            }

            return _db.Delete(doctor) ? res : Result.Fail<Doctors>("Error while deleting.Try again later");
        }
        public Result<IEnumerable<Doctors>> GetAll()
        {
            var doctors = _db.GetAll();
            return doctors != null ? Result.Ok(doctors) : Result.Fail<IEnumerable<Doctors>>("No doctors");
        }

        public void Save()
        {
            _db.Save();
        }
    }
}