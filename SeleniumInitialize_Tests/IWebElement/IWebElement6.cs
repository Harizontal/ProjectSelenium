using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics.Metrics;

namespace SeleniumInitialize_Tests.IWebElement
{
    public class IWebElement6 : TestBaseSetUp
    {
        [Test(Description = "Проверка состояние кнопки при заполнения формы")]
        public void CheckStatusByFillingForm()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").SetArgument("--start-maximized").Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//psb-loader[contains(@class,'mortgage-calculator-output__loader')]/descendant::psb-loader-icon")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Заполнить без Госуслуг')]/ancestor::button"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Хорошо')]/ancestor::psb-button"))).Click();
            var btnRegistrationNext = driver.FindElement(By.XPath("//button[contains(@rtl-automark, 'REGISTRATION_NEXT')]"));
            Thread.Sleep(1500);
            if (!btnRegistrationNext.Enabled)
            {
                var sureName = driver.FindElement(By.XPath("//input[@name='CardHolderLastName']"));
                var name = driver.FindElement(By.XPath("//input[@name='CardHolderFirstName']"));
                var fatherland = driver.FindElement(By.XPath("//input[@name='CardHolderMiddleName']"));
                var gender = driver.FindElement(By.XPath("//*[@id='formly_19_radio_Sex_0-0']"));
                var birthday = driver.FindElement(By.XPath("//input[@data-mat-calendar='mat-datepicker-1']"));
                var phone = driver.FindElement(By.XPath("//*[@id='formly_23_input_Phone_0']"));
                var email = driver.FindElement(By.XPath("//input[@name='Email']"));
                sureName.SendKeys("Иванов");
                name.SendKeys("Иван");
                fatherland.SendKeys("Иванович");
                gender.Click();
                birthday.Click();
                birthday.SendKeys("12122000");
                phone.Click();
                phone.SendKeys("9321231212");
                email.SendKeys("email@mail.ru");
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"formly_28_select-with-double-item_OfficeId_0\"]"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@role='listbox']/mat-option"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), ' Гражданство  ')]/ancestor::rtl-formly-field-select"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='formly_27_select_RussianFederationResident_0-panel']/mat-option"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), ' Официальное трудоустройство  ')]/ancestor::rtl-formly-field-select"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='formly_27_select_RussianEmployment_1-panel']/mat-option"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='formly_30_checkbox_PersonalDataProcessingAgreementConcent_0']"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='formly_32_checkbox_BkiRequestAgreementConcent_0']"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='formly_34_checkbox_PromotionAgreementConcent_0']"))).Click();
                Assert.That(btnRegistrationNext.Enabled, Is.True);
            }
            else
                Console.WriteLine("Кнопка кликабельна при пустой форме");
        }
    }
}