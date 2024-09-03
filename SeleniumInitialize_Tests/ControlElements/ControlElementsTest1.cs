using iText.Kernel.Pdf;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Builder.ControlElements;

namespace SeleniumInitialize_Tests.ControlElements
{
    public class ControlElementsTest1 : TestBaseSetUp
    {

        [Test(Description = "Проверка выбора другой категории")]
        public void SetValueSlider()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            var yearlyCashback = By.XPath("//*[contains(@class,'cashback-calculator-output__label-yearly-count')]");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Посчитайте свою выгоду с картой «Твой кешбэк»')]"));
            var valueYearlyCashback = driver.FindElement(yearlyCashback).Text;
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Хорошо')]/ancestor::psb-button"))).Click();
            var sliderElement = driver.FindElement(By.XPath("//div[./*[contains(text(),'Кафе и рестораны')]]/following-sibling::rui-slider"));
            var slider = new Slider(driver, sliderElement);
            slider.SetSliderValue(10000, 50000);
            Assert.That(driver.FindElement(yearlyCashback).Text, Is.Not.EqualTo(valueYearlyCashback));
        }

        [Test(Description = "Проверка выбора другой категории")]
        public void SelectAnotherCategory()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Посчитайте свою выгоду с картой «Твой кешбэк»')]"));
            driver.FindElement(By.XPath("//button[contains(@class,'change-categories-btn')]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h3[contains(text(),'Выберите 3 категории')]")));
            var buttonConfirmed = driver.FindElement(By.XPath("//button[contains(@class,'confirm-button')]"));
            var checkBoxElement = driver.FindElement(By.XPath("//li[./*[contains(text(), 'Кафе и рестораны')]]"));
            var checkBox = new CheckBox(driver, checkBoxElement);
            checkBox.SetCategory("Кафе и рестораны");
            checkBox.SetCategory("Аптеки, медицина");
            Assert.IsTrue(buttonConfirmed.Enabled);
            buttonConfirmed.Click();
            Assert.IsNotNull(driver.FindElements(By.XPath("//*[contains(text(),'Аптеки, медицина')]")).SingleOrDefault());
        }

        [Test(Description = "Проверка выбора значения из выпадающего списка")]
        public void ChangeValueFromDropDownList()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Заявка на карту')]"));
            var LastNameInput = driver.FindElement(By.XPath("//input[@name='CardHolderLastName']"));
            var dropDownList = new DropDownList(driver, LastNameInput);
            dropDownList.SelectValueByTyping("Пу", "Пушкин");
            var valueInputLastName = driver.FindElement(By.XPath("//input[@name='CardHolderLastName']")).GetAttribute("value");
            Assert.That(valueInputLastName, Is.EqualTo("Пушкин"));
        }
        [Test(Description = "Проверка выбора значения из выпадающего списка")]
        public void ChangeValueFromDropDownListe()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Заявка на карту')]"));
            var LastNameInput = driver.FindElement(By.XPath("//mat-select[@name='RussianFederationResident']"));
            var dropDownList = new DropDownList(driver, LastNameInput);
            dropDownList.SelectValueByClicking("РФ");
            Assert.That(dropDownList.GetValueDropDownList(), Is.EqualTo("РФ"));
        }

        [Test(Description = "Проверка установки даты с помощью DatePicker")]
        public void SetDateWithDatePicker()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            string date = "12.02.1983";

            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Заявка на карту')]"));
            driver.FindElement(By.XPath("//div[contains(@class,'rui-datepicker-form-field__calendar-icon')]")).Click();
            var datePickerElement = driver.FindElement(By.XPath("//mat-datepicker-content"));
            var datePicker = new DatePicker(driver, datePickerElement);
            datePicker.SetDateOfBirth(date);
            var inputDate = driver.FindElement(By.XPath("//input[contains(@class,'mat-datepicker-input')]"));
            Assert.That(inputDate.GetAttribute("value"), Is.EqualTo(date));
        }

        [Test(Description = "Проверка загрузки файла")]
        public void CheckdownloadFile()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            var file = new InteractionFile(driver);

            browser.WaitForPageLoad(By.XPath("//div[contains(@class,'documents')]"));
            driver.FindElement(By.XPath("//psb-document[.//h4[contains(text(), 'Дебетовая карта')]]")).Click();
            Assert.IsTrue(file.CheckFileToDownload("yc_short_tarifs.pdf", "Дебетовая карта «Твой кешбэк»"));
        }

        [Test(Description = "Проверка работы Expansion-panel показа ответа по соответсвующему вопросу")]
        public void CheckManagementExpansionPanel()
        {
            var driver = Builder.WithURL("https://ib.psbank.ru/store/products/your-cashback-new").SetArgument("--start-maximized").Build();
            var browser = Builder.Browser;
            browser.WaitForPageLoad(By.XPath("//h2[contains(text(),'Часто задаваемые вопросы')]"));
            var expansionalPanelElement = driver.FindElement(By.XPath("//rui-expansion-panel[.//*[contains(text(),'Как я могу получить кешбэк')]]"));
            var expansionalPanel = new ExpansionPanel(expansionalPanelElement);
            expansionalPanel.Open();
            Assert.IsTrue(expansionalPanel.GetAnswer().Contains("Оплачивайте покупки на сумму от 10 000 ₽ в месяц."));
        }
    }
}

