using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hospital.Servise
{
    public class SheduleService
    {
        private readonly IScheduleRep _db;
        private readonly IDoctorRep _dbDocta;

        public SheduleService(IScheduleRep db, IDoctorRep dbDocta)
        {
            _db = db;
            _dbDocta = dbDocta;
        }

        public Result<Shedule> CreateShedule(Shedule shedule)
        {
            if (shedule.IsValid().IsFailure)
            {
                return Result.Fail<Shedule>("Invalid input data:" + shedule.IsValid().Error);
            }
            return _db.Create(shedule) ? Result.Ok(shedule) : Result.Fail<Shedule>("Unable to create shedule");
        }
        public Result<Shedule> UpdateShedule(Shedule shedule)
        {
            if (shedule.IsValid().IsFailure)
            {
                return Result.Fail<Shedule>("Invalid input data:" + shedule.IsValid().Error);
            }
            return _db.Update(shedule) ? Result.Ok(shedule) : Result.Fail<Shedule>("Unable to update shedule");
        }
        public Result<Shedule> GetSheduleTableByDoctorAndDate(Doctors doctor, DateTime date)
        {
            if (!_dbDocta.IsDoctorExist(doctor.Id))
            {
                return Result.Fail<Shedule>("Doctor not found");
            }

            var res = _db.GetSheduleTableByDoctorAndDate(doctor, date);
            return res != null ? Result.Ok(res) : Result.Fail<Shedule>("Unable to find shedule");
        }

        public void Save()
        {
            _db.Save();
        }
    }
}