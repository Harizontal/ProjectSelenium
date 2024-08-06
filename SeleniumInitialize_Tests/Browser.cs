using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Builder;

namespace SeleniumInitialize_Tests
{
    public class Browser
    {
        private SeleniumBuilder _builder;
        public Browser(SeleniumBuilder builder)
        {
            _builder = builder;
        }
        /// <summary>
        /// Метод для ожидание загрузки страницы
        /// </summary>
        public void WaitForPageLoad()
        {
            Thread.Sleep(500);
            new WebDriverWait(_builder.GetLastWebDriver(), TimeSpan.FromSeconds(5))
                 .Until(ExpectedConditions
                 .ElementIsVisible(By.XPath("//body/descendant::*[last()]")));
        }
        /// <summary>
        /// Метод создаёт скриншот экрана страницы при падение теста
        /// </summary>
        public void TackeScreenshot()
        {
            if ((TestContext.CurrentContext.Result.Outcome == ResultState.Failure) ||
            (TestContext.CurrentContext.Result.Outcome == ResultState.Error))
            {
                var screenshot = ((ITakesScreenshot)_builder.GetLastWebDriver()).GetScreenshot();
                screenshot.SaveAsFile(@"C:\Users\Alexey\source\repos\ProjectSelenium\SeleniumInitialize_Tests\Failed.png");
            }
        }
        /// <summary>
        /// Метод переключает на выбранную вкладку по индексу
        /// </summary>
        public void SwitchToTab(int index)
        {
            var driver = _builder.GetLastWebDriver();
            driver.SwitchTo().Window(driver.WindowHandles[index]);
        }
        /// <summary>
        /// Метод закрывает текущую вкладку и переключается по последнему дескриптору
        /// </summary>
        public void Close()
        {
            var driver = _builder.GetLastWebDriver();
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }
    }
}
