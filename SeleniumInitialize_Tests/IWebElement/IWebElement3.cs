using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Drawing;

namespace SeleniumInitialize_Tests.IWebElement
{
    public class IWebElement3 : TestBaseSetUp
    {
        [Test(Description = "Проверка кнопки на кликабельность")]
        public void CheckButtonClickable()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            var button = driver.FindElement(By.XPath("//button[@icon='gosuslugi']"));
            Assert.IsTrue(button.Enabled && button.Displayed);
        }
        [Test(Description = "Провекра кнопки на цвет")]
        public void CheckButtonColor()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            string backgroundColor = (driver.FindElement(By.XPath("//button[@icon='gosuslugi']/child::rui-wrapper")).GetCssValue("background-color"));
            Assert.That(Helper.RgbaToHex(backgroundColor), Is.EqualTo("#F26126"));
        }
        [Test(Description = "Проверка кнопки на высоту")]
        public void CheckButtonHeight()
        {
            IWebDriver driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(5)).Build();
            string height = driver.FindElement(By.XPath("//button[@icon='gosuslugi']")).GetCssValue("height");
            Assert.That(height, Is.EqualTo("48px"));
        }
    }
}
