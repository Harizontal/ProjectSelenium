using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumInitialize_Tests
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
        public void WaitForPageLoad()
        {
            Thread.Sleep(500);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
                 .Until(ExpectedConditions
                 .InvisibilityOfElementLocated(By.XPath("//div[@id='rui-icon-sprite-container']")));
        }
        /// <summary>
        /// Метод создаёт скриншот экрана страницы при падение теста
        /// </summary>
        public void TackeScreenshot()
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var fileName = $"Failed_{timeStamp}.png";
            var relativePath = Path.Combine("Screenshot", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(relativePath));
            screenshot.SaveAsFile(relativePath);
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