using DB.Converters;
using Hospital.Models;
using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class DoctorRepository : IDoctorRep
    {
        private readonly ApplicationContext _context;

        public DoctorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(Doctors item)
        {
            var doctor = _context.Doctors.Add(item.ToModel());
            return true;
        }

        public bool Delete(Doctors item)
        {
            var doctor = _context.Doctors.SingleOrDefault(u => u.Id == item.Id);
            if (doctor != null)
            {
                var flag = _context.Doctors.Remove(doctor);
                return true;
            }
            return false;
        }

        public IEnumerable<Doctors> GetAll()
        {
            var _doctors = _context.Doctors.Include(u => u.Specialization).ToList();
            var doctors = _doctors.Select(x => x.ToDomain()).ToList();
            return doctors;
        }

        public Doctors? GetDoctorById(int id)
        {
            var doctor = _context.Doctors.Include(u => u.Specialization).FirstOrDefault(u => u.Id == id);
            return doctor?.ToDomain();
        }

        public Doctors? GetDoctorBySpecialization(Specialization specialization)
        {
            var doctor = _context.Doctors.First(d => d.Specialization.ToDomain() == specialization);
            return doctor?.ToDomain();
        }

        public bool IsDoctorExist(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(u => u.Id == id);
            return doctor != null;
        }

        public bool IsDoctorExist(Doctors doctor)
        {
            var doctors = _context.Doctors.FirstOrDefault(u => u.Id == doctor.Id);
            return doctors != null;
        }

        public void Save()
        {
            _context.SaveChanges();
            return;
        }

        public bool Update(Doctors item)
        {
            _context.Doctors.Update(item.ToModel());
            return true;
        }
    }
}
