using DB.Converters;
using DB.Models;
using Hospital.Models;
using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class VisitRepository : IVisitRep
    {
        private readonly ApplicationContext _context;

        public VisitRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(Visit item)
        {
            _context.Visits.Add(item.ToModel());
            return true;
        }

        public bool Delete(Visit item)
        {
            var visit = _context.Visits.FirstOrDefault(v => v.PatientId == item.DoctorId);
            if (visit != null)
            {
                _context.Visits.Remove(visit);
                return true;
            }
            return false;
        }

        public IEnumerable<Visit> GetAll()
        {
            var _visits = _context.Visits.ToList();
            var visits = _context.Visits.Select(v => v.ToDomain()).ToList();
            return visits;
        }

        public IEnumerable<Visit?> GetVisitByDoctor(Doctors doctors)
        {
            var visits = _context.Visits.Where(u => u.DoctorId == doctors.Id && u.PatientId == 0).ToList();
            var date = visits.Select(x => x.ToDomain()).ToList();
            return date;
        }

        public IEnumerable<Visit?> GetVisitBySpec(Specialization specialization)
        {
            var doctors = _context.Doctors.Where(d => d.Specialization.ToDomain() == specialization);
            var alldates = new List<VisitModel>();
            foreach (var doctor in doctors)
            {
                var appointment = _context.Visits.Where(s => s.DoctorId == doctor.Id && s.PatientId == 0).ToList();
                appointment.ForEach(p => alldates.Add(p));
            }
            IEnumerable<Visit?> date = alldates.Select(s => s.ToDomain()).ToList();
            return date;
        }

        public bool IsVisitExist(Visit visit)
        {
            return _context.Visits.FirstOrDefault(v => v.DoctorId == visit.DoctorId && v.PatientId == visit.PatientId) != null;
        }

        public void Save()
        {
            _context.SaveChanges();
            return;
        }

        public bool Update(Visit item)
        {
            _context.Visits.Update(item.ToModel());
            return true;
        }
    }
}
