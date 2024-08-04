using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.IWebElement
{
    public class IWebElement4 : TestBaseSetUp
    {
        [Test]
        public void WaitStatusElements()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/military-family-mortgage-program").Build();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//psb-loader-icon[contains(@class, 'ng-tns-c97-19')]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button')][2]"))).Click();
            Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'mortgage-calculator-output__alert') and contains(@class, 'mortgage-calculator-output__alert_show')]"))).Text, 
            Is.EqualTo("Оформление заявки станет доступным после заполнения обязательных полей"));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button')][2]")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[contains(@class, 'mortgage-calculator-output__alert') and contains(@class, 'mortgage-calculator-output__alert_show')]")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button')][2]")));
        }
        [Test]
        public void WaitStatusElements2()
        {

            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").Build();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            var listSwitcher = wait.Until(b => b.FindElements(By.XPath("//div[@class='deltas__list']/descendant::label[@class='switcher']")).ToList());
            var listPsbStatus = wait.Until(b => b.FindElements(By.XPath("//psb-status")).ToList());
            for (int i = 0; i < listPsbStatus.Count; i++)
            {
                if (listPsbStatus[i].GetAttribute("class").Contains("_success"))
                    listSwitcher[i].Click();
                wait.Until(d => !listPsbStatus[i].GetAttribute("class").Contains("_success"));
            }
        }

    }
}