using NSubstitute;
using CodeQL.Test.Framework;
using CodeQL.Business.Services;
using CodeQL.Data.Interfaces;

namespace CodeQL.Test.Business.SampleServiceSpec
{
    public abstract class UsingSampleServiceSpec : SpecFor<SampleService>
    {
        protected ISampleRepository _sampleRepository;

        public override void Context()
        {
            _sampleRepository = Substitute.For<ISampleRepository>();
            subject = new SampleService(_sampleRepository);

        }

    }
}
