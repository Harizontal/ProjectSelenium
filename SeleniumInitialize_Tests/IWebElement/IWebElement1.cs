using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace SeleniumInitialize_Tests.IWebElement
{
    public class IWebElement1 : TestBaseSetUp
    {
        [Test(Description = "Нахождение элемента с выпадающим списком")]
        public void FindElementWithDropDownList()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.IsNotNull(driver.FindElement(By.XPath("//mat-select[@role='combobox']")));
        }
        [Test(Description = "Нахождение элемента кнопки")]
        public void FindElementButton()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.IsNotNull(driver.FindElement(By.XPath("//button[@icon='gosuslugi']")));
        }
        [Test(Description = "Нахождение карточи семейная ипотека")]
        public void FindElementBrandsCard()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.IsNotNull(driver.FindElement(By.XPath("//div[contains(@class, 'brands-cards__item')][1]")));
        }
        [Test(Description = "Нахождение свитчера страхование жизни")]
        public void FindElementSwitcher()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.IsNotNull(driver.FindElement(By.XPath("//psb-switcher[contains(@class, 'deltas__switcher')][1]")));
        }
        [Test(Description = "Нахождение поля срока кредита")]
        public void FindElementInputLoanTerm()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.IsNotNull(driver.FindElement(By.XPath("//*[@id=\"loanPeriod\"]/rui-form-field-wrapper/rui-form-field/div/input")));
        }
        [Test(Description = "Ошибочный тест для скриншота браузера на момент падения теста")]
        public void ErrorTestForScreenShot()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            try
            {
                Assert.IsNotNull(driver.FindElement(By.XPath("//*[@id='m-field/div/input")));
            }
            catch
            {
                Thread.Sleep(500);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();    
                screenshot.SaveAsFile(@"C:\Users\Alexey\source\repos\ProjectSelenium\SeleniumInitialize_Tests\Failed.png");
            }
        }
    }
}
