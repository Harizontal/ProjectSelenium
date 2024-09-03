using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumInitialize_Builder.ControlElements;
using SeleniumInitialize_Builder.Generator;
using System;

namespace SeleniumInitialize_Builder.PageObjectModels
{
    public class YourCashbackPage
    {
        private IWebDriver _driver;
        public YourCashbackPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public DropDownList LastName
        {
            get { return new DropDownList(_driver, _driver.FindElement(By.XPath("//input[@name='CardHolderLastName']"))); }
        }
        public DropDownList FirstName
        {
            get { return new DropDownList(_driver, _driver.FindElement(By.XPath("//input[@name='CardHolderFirstName']"))); }
        }
        public DropDownList MiddleName
        {
            get { return new DropDownList(_driver, _driver.FindElement(By.XPath("//input[@name='CardHolderMiddleName']"))); }
        }

        public IWebElement MaleGender
        {
            get { return _driver.FindElement(By.XPath("//*[./*[contains(text(),'Мужской')]]")); }
        }

        public IWebElement FemaleGender
        {
            get { return _driver.FindElement(By.XPath("//*[./*[contains(text(),'Женский')]]")); }
        }

        public DatePicker Birthday
        {
            get { return new DatePicker(_driver, _driver.FindElement(By.XPath("//input[contains(@class,'mat-datepicker-input')]"))); }
        }

        public IWebElement Phone
        {
            get { return _driver.FindElement(By.XPath("//input[@name='Phone']")); }
        }

        public DropDownList Citizenship
        {
            get { return new DropDownList(_driver, _driver.FindElement(By.XPath("//mat-select[@name='RussianFederationResident']"))); }
        }

        public CheckBox ConsentPersonalData
        {
            get { return new CheckBox(_driver, _driver.FindElement(By.XPath("//*[@name='PersonalDataProcessingAgreementConcent']//input"))); }
        }

        public CheckBox PromotionAgreementConcent
        {
            get { return new CheckBox(_driver, _driver.FindElement(By.XPath("//*[@name='PromotionAgreementConcent']//input"))); }
        }

        public IWebElement Continue 
        {
            get { return _driver.FindElement(By.XPath("//button[contains(@class,'registration-form__next')]")); }
        }

        public YourCashbackPage FillLastName(string lastName)
        {
            LastName.SelectValueByTyping(lastName);
            return this;
        }
        public YourCashbackPage FillFirstName(string firstName)
        {
            FirstName.SelectValueByTyping(firstName);
            return this;
        }
        public YourCashbackPage FillMiddleName(string middleName)
        {
            MiddleName.SelectValueByTyping(middleName);
            return this;
        }
        public YourCashbackPage SelectMaleGender()
        {
            MaleGender.Click();
            return this;
        }
        public YourCashbackPage SelectFemaleGender()
        {
            FemaleGender.Click();
            return this;
        }
        public YourCashbackPage SetDateOfBirth(string birthday)
        {
            Birthday.SetDateOfBirth(birthday);
            return this;
        }
        public YourCashbackPage FillPhone(string numberPhone)
        {
            Phone.Click();
            Phone.SendKeys(numberPhone);
            return this;
        }
        public YourCashbackPage SelectCitizenship(string citizenship)
        {
            Citizenship.SelectValueByClicking(citizenship);
            return this;
        }

        public YourCashbackPage SetConsentPersonalData()
        {
            ConsentPersonalData.Click();
            return this;
        }

        public YourCashbackPage SetPromotionAgreementConcent()
        {
            PromotionAgreementConcent.Click();
            return this;
        }

        public YourCashbackPage Submit()
        {
            Continue.Click();
            return this;
        }

        public virtual YourCashbackPage SetRandomDate()
        {
            SetDateOfBirth(DateGenerator.GetRandomBirthday());
            FillLastName(DateGenerator.GetRandomWord());
            FillFirstName(DateGenerator.GetRandomWord());
            FillMiddleName(DateGenerator.GetRandomWord());
            if (DateGenerator.RandomBoolean())
                SelectFemaleGender();
            else
                SelectMaleGender();
            FillPhone(DateGenerator.GetRandomPhoneNumber());
            SelectCitizenship(DateGenerator.GenerateRandomCitizenship());
            return this;
        }
    }
}
