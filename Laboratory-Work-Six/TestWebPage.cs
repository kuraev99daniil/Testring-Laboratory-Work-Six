using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Laboratory_Work_Six
{
    [TestFixture]
    public class TestWebPage
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            var x = new ChromeOptions();

            x.AddArgument("--headless");
            x.AddArgument("--no-sandbox");

            driver = new ChromeDriver(x);
        }

        [Test]
        public void PerformPageOpening()
        {
            OpenMainPage();
        }

        [Test]
        public void PerformSearch()
        {
            OpenMainPage();

            IWebElement searchInput = driver.FindElement(By.Id("searchInput"));

            searchInput.Click();

            searchInput.SendKeys("Небо");

            searchInput.SendKeys(Keys.Enter);

            IWebElement firstHeading = driver.FindElement(By.Id("firstHeading"));

            Assert.AreEqual("Небо", firstHeading.Text);

            PerformDefaultSleep();
        }

        [Test]
        public void PerfromCheckingGooglePlayButton() 
        {
            OpenMainPage();

            IWebElement googlePlayElement = driver.FindElement(By.ClassName("app-badge-android"));

            Assert.IsTrue(googlePlayElement.Displayed);

            Assert.IsTrue(googlePlayElement.Enabled);

            googlePlayElement.Click();

            PerformDefaultSleep();
        }

        [Test]
        public void PerformCheckingAppStoreButton()
        {
            OpenMainPage();

            IWebElement googlePlayElement = driver.FindElement(By.ClassName("app-badge-ios"));

            Assert.IsTrue(googlePlayElement.Displayed);

            Assert.IsTrue(googlePlayElement.Enabled);

            googlePlayElement.Click();

            PerformDefaultSleep();
        }

        [Test]
        public void PerformOpeningEnglishArticles()
        {
            OpenMainPage();

            IWebElement englishArticlesElement = driver.FindElement(By.Id("js-link-box-en"));

            englishArticlesElement.Click();

            PerformDefaultSleep();
        }

        private void OpenMainPage()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }

        private void PerformDefaultSleep()
        {
            System.Threading.Thread.Sleep(5000);
        }

        [TearDown]
        protected void Close()
        {
            driver.Quit();
        }
    }
}
