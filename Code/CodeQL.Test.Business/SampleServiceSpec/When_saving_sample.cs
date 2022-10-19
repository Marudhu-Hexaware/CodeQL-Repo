using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using CodeQL.Entities.Entities;

namespace CodeQL.Test.Business.SampleServiceSpec
{
    public class When_saving_sample : UsingSampleServiceSpec
    {
        private Sample _result;

        private Sample _sample;

        public override void Context()
        {
            base.Context();

            _sample = new Sample
            {
                Name = "Name",
                Age = 12,
                Gender = "Gender",
                _Id = 18
            };

            _sampleRepository.Save(_sample).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_sample);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _sampleRepository.Received(1).Save(_sample);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Sample>();

            _result.ShouldBe(_sample);
        }
    }
}
