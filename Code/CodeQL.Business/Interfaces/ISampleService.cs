using CodeQL.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeQL.Business.Interfaces
{
    public interface ISampleService
    {      
        IEnumerable<Sample> GetAll();
        Sample Save(Sample classification);
        Sample Update(Sample classification);
        bool Delete(int id);
        Sample  GetById(int id);

    }
}
