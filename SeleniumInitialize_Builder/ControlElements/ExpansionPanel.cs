using OpenQA.Selenium;

namespace SeleniumInitialize_Builder.ControlElements
{
    public class ExpansionPanel
    {
        private IWebElement _expansionalPanel;

        public ExpansionPanel(IWebElement expansionalPanel)
        {
            _expansionalPanel = expansionalPanel;
        }
        public void Open()
        {
            if (!_expansionalPanel.FindElement(By.XPath(".//*[contains(@class,'expansion-panel-body')]")).Displayed)
                _expansionalPanel.FindElement(By.XPath($".//psb-icon")).Click();
        }
        public void Close()
        {
            if (_expansionalPanel.FindElement(By.XPath(".//*[contains(@class,'expansion-panel-body')]")).Displayed)
                _expansionalPanel.FindElement(By.XPath($".//psb-icon")).Click();
        }

        public string GetAnswer()
        {
            return _expansionalPanel.FindElement(By.XPath(".//*[contains(@class,'answer')]")).Text;
        }
    }
}
                
