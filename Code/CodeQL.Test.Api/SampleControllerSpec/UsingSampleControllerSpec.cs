using NSubstitute;
using CodeQL.Test.Framework;
using CodeQL.Api.Controllers;
using CodeQL.Business.Interfaces;


namespace CodeQL.Test.Api.SampleControllerSpec
{
    public abstract class UsingSampleControllerSpec : SpecFor<SampleController>
    {
        protected ISampleService _sampleService;

        public override void Context()
        {
            _sampleService = Substitute.For<ISampleService>();
            subject = new SampleController(_sampleService);

        }

    }
}
