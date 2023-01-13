using DB.Converters;
using DB.Models;
using Hospital.Models;
using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DB.Repositories
{
    public class SheduleRepository : IScheduleRep
    {
        private readonly ApplicationContext _context;

        public SheduleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(Shedule item)
        {
            var shedule = _context.Shedules.Add(item.ToModel());
            return true;
        }

        public bool Delete(Shedule item)
        {
            var shedule = _context.Shedules.SingleOrDefault(x => x.DoctorId == item.DoctorId);
            if (shedule != null)
            {
                _context.Remove(shedule);
                return true;
            }
            return false;
        }

        public IEnumerable<Shedule> GetAll()
        {
            var _shedules = _context.Shedules.ToList();
            var shedules = _shedules.Select(u => u.ToDomain()).ToList();
            return shedules;
        }

        public Shedule? GetSheduleTableByDoctorAndDate(Doctors doctor, DateTime date)
        {
            var shedule = _context.Shedules.FirstOrDefault(u => u.DoctorId == doctor.Id && u.Start_Time == date);
            return shedule?.ToDomain();
        }

        public void Save()
        {
            _context.SaveChanges();
            return;
        }

        public bool Update(Shedule item)
        {
            _context.Update(item);
            return true;
        }
    }
}
