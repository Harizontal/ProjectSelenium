using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SeleniumInitialize_Builder;

namespace SeleniumInitialize_Tests
{
    public abstract class TestBaseSetUp
    {
        public SeleniumBuilder Builder;
        public Browser Browser;

        [SetUp]
        public void Setup()
        {
            Builder = new SeleniumBuilder();
        }
        [TearDown]
        public void Dispose()
        {
            if ((TestContext.CurrentContext.Result.Outcome == ResultState.Failure) ||
            (TestContext.CurrentContext.Result.Outcome == ResultState.Error))
                Builder.Browser.TackeScreenshot();
            Builder.Dispose();
        }
    }
}