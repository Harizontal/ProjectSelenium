using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumInitialize_Tests.NavigationTo
{
    public class NavigationTo2 : TestBaseSetUp
    {
        [Test(Description = "Проверка полноценной загрузки сайта")]
        public void HomePageLoadsSuccessfully()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/").Build();
            var browser = Builder.Browser;
            browser.WaitForPageLoad(By.XPath("//h2[contains(text(), 'Финансовые продукты')]"));
        }
    }
}
