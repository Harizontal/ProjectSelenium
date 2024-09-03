using OpenQA.Selenium;
using SeleniumInitialize_Builder.ControlElements;
using SeleniumInitialize_Builder.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Builder.PageObjectModels
{
    public class ConsumerCreditPage : YourCashbackPage
    {
        private IWebDriver _driver;
        public ConsumerCreditPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
        public DropDownList OfficialEmployment 
        {
            get { return new DropDownList(_driver, _driver.FindElement(By.XPath("//*[@name ='RussianEmployment']"))); }
        }
        public CheckBox BkiRequestConcent 
        {
            get { return new CheckBox(_driver, _driver.FindElement(By.XPath("//*[@name ='BkiRequestAgreementConcent']//input"))); }
        }
        public ConsumerCreditPage SelectEmployment(string employment)
        {
            OfficialEmployment.SelectValueByClicking(employment);
            return this;
        }
        public ConsumerCreditPage SetBkiRequestConcent()
        {
            BkiRequestConcent.Click();
            return this;
        }

        public override ConsumerCreditPage SetRandomDate()
        {
            base.SetRandomDate();
            SelectEmployment(DateGenerator.GenerateRandomEmployment());
            SetBkiRequestConcent();
            return this;
        }
    }
}
