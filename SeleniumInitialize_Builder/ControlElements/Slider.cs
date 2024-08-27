using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumInitialize_Builder.ControlElements
{
    public class Slider
    {
        private IWebDriver _driver;
        private IWebElement _slider;
        public Slider(IWebDriver driver, IWebElement slider)
        {
            _driver = driver;
            _slider = slider;
        }

        /// <summary>
        /// Метод для установки значения Slider
        /// </summary>
        /// <param name="value">Значение элемента slider</param>
        /// <param name="maxValue">Максимальное начение элемента slider</param>
        public void SetSliderValue(double value, double maxValue)
        {
            double position = (value / maxValue) * _slider.Size.Width;
            var actions = new Actions(_driver);
            actions.MoveToElement(_slider)
                   .ClickAndHold()
                   .MoveByOffset((-_slider.Size.Width / 2) + (int)position, 0)
                   .Perform();
        }

        public string GetValueSlider()
        {
            return _slider.GetAttribute("value");
        }
    }
}
