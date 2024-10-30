using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Builder
{
    public class DataPage
    {
        private IWebDriver _dirver;
        public DataPage(IWebDriver driver)
        {
            _dirver = driver;
        }

        public By ElementWait = By.XPath("//*[contains(text(),'Смарт-ставка')]");


    }
}
