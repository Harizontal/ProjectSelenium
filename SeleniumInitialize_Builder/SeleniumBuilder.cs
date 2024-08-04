using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumInitialize_Builder
{
    public class SeleniumBuilder : IDisposable
    {
        private IWebDriver WebDriver { get; set; }
        public int Port { get; private set; }
        public bool IsDisposed { get; private set; }
        public List<string> ChangedArguments { get; private set; }
        public Dictionary<string, object> ChangedUserOptions { get; private set; }
        public TimeSpan Timeout { get; private set; }
        public string StartingURL { get; private set; }
        public bool IsHeadless
        {
            get
            { return ChangedArguments != null && ChangedArguments.Contains("--headless"); }
        }

        public IWebDriver Build()
        {
            var service = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            // Возможность настроить порт
            if (Port != default)
                service.Port = Port;
            if (ChangedArguments != null)
                options.AddArguments(ChangedArguments);
            if (ChangedUserOptions != null)
            {
                foreach (var opt in ChangedUserOptions)
                {
                    options.AddAdditionalOption(opt.Key, opt.Value);
                }
            }
            WebDriver = new ChromeDriver(service, options);
            WebDriver.Manage().Timeouts().ImplicitWait = Timeout;
            if (!string.IsNullOrEmpty(StartingURL))
                WebDriver.Navigate().GoToUrl(StartingURL);
            return WebDriver;
        }

        public void Dispose()
        {
            //Закрыть браузер, очистить использованные ресурсы, по завершении переключить IsDisposed на состояние true
            WebDriver?.Quit();
            WebDriver?.Dispose();
            IsDisposed = true;
        }

        public SeleniumBuilder ChangePort(int port)
        {
            //Реализовать смену порта, на котором развёрнут IWebDriver для этого необходимо ознакомиться с классом DriverService соответствующего драйвера (ChromeDriverService для хрома)
            //Изменить свойство Port на тот порт, на который поменяли.
            //Builder в данном методе должен возвращать сам себя
            Port = port;
            return this;
        }

        public SeleniumBuilder SetArgument(string argument)
        {
            //Реализовать добавление аргумента. При решении данной задаче ознакомитесь с классом Options соответствующего драйвера (ChromeOptions для браузера Chrome)
            //Все изменённые/добавленные аргументы необходимо отразить в свойстве СhangedArguments, которое перед этим нужно где-то будет проинициализировать.
            //Builder в данном методе должен возвращать сам себя
            ChangedArguments ??= new List<string>();
            ChangedArguments.Add(argument);
            return this;
        }

        public SeleniumBuilder SetUserOption(string option, object value)
        {
            //Реализовать добавление пользовательской настройки.
            //Все изменения сохранить в свойстве ChangedUserOptions
            //Builder в данном методе должен возвращать сам себя
            ChangedUserOptions ??= new Dictionary<string, object>();
            if (!ChangedUserOptions.ContainsKey(option))
                ChangedUserOptions.Add(option, value);
            return this;
        }

        public SeleniumBuilder EditHeadless()
        {
            if (IsHeadless)
                ChangedArguments?.Remove("--headless");
            else
                ChangedArguments = ChangedArguments?.Append("--headless").ToList() ?? new List<string> { "--headless" };
            return this;
        }

        public SeleniumBuilder WithTimeout(TimeSpan timeout)
        {
            //Реализовать изменение изначального таймаута запускаемого браузера
            //Отслеживать изменения в свойстве Timeout
            //Builder возвращает себя
            Timeout = timeout;
            return this;
        }

        public SeleniumBuilder WithURL(string url)
        {
            //Реализовать изменения изначального URL запускаемого браузера
            //Отслеживать изменения в строке StartingURL
            //Builder возвращает себя
            StartingURL = url;
            return this;
        }
        /// <summary>
        /// Преобразует RGBA форммат в HEX
        /// </summary>
        /// <returns>Преобразованная строка в формате HEX</returns>
        public string RgbaToHex(string rgbaColor)
        {
            rgbaColor = rgbaColor.Substring(5, rgbaColor.Length - 6);
            string[] parts = rgbaColor.Split(',');

            int red = int.Parse(parts[0].Trim());
            int green = int.Parse(parts[1].Trim());
            int blue = int.Parse(parts[2].Trim());

            return string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
        }
        /// <summary>
        /// Метод для ожидание загрузки страницы
        /// </summary>
        public void WaitForPageLoad()
        {
            Thread.Sleep(500);
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5))
                 .Until(ExpectedConditions
                 .ElementIsVisible(By.XPath("//body/descendant::*[last()]")));
        }
    }
}