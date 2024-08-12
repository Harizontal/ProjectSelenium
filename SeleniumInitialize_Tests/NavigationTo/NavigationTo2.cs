using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumInitialize_Builder;

namespace SeleniumInitialize_Tests.NavigationTo
{
    public class NavigationTo2 : TestBaseSetUp
    {
        [Test(Description = "Проверка полноценной загрузки сайта")]
        public void HomePageLoadsSuccessfully()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/").Build();
            var browser = Builder.GetBrowser();
            browser.WaitForPageLoad(By.XPath("//h2[contains(text(), 'Финансовые продукты')]"));
            Assert.That(driver.FindElements(By.XPath("//h2[contains(text(), 'Финансовые продукты')]")).SingleOrDefault(), Is.Not.Null);
        }
    }
}
