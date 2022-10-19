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
    public class When_updating_sample : UsingSampleControllerSpec
    {
        private ActionResult<Sample > _result;
        private Sample _sample;

        public override void Context()
        {
            base.Context();

            _sample = new Sample
            {
                Name = "Name",
                Age = 76,
                Gender = "Gender",
                _Id = 60
            };

            _sampleService.Update( _sample).Returns(_sample);
            
        }
        public override void Because()
        {
            _result = subject.Update( _sample);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _sampleService.Received(1).Update( _sample);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Sample>();

            var resultList = resultListObject as Sample;

            resultList.ShouldBe(_sample);
        }
    }
}
