using CodeQL.Business.Interfaces;
using CodeQL.Data.Interfaces;
using CodeQL.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeQL.Business.Services
{
    public class SampleService : ISampleService
    {
        ISampleRepository _SampleRepository;

        public SampleService(ISampleRepository SampleRepository)
        {
           this._SampleRepository = SampleRepository;
        }
        public IEnumerable<Sample> GetAll()
        {
            return _SampleRepository.GetAll();
        }

        public Sample Save(Sample Sample)
        {
            _SampleRepository.Save(Sample);
            return Sample;
        }

        public Sample Update(Sample Sample)
        {
            return _SampleRepository.Update( Sample);
        }

        public bool Delete(int id)
        {
            return _SampleRepository.Delete(id);
        }
        public Sample GetById(int id)
        {
            return _SampleRepository.GetById(id);
        }

        public string GetString()
        {
            return "Hello";
        }
    }
}
