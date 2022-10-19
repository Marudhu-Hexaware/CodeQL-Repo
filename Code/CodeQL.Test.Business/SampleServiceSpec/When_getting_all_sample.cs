using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using CodeQL.Entities.Entities;

namespace CodeQL.Test.Business.SampleServiceSpec
{
    public class When_getting_all_sample : UsingSampleServiceSpec
    {
        private IEnumerable<Sample> _result;

        private IEnumerable<Sample> _all_sample;
        private Sample _sample;

        public override void Context()
        {
            base.Context();

            _sample = new Sample{
                Name = "Name",
                Age = 49,
                Gender = "Gender",
                _Id = 66
            };

            _all_sample = new List<Sample> { _sample};
            _sampleRepository.GetAll().Returns(_all_sample);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _sampleRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Sample>>();

            List<Sample> resultList = _result as List<Sample>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_sample);
        }
    }
}
