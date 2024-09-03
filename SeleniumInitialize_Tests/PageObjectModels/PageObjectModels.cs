using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Builder.PageObjectModels;

namespace SeleniumInitialize_Tests.PageObjectModels
{
    public class PageObjectModels : TestBaseSetUp
    {
        [Test(Description = "Заполнение формы с помощью PageObjectModel")]
        public void FillFormWithPageObjectModel()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var cashBack = new YourCashbackPage(driver);

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Заявка на карту')]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Хорошо')]/ancestor::psb-button"))).Click();
            cashBack
                .SetRandomDate()
                .SetPromotionAgreementConcent()
                .SetConsentPersonalData();
            Assert.True(cashBack.Continue.Enabled);
            cashBack.Submit();
        }

        [Test(Description = "Проверка достоверности введенных данных между страницами")]
        public void CheckValidateDataPage()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var cashBack = new YourCashbackPage(driver);

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Заявка на карту')]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Хорошо')]/ancestor::psb-button"))).Click();
            cashBack
                .SetRandomDate()
                .SetPromotionAgreementConcent()
                .SetConsentPersonalData();
            var lastName = cashBack.LastName.GetValueDropDownList();
            var firstName = cashBack.FirstName.GetValueDropDownList();
            var middleName = cashBack.MiddleName.GetValueDropDownList();
            var birthday = cashBack.Birthday.GetValueDataPicker();
            var phone = cashBack.Phone.GetAttribute("value");
            cashBack.Submit();
            var checkData = new CheckValidateDataPage(driver);
            Assert.IsTrue(checkData.CheckValidateData(lastName, firstName, middleName, birthday, phone));
        }
        [Test(Description = "Проверка достоверности введенных данных между страницами с наследованием POM")]
        public void CheckValidateDataInheritancePage()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/consumer-loan").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var consCredit = new ConsumerCreditPage(driver);

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Давайте знакомиться!')]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Хорошо')]/ancestor::psb-button"))).Click();
            consCredit
                .SetRandomDate()
                .SetPromotionAgreementConcent()
                .SetConsentPersonalData();
            var lastName = consCredit.LastName.GetValueDropDownList();
            var firstName = consCredit.FirstName.GetValueDropDownList();
            var middleName = consCredit.MiddleName.GetValueDropDownList();
            var birthday = consCredit.Birthday.GetValueDataPicker();
            var phone = consCredit.Phone.GetAttribute("value");
            consCredit.Submit();
            var checkData = new CheckValidateDataPage(driver);
            Assert.IsTrue(checkData.CheckValidateData(lastName, firstName, middleName, birthday, phone));
        }
    }
}
