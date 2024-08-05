using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
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
            Browser = new Browser(Builder);
        }
        [TearDown]
        public void Dispose()
        {
            Browser.TackeScreenshot();
            Builder.Dispose();
        }
    }
}