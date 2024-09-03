using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace SeleniumInitialize_Builder.ControlElements
{
    public class CheckBox
    {
        private IWebDriver _driver;
        private IWebElement _checkBox;
        public CheckBox(IWebDriver driver, IWebElement checkBox)
        {
            _driver = driver;
            _checkBox = checkBox;
        }

        /// <summary>
        /// Метод выбора и смены категорий
        /// </summary>
        public void SetCategory(string nameCategory)
        {   
            _driver.ExecuteJavaScript("arguments[0].click()", 
            _driver.FindElement(By.XPath($"//*[./*[contains(text(),'{nameCategory}')]]//input")));
        }

        public void Click()
        {
            _driver.ExecuteJavaScript("arguments[0].click()", _checkBox);
        }
    }
}
