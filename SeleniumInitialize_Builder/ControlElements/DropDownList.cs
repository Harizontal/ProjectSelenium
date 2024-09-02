using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        public void ChangeValueDropDownList(string value, string dropDownValue = null)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _dropDownList.SendKeys(value);
            var listOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@class,'mat-autocomplete-panel')]/mat-option")));
            dropDownValue ??= listOptions.First(list => list.Text.Contains(value)).Text;
            listOptions.First(list => list.Text.Contains(dropDownValue)).Click();
        }
        public string GetValueDropDownList()
        {
            return _dropDownList.GetAttribute("value");
        }
    }
}
