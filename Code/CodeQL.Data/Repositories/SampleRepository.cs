using CodeQL.Data.Interfaces;
using CodeQL.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CodeQL.Data.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly DataContext _context;        

        public SampleRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Sample> GetAll()
        {            
            return _context.Sample.ToList();
        }

        public bool Save(Sample entity)
        {
            if (entity == null)
            return false;
            _context.Sample.Add(entity);
            var created= _context.SaveChanges();
            return created>0;
        }

        public Sample Update(Sample entity)
        {     
             _context.Sample.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {          

            int deleted = 0;
            var entity = _context.Sample.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Remove(entity);
                deleted = _context.SaveChanges();
            }
            return deleted > 0;
        }
        public Sample GetById(int id)
        {
            return _context.Sample.FirstOrDefault(x => x.Id == id);            
             
        }
    }
}
