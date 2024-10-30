using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Builder
{
    // 1. Заходим на сайт по ссылке https://www.psbank.ru/
    // 2. Переходим во вкладку "Малому бизнесу". https://www.psbank.ru/Business
    // 3. Переходим на Экваринг и платежи https://www.psbank.ru/Business/Acquiring
    // 4. Найти элемент кнопка "Подробнее" и нажать на нее
    // 5. Вывести список Сфер Бизнесов до 300-400т

    public class Online
    {
        private IWebDriver _dirver;
        public Online(IWebDriver driver) 
        { 
            _dirver = driver;   
        }

        public By ElementWait = By.XPath("//div[@class='header-logo__image']");

        public IWebElement LinkPay
        {
            get => _dirver.FindElement(By.XPath("//span[contains(text(),'Эквайринг и платежи')]"));
        }
        public IWebElement LinkLitlleBusiness
        {
            get => _dirver.FindElement(By.XPath("//a[contains(text(),'Малому бизнесу')][1]"));
        }
        public Online ClickLinkPay()
        {
            LinkPay.Click();
            return this;
        }
        public Online ClickLinkLitlleBusiness()
        {
            LinkLitlleBusiness.Click();
            return this;
        }
    }
}
