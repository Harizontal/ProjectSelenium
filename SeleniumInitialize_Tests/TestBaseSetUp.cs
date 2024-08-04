using NUnit.Framework;
using SeleniumInitialize_Builder;

namespace SeleniumInitialize_Tests
{
    public abstract class TestBaseSetUp
    {
        public SeleniumBuilder Builder;

        [SetUp]
        public void Setup()
        {
            Builder = new SeleniumBuilder();
        }
        [TearDown]
        public void Dispose()
        {
            Builder.Dispose();
        }
    }
}