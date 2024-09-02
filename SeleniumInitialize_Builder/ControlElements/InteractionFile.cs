using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumInitialize_Builder.ControlElements
{
    public class InteractionFile
    {
        private IWebDriver _driver;

        public InteractionFile(IWebDriver driver)
        {
            _driver = driver;
        }
        public bool CheckFileToDownload(string fileName, string titleFile)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var filePath = Path.Combine(@"C:\Downloads", fileName);
            wait.Until(d => File.Exists(filePath));
            using (PdfDocument pdfDocument = new(new PdfReader(filePath)))
            {
                var page = pdfDocument.GetPage(1);
                return PdfTextExtractor.GetTextFromPage(page).Contains(titleFile.Replace(" ", ""));
            }
        }
    }
}
