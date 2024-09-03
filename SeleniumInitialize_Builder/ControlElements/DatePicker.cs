using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace SeleniumInitialize_Builder.ControlElements
{
    public class DatePicker
    {
        private IWebDriver _driver;
        private IWebElement _datePikcer;
        public DatePicker(IWebDriver driver, IWebElement datePicker)
        {
            _driver = driver;
            _datePikcer = datePicker;
        }

        /// <summary>
        /// Метод установки даты рождения
        /// </summary>
        /// <param name="dateOfBirth">Строка в формате "дд.мм.гггг"</param>
        public void SetDateOfBirth(string dateOfBirth)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _driver.FindElement(By.XPath("//rui-datepicker[.//*[contains(@class,'mat-datepicker-input')]]//rui-icon")).Click();
            string[] dateParts = dateOfBirth.Split('.');
            string day = dateParts[0];
            string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(dateParts[1])).Substring(0, 3).ToUpper();
            string year = dateParts[2];
            SetValueDate(year);
            SetValueDate(month);
            SetValueDate(day);
        }

        private void SetValueDate(string time)
        {
            var ListTime = _driver.FindElements(By.XPath("//td[contains(@class,'mat-calendar-body-cell')]"));
            var targetYearElement = ListTime.FirstOrDefault(e => e.Text.Contains(time));
            if (targetYearElement != null)
                targetYearElement.Click();
        }

        public string GetValueDataPicker()
        {
            return _datePikcer.GetAttribute("value");
        }
    }
}
