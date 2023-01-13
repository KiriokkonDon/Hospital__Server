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
    public class SpecializationRepository : ISpecializationRep
    {
        private readonly ApplicationContext _context;

        public SpecializationRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(Specialization item)
        {
            _context.Specializations.Add(item.ToModel());
            return true;
        }

        public bool Delete(Specialization item)
        {
            var spec = _context.Specializations.FirstOrDefault(u => u.Id == item.Id);
            if (spec != null)
            {
                _context.Specializations.Remove(spec);
                return true;
            }
            return false;
        }

        public IEnumerable<Specialization> GetAll()
        {
            var _specs = _context.Specializations.ToList();
            var specs = _specs.Select(s => s.ToDomain()).ToList();
            return specs;
        }

        public Specialization? GetSpecialization(string name)
        {
            var spec = _context.Specializations.FirstOrDefault(s => s.Name == name);
            return spec?.ToDomain();
        }

        public bool IsSpecializationExist(string name)
        {
            var spec = _context.Specializations.FirstOrDefault(u => u.Name == name);
            return spec != null;
        }

        public bool IsSpecializationExist(Specialization specialization)
        {
            var spec = _context.Specializations.FirstOrDefault(s => s.Id == specialization.Id);
            return spec != null;
        }

        public bool IsSpecializationExistById(int id)
        {
            var spec = _context.Specializations.FirstOrDefault(s => s.Id == id);
            return spec != null;
        }

        public void Save()
        {
            _context.SaveChanges();
            return;
        }

        public bool Update(Specialization item)
        {
            _context.Specializations.Update(item.ToModel());
            return true;
        }
    }
}
