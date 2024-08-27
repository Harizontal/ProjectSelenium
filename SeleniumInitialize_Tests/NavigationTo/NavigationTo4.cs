using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;


namespace SeleniumInitialize_Tests.NavigationTo
{
    public class NavigationTo4 : TestBaseSetUp
    {
        [Test(Description = "Проверка перехода по ссылке внутри элемента")]
        public void TransitionInsideLinkElement()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/consumer-loan").Build();
            var browser = Builder.Browser;
            Regex reg = new Regex(@"Генеральная лицензия на осуществление банковских операций № (\d+)\s+от\s+(\d{2}\s+\w+\s+\d{4})");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(), 'Как получить кредит')]"));
            browser.OpenTab("https://ib.psbank.ru/store/products/investmentsbrokerage");
            browser.SwitchToTab(1);
            browser.WaitForPageLoad(By.XPath("//span[contains(text(), 'Инвестиции в ценные бумаги')]"));

            var generalLicenseInvest = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//rtl-copyrights[contains(text(), '© 2001 – 2024 ПAO «Промсвязьбанк»')]"))).Text;
            Assert.IsTrue(reg.IsMatch(generalLicenseInvest), "Текст не соответсвует маске");
            browser.Close();
            var generalLicenseCredit = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//rtl-copyrights[contains(text(), '© 2001 – 2024 ПAO «Промсвязьбанк»')]"))).Text;
            Assert.IsTrue(reg.IsMatch(generalLicenseCredit), "Текст не соответсвует маске");
            Assert.That(generalLicenseCredit, Is.EquivalentTo(generalLicenseInvest), "generalLicenseCredit не равен generalLicenseInvest");
        }
    }
}