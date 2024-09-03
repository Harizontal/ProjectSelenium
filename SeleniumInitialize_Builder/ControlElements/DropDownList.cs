using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;

namespace SeleniumInitialize_Builder.ControlElements
{
    public class DropDownList
    {
        private IWebDriver _driver;
        private IWebElement _dropDownList;
        public DropDownList(IWebDriver driver, IWebElement dropDownList)
        {
            _driver = driver;
            _dropDownList = dropDownList;

        }
        public void SelectValueByTyping(string value, string dropDownValue = null)
        {
            _dropDownList.SendKeys(value);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var visible = _driver.FindElements(By.XPath("//div[@role='listbox']/mat-option")).LongCount() > 0;
            var textInfo = new CultureInfo("ru-RU").TextInfo;
            if (visible)
            {
                var listOptions = _driver.FindElements(By.XPath("//div[@role='listbox']/mat-option")).ToList();
                dropDownValue ??= listOptions.First(list => list.Text.Contains(textInfo.ToTitleCase(textInfo.ToLower(value))))?.Text;
                listOptions.First(list => list.Text.Contains(dropDownValue)).Click();
            }
        }
        public void SelectValueByClicking(string value = null)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _dropDownList.Click();
            var listOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@role='listbox']/mat-option")));
            var optionToSelect = value != null
            ? listOptions.First(list => list.Text.Contains(value))
            : listOptions.FirstOrDefault();
            optionToSelect.Click();
        }

        public string GetValueDropDownList()
        {
            if (_dropDownList.TagName == "input")
                return _dropDownList.GetAttribute("value");
            return _dropDownList.GetAttribute("textContent");
        }
    }
}
