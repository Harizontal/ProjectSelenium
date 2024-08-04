using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;
namespace SeleniumInitialize_Tests
{
    public class Tests : TestBaseSetUp
    {

        [Test(Description = "Проверка корректной инициализации экземпляра IWebDriver")]
        public void BuildTest1()
        {
            IWebDriver driver = Builder.Build();
            Assert.IsNotNull(driver);
        }

        [Test(Description = "Проверка очистки ресурсов IWebDriver")]
        public void DisposeTest1()
        {
            IWebDriver driver = Builder.Build();
            Assert.IsFalse(Builder.IsDisposed);
            Builder.Dispose();
            Assert.IsTrue(Builder.IsDisposed);
            var processes = Process.GetProcessesByName("chromedriver.exe");
            Assert.IsFalse(processes.Any());
        }

        [Test(Description = "Проверка смены порта драйвера")]
        public void PortTest1()
        {
            IWebDriver driver = Builder.ChangePort(3737).Build();
            Assert.That(Builder.Port, Is.EqualTo(3737));
        }

        [Test(Description = "Проверка смены порта на случайный")]
        public void PortTest2()
        {
            int port = new Random().Next(6000, 32000);
            IWebDriver driver = Builder.ChangePort(port).Build();
            Assert.That(Builder.Port, Is.EqualTo(port));

        }

        [Test(Description = "Проверка добавления аргумента")]
        public void ArgumentTest1()
        {
            string argument = "--start-maximized";
            IWebDriver driver = Builder.SetArgument(argument).Build();
            Assert.Contains(argument, Builder.ChangedArguments);
            var startingSize = driver.Manage().Window.Size;
            driver.Manage().Window.Maximize();
            Assert.That(driver.Manage().Window.Size, Is.EqualTo(startingSize));

        }
        [Test(Description = "Проверка запуска браузера в headless режима")]
        public void HeadlessTest1()
        {
            IWebDriver driver = Builder.EditHeadless().Build();
            Assert.IsTrue(Builder.IsHeadless);
            var processes = Process.GetProcessesByName("chromedriver.exe");
            Assert.IsFalse(processes.Any());
        }
        [Test(Description = "Проверка запуска браузера в headless режима")]
        public void HeadlessTest2()
        {
            IWebDriver driver = Builder.SetArgument("--headless").Build();
            Assert.IsTrue(Builder.IsHeadless);
            var processes = Process.GetProcessesByName("chromedriver.exe");
            Assert.IsFalse(processes.Any());
        }
        [Test(Description = "Проверка запуска браузера в headless режима")]
        public void HeadlessTest3()
        {
            IWebDriver driver = Builder.SetArgument("--headless").EditHeadless().Build();
            Assert.IsFalse(Builder.IsHeadless);
            var processes = Process.GetProcessesByName("chromedriver.exe");
            Assert.IsFalse(processes.Any());
        }

        [Test(Description = "Добавление пользовательской настройки")]
        public void UserOptionTest()
        {
            string key = "safebrowsing.enabled";
            IWebDriver driver = Builder.SetUserOption(key, true).Build();
            Assert.That(Builder.ChangedUserOptions.ContainsKey(key));
            Assert.That(Builder.ChangedUserOptions[key], Is.True);

        }

        [Test(Description = "Стресстест добавления пользовательской настройки")]
        public void UserOptionStressTest()
        {
            string key = "safebrowsing.enabled";
            IWebDriver driver = Builder.SetUserOption(key, true)
                .SetUserOption(key, true)
                .Build();
            Assert.That(Builder.ChangedUserOptions.ContainsKey(key));
            Assert.That(Builder.ChangedUserOptions[key], Is.True);

        }

        [Test(Description = "Проверка изменения таймаута")]
        public void TimeoutTest()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(20);
            IWebDriver driver = Builder.WithTimeout(timeout).Build();
            Assert.That(driver.Manage().Timeouts().ImplicitWait, Is.EqualTo(timeout));
            Assert.That(Builder.Timeout, Is.EqualTo(timeout));

        }

        [Test(Description = "Проверка изменения URL")]
        public void URLTest()
        {
            string url = @"https://ib.psbank.ru/store/products/your-cashback-new";
            IWebDriver driver = Builder.WithURL(url).Build();
            Assert.That(driver.Url, Is.EqualTo(url));
            Assert.That(Builder.StartingURL, Is.EqualTo(url));

        }

        [Test(Description = "Комплексная проверка")]
        public void ComplexTest()
        {
            string url = @"https://ib.psbank.ru/store/products/your-cashback-new";
            string key = "safebrowsing.enabled";
            string argument = "--start-maximized";
            int port = new Random().Next(6000, 32000);
            TimeSpan timeout = TimeSpan.FromSeconds(20);
            IWebDriver driver = Builder.WithTimeout(timeout)
                .WithURL(url)
                .ChangePort(port)
                .SetArgument(argument)
                .SetUserOption(key, true)
                .Build();
            Assert.Multiple(() =>
            {
                Assert.That(driver.Manage().Timeouts().ImplicitWait, Is.EqualTo(timeout));
                Assert.That(Builder.Timeout, Is.EqualTo(timeout));
                Assert.That(driver.Url, Is.EqualTo(url));
                Assert.That(Builder.StartingURL, Is.EqualTo(url));
                Assert.IsTrue(Builder.ChangedArguments.Contains(argument));
                Assert.That(Builder.ChangedUserOptions.ContainsKey(key));
                Assert.That(Builder.ChangedUserOptions[key], Is.True);
            });

        }
    }
}