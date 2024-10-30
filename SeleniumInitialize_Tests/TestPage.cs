using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumInitialize_Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Tests
{
    public class TestPage : TestBaseSetUp
    {
        [Test]
        public void TestingPage()
        {
            var driver = Builder.WithURL("https://www.psbank.ru/").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            var online = new Online(driver);
            var Acquiring = new AcquiringPage(driver);
            var dataPage = new DataPage(driver);

            browser.WaitForPageLoad(online.ElementWait);
            online.ClickLinkLitlleBusiness();
            browser.WaitForPageLoad(online.ElementWait);
            online.ClickLinkPay();
            browser.WaitForPageLoad(Acquiring.ElementWait);
            Acquiring.ClickButton();
            browser.WaitForPageLoad(dataPage.ElementWait);
            var ListBusiness = driver.FindElements(By.XPath("//table[@class='tariff-info__table']/tbody/tr"));
            foreach(var business in ListBusiness)
            {
                Console.Write(business.FindElement(By.XPath(".//strong")).Text + " ");
                Console.WriteLine(business.FindElement(By.XPath("./td[5]")).Text);
            }
        }
    }
}
