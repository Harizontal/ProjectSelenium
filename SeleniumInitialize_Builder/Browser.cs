using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Builder
{
    public class Browser
    {
        private IWebDriver _driver;
        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }
        /// <summary>
        /// Метод для ожидание загрузки страницы
        /// </summary>
        public void WaitForPageLoad(By element)
        {
            Thread.Sleep(500);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
                 .Until(ExpectedConditions
                 .ElementIsVisible(element));
        }
        /// <summary>
        /// Метод создаёт скриншот экрана страницы при падение теста
        /// </summary>
        public void TackeScreenshot()
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var timeStamp = DateTime.Now.ToString("yyyy_dd_MM_HH_mm");
            var fileName = $"Failed_{timeStamp}.png";
            var relativePath = Path.Combine("Screenshot", fileName);
            if(!Directory.Exists(relativePath))
                Directory.CreateDirectory(Path.GetDirectoryName(relativePath));
            screenshot.SaveAsFile(relativePath);
        }

        public void OpenTab(string URL)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript($"window.open('" + URL + "')");
        }
        /// <summary>
        /// Метод переключает на выбранную вкладку по индексу
        /// </summary>
        public void SwitchToTab(int index)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[index]);
        }
        /// <summary>
        /// Метод закрывает текущую вкладку и переключается по последнему дескриптору
        /// </summary>
        public void Close()
        {
            _driver.Close();
            _driver.SwitchTo().Window(_driver.WindowHandles[_driver.WindowHandles.Count - 1]);
        }
    }
}