using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.IWebElement
{
    public class IWebElement4 : TestBaseSetUp
    {
        [Test(Description = "C ожиданием состояний элементов.")]
        public void WaitStatusElements()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/military-family-mortgage-program").SetArgument("--start-maximized").Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var button = By.XPath("//*[contains(text(), 'Заполнить без Госуслуг')]/ancestor::button");
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//psb-loader-icon[contains(@class, 'ng-tns-c97-19')]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(button)).Click();
            Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'mortgage-calculator-output__alert') and contains(@class, 'mortgage-calculator-output__alert_show')]"))).Text, 
            Is.EqualTo("Оформление заявки станет доступным после заполнения обязательных полей"));
            wait.Until(ExpectedConditions.ElementToBeClickable(button));
        }
        [Test(Description = "C ожиданием состояний изменений состояний после взаимодействия со свитчером")]
        public void WaitStatusInteractionsSwitcher()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").SetArgument("--start-maximized").Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var listSwitcher = wait.Until(driver => driver.FindElements(By.XPath("//div[@class='deltas__list']/descendant::label[@class='switcher']")).ToList());
            var listPsbStatus = wait.Until(driver => driver.FindElements(By.XPath("//div[contains(@class, 'deltas__list')]/descendant::psb-status")).ToList());
            for (int i = 0; i < listPsbStatus.Count; i++)
            {
                if (listPsbStatus[i].GetAttribute("class").Contains("_success"))
                    listSwitcher[i].Click();
                wait.Until(driver => !listPsbStatus[i].GetAttribute("class").Contains("_success"));
            }
        }

    }
}