using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Tests.IWebElement
{
    public class IWebElement7 : TestBaseSetUp
    {
        [Test(Description = "Проверка наведением мыши с помощью Actions")]// Придумать название для метода и для второго
        public void WaitStatusElements()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").SetArgument("--start-maximized").Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var btnGosusslugi = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@icon='gosuslugi']/child::rui-wrapper")));
            Assert.That(Helper.RgbaToHex(btnGosusslugi.GetCssValue("background-color")), Is.EqualTo("#F26126"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(btnGosusslugi).Perform();
            Thread.Sleep(100);
            Assert.That(Helper.RgbaToHex(btnGosusslugi.GetCssValue("background-color")), Is.EqualTo("#D44921"));
        }
        [Test(Description = "Проверка корректной работы слайдера с помощью Actions")]
        public void WaitStatusElements2()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").SetArgument("--start-maximized").Build();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var slider = wait.Until(ExpectedConditions.ElementExists(By.XPath("//rui-range-slider[@id='amountPledge']/rui-form-field-wrapper/rui-slider")));
            var input = driver.FindElement(By.XPath("//rui-range-slider[@id='amountPledge']/descendant::input[@type='range']"));
            Actions actions = new Actions(driver);
            actions.ClickAndHold(slider).MoveByOffset(500, 0).Release().Build().Perform();
            Assert.That(input.GetAttribute("value").Replace(" ", ""), Is.EqualTo("100000000"));
        }
    }
}