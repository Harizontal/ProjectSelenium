using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumInitialize_Tests
{
    public class IWebElement2 : TestBaseSetUp
    {
        [Test(Description = "Получение значений элемента с выпадающим списком")]
        public void GetValuesDropDownList()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(6)).Build();
            driver.FindElement(By.XPath("//mat-select[@data-testid='calc-input-mortgageCreditType']")).Click();
            var options = driver.FindElements(By.XPath("//*[@id=\"mat-select-10-panel\"]/mat-option")).ToList();
            Assert.That(options.Count, Is.EqualTo(2));
        }
        [Test(Description = "Провекра карточки 'Семейная ипотека' на состояние 'Активна'")]
        public void CheckElementBrandsCard()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.IsTrue(driver.FindElement(By.XPath("//div[contains(@class, 'brands-cards__item')][1]")).Enabled);
        }
        [Test(Description = "Провекра свитчера 'Страхование жизни' на состояние 'Активна'")]
        public void CheckElementSwitcher()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.That(driver.FindElement(By.XPath("//psb-switcher[contains(@class, 'deltas__switcher ')][1]")).Enabled);
        }
        [Test(Description = "Получение значения поля срока кредита")]
        public void GetValueInputLoanTerm()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"loanPeriod\"]/rui-form-field-wrapper/rui-form-field/div/input")).GetAttribute("value"), Is.EqualTo("30"));
        }
    }
}
