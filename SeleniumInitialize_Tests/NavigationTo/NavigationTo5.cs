using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.NavigationTo
{
    public class NavigationTo5 : TestBaseSetUp
    {
        [Test(Description = "Проверка работы с различными вкладками на странице")]
        public void WorkingWithDifferentTab()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/").SetArgument("--start-maximized").Build();
            Regex reg = new Regex(@"\d*%");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var purposesAcquisition = By.XPath("//button[.//span[text()=' Приобретение ']]");
            var purposesRefinancing = By.XPath("//button[.//span[text()=' Рефинансирование ']]");
            var mortgageCalculatorLoader = By.XPath("//psb-loader[contains(@class, 'mortgage-calculator__loader')]/descendant::psb-loader-icon");
            var mortgageCalculatorOutputLoader = By.XPath("//psb-loader[contains(@class,'mortgage-calculator-output__loader')]/descendant::psb-loader-icon");
            var rate = By.XPath("//span[text()='Ставка по кредиту']/following-sibling::div");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[.//span[text()='Ипотека']]"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()=' Ипотека для военных ']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(purposesAcquisition)).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(mortgageCalculatorLoader));
            Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(purposesAcquisition)).GetAttribute("data-appearance"), Is.EqualTo("dark"), "Элемент не был окрашен в черный цвет");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[./div[text()='Семейная ипотека — 6%']]"))).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(mortgageCalculatorLoader));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(mortgageCalculatorOutputLoader));
            Assert.IsTrue(reg.IsMatch(wait.Until(ExpectedConditions.ElementIsVisible(rate)).Text), "Значение не соответсвует маске");

            driver.FindElement(purposesRefinancing).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(mortgageCalculatorLoader));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[./div[text()='Рефинансирование. Семейная ипотека — 6%']]"))).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(mortgageCalculatorLoader));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(mortgageCalculatorOutputLoader));
            Assert.IsTrue(reg.IsMatch(wait.Until(ExpectedConditions.ElementIsVisible(rate)).Text), "Значение не соответсвует маске");
        }
    }
}

