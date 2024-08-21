using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.NavigationTo
{
    public class NavigationTo3 : TestBaseSetUp
    {
        [Test(Description = "Проверка перехода по ссылке внутри элемента")]
        public void HomePageLoadsSuccessfully()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/").Build();
            var browser = Builder.GetBrowser();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            browser.WaitForPageLoad(By.XPath("//h2[text()='Финансовые продукты']"));
            driver.FindElement(By.XPath("//a[.//span[contains(text(),'Инвестиции')]]")).Click();
            var hrefBroker = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(), 'Брокерский договор')]")));
            Assert.That(hrefBroker.GetAttribute("href"), Is.EqualTo("https://ib.psbank.ru/store/products/investmentsbrokerage"));
            hrefBroker.Click();
            browser.WaitForPageLoad(By.XPath("//h2[contains(text(), 'Заключить договор через Госуслуги')]"));
            Assert.That(((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState"), Is.EqualTo("complete"));
            Assert.That(driver.Url, Is.EqualTo("https://ib.psbank.ru/store/products/investmentsbrokerage"), "Текущая ссылка не соответсвует ожидаемой");
        }
    }
}
