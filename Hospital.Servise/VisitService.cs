using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Servise
{
    public class VisitService
    {
        private readonly IVisitRep _db;
        private readonly IDoctorRep _dbDoctor;
        private readonly IUserRep _dbUser;
        private readonly ISpecializationRep _dbSpec;

        public VisitService(IVisitRep db, IDoctorRep dbDoctor, IUserRep dbUse, ISpecializationRep dbSpec)
        {
            _db = db;
            _dbDoctor = dbDoctor;
            _dbUser = dbUse;
            _dbSpec = dbSpec;
        }

        public Result<Visit> CreateVisit(User user, Doctors doctors)
        {
            if (_dbDoctor.IsDoctorExist(doctors) == false)
                return Result.Fail<Visit>("Doctor is not exist");

            if (_dbUser.IsUserExist(user) == false)
                return Result.Fail<Visit>("Patient is not exist");

            if (user.Role != Role.Patient)
                return Result.Fail<Visit>("User is not a patient");

            var date = _db.GetVisitByDoctor(doctors).First<Visit>();


            if (date.IsValid().IsFailure)
            {
                return Result.Fail<Visit>("Invalid visit");
            }

            if (_db.IsVisitExist(date))
            {
                return Result.Fail<Visit>("Visit already exists");
            }

            return _db.Create(date) ? Result.Ok(date) : Result.Fail<Visit>("Unable to create appointment");
        }

        public Result<Visit> CreateVisit(User user, Specialization specialization)
        {
            if (_dbUser.IsUserExist(user) == false)
                return Result.Fail<Visit>("Patient is not exist");

            if (_dbSpec.IsSpecializationExist(specialization) == false)
                return Result.Fail<Visit>("Doctor is not exist");

            if (user.Role != Role.Patient)
                return Result.Fail<Visit>("User is not a patient");

            var date = _db.GetVisitBySpec(specialization).First<Visit>();
            if (date == null)
            {
                return Result.Fail<Visit>("There are not actual dates");
            }
            if (date.IsValid().IsFailure)
            {
                return Result.Fail<Visit>("Invalid visit");
            }

            if (_db.IsVisitExist(date))
            {
                return Result.Fail<Visit>("Visit already exists");
            }
            return _db.Create(date) ? Result.Ok(date) : Result.Fail<Visit>("Unable to create appointment");
        }
        public Result<IEnumerable<Visit?>> GetVisitBySpec(Specialization specialization)
        {
            var success = _db.GetVisitBySpec(specialization);
            return Result.Ok(success);
        }

    }
}