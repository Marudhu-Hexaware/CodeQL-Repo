using System.Collections.Generic;
using CodeQL.Business.Interfaces;
using CodeQL.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeQL.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        ISampleService _SampleService;
        public SampleController(ISampleService SampleService)
        {
            _SampleService = SampleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sample>> Get()
        {
            return Ok(_SampleService.GetAll());
        }

        [HttpPost]
        public ActionResult<Sample> Save(Sample Sample)
        {
            return Ok(_SampleService.Save(Sample));

        }

        [HttpPut]
        public ActionResult<Sample> Update( Sample Sample)
        {
            return Ok(_SampleService.Update(Sample));

        }

        [HttpDelete]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_SampleService.Delete(id));

        }
        [HttpGet("{id:int}")]
        public ActionResult<Sample> GetById(int id)
        {
            return Ok(_SampleService.GetById(id));
        }

    }
}
