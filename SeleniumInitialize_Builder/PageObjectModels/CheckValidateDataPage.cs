using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Builder.PageObjectModels
{
    public class CheckValidateDataPage
    {
        private IWebDriver _driver;

        public CheckValidateDataPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LastName
        {
            get { return _driver.FindElement(By.XPath("//*[./*[contains(text(),'Фамилия')]]/b")); }
        }
        public IWebElement FirstName
        {
            get { return _driver.FindElement(By.XPath("//*[./*[contains(text(),'Имя')]]/b")); }
        }
        public IWebElement MiddleName
        {
            get { return _driver.FindElement(By.XPath("//*[./*[contains(text(),'Отчество')]]/b")); }
        }
        public IWebElement Birthday
        {
            get { return _driver.FindElement(By.XPath("//*[./*[contains(text(),'Дата рождения')]]/b")); }
        }
        public IWebElement Phone
        {
            get { return _driver.FindElement(By.XPath("//*[./*[contains(text(),'Мобильный телефон')]]/b")); }
        }

        public bool CheckValidateData(string lastName, string firstName, string middleName, string birthday, string phone)
        {
            return
                lastName == LastName.Text &&
                firstName == FirstName.Text &&
                middleName == MiddleName.Text &&
                birthday == Birthday.Text &&
                phone == Phone.Text;
        }
    }
}
