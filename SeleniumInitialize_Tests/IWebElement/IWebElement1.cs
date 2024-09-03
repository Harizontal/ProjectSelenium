using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumInitialize_Tests.IWebElement
{
    public class IWebElement1 : TestBaseSetUp
    {
        [Test(Description = "Нахождение элемента с выпадающим списком")]
        public void FindElementWithDropDownList()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(100)).Build();
            var element = driver.FindElements(By.XPath("//rui-form-field[.//label[text()='Объект ипотеки']]")).SingleOrDefault();
            Assert.IsNotNull(element, "Элемент с выпадающим списком не найден");
        }

        [Test(Description = "Нахождение элемента кнопки")]
        public void FindElementButton()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(100)).Build();
            var element = driver.FindElements(By.XPath("//button[@icon='gosuslugi']")).SingleOrDefault();
            Assert.IsNotNull(element, "Элемент кнопки не найден");
        }

        [Test(Description = "Нахождение карточи семейная ипотека")]
        public void FindElementBrandsCard()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(100)).Build();
            var element = driver.FindElements(By.XPath("//div[./div[text()='Семейная ипотека — 6%']]")).SingleOrDefault();
            Assert.IsNotNull(element, "Карточка семейной ипотеки не найдена");
        }

        [Test(Description = "Нахождение свитчера страхование жизни")]
        public void FindElementSwitcher()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(100)).Build();
            var element = driver.FindElements(By.XPath("//psb-switcher[.//psb-text[text()=' Страхование жизни ']]")).SingleOrDefault();
            Assert.IsNotNull(element, "Свитчер страхования жизни не найден");
        }

        [Test(Description = "Нахождение поля срока кредита")]
        public void FindElementInputLoanTerm()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(100)).Build();
            var element = driver.FindElements(By.XPath("//rui-range-slider[@id='loanPeriod']/descendant::input[@unmask='typed']")).SingleOrDefault();
            Assert.IsNotNull(element, "Поле срока кредита не найдено");
        }

        [Test(Description = "Ошибочный тест для скриншота браузера на момент падения теста")]
        public void ErrorTestForScreenShot()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            var element = driver.FindElements(By.XPath("//*[@id='m-field/div/input")).SingleOrDefault();
            Assert.IsNull(element, "Элемент должен был отсутствовать на странице");
        }
    }
}
