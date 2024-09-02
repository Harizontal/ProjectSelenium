using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumInitialize_Tests
{
    public class IWebElement2 : TestBaseSetUp
    {
        [Test(Description = "Получение значений элемента с выпадающим списком")]
        public void GetValuesDropDownList()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(6)).Build();
            driver.FindElement(By.XPath("//rui-form-field[.//label[text()='Объект ипотеки']]")).Click();
            var options = driver.FindElements(By.XPath("//*[@id='mat-select-10-panel']/mat-option")).ToList();
            Assert.That(options.Count, Is.EqualTo(2), "Неверное количество значении");
        }
        [Test(Description = "Провекра карточки 'Семейная ипотека' на состояние 'Активна'")]
        public void CheckElementBrandsCard()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.IsTrue(driver.FindElement(By.XPath("//div[./div[text()='Семейная ипотека — 6%']]")).Enabled, "Элемент карточки 'Семейная ипотека' не активна");
        }
        [Test(Description = "Провекра свитчера 'Страхование жизни' на состояние 'Активна'")]
        public void CheckElementSwitcher()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.That(driver.FindElement(By.XPath("//psb-switcher[.//psb-text[text()=' Страхование жизни ']]")).Enabled, "Элемент свитчера 'Страхование жизни' не активна");
        }
        [Test(Description = "Получение значения поля срока кредита")]
        public void GetValueInputLoanTerm()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            Assert.That(driver.FindElement(By.XPath("//rui-range-slider[@id='loanPeriod']/descendant::input[@unmask='typed']")).GetAttribute("value"), Is.EqualTo("30"), "Неверное значение");
        }
    }
}
