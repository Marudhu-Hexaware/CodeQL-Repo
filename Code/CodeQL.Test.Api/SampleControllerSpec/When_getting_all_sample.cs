using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using CodeQL.Entities.Entities;

namespace CodeQL.Test.Api.SampleControllerSpec
{
    public class When_getting_all_sample : UsingSampleControllerSpec
    {
        private ActionResult<IEnumerable<Sample>> _result;

        private IEnumerable<Sample> _all_sample;
        private Sample _sample;

        public override void Context()
        {
            base.Context();

            _sample = new Sample{
                Name = "Name",
                Age = 60,
                Gender = "Gender",
                _Id = 20
            };

            _all_sample = new List<Sample> { _sample};
            _sampleService.GetAll().Returns(_all_sample);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _sampleService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Sample>>();

            List<Sample> resultList = resultListObject as List<Sample>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_sample);
        }
    }
}
