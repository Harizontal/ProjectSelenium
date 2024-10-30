using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Builder
{
    public class AcquiringPage
    {
        private IWebDriver _dirver;
        public AcquiringPage(IWebDriver driver)
        {
            _dirver = driver;
        }

        public By ElementWait = By.XPath("//h2[text()='Онлайн-касса']");

        public IWebElement ButtonMoreDetailed => _dirver.FindElement(By.XPath("//*[text()='Онлайн-касса']/../../..//a[text()='Подробнее']"));

        public AcquiringPage ClickButton() 
        {
            ButtonMoreDetailed.Click();
            return this;
        }
    }
}
