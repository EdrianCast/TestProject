using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace TestProject
{
    public class Tests : IDisposable
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://admlucid.com");
            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/"));
            Assert.That(driver.Title, Is.EqualTo("Home Page - Admlucid"));
        }

        [Test]
        public void TestBox()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Id("Text1")).Clear();
            driver.FindElement(By.Id("Text1")).SendKeys("adm123456"); 
        }

        [Test]
        public void TestArea()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Id("TextArea2")).Clear();
            driver.FindElement(By.Id("TexteArea2")).SendKeys("If you want to create robust, browser");
        }

        [Test]
        public void Button()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Id("Button1")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void RadioButtonCheckBox()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Id("Checkbox1")).Click();
            driver.FindElement(By.Name("Radio2")).Click();
        }

        [Test]
        public void FileInput()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.CssSelector("#File")).SendKeys(@"");
        }

        [Test]
        public void FormSubmit()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Name("Name")).SendKeys("Jurado Angel");
            driver.FindElement(By.Name("Email")).SendKeys("AngelJuradoC@gmail.com");
            driver.FindElement(By.Name("Telephone")).SendKeys("6864044483");
            driver.FindElement(By.Name("Gender")).Click();

            var selectElement = driver.FindElement(By.Name("Age"));
            var select = new SelectElement(selectElement); select.SelectByText("4");

            var selectElement2 = driver.FindElement(By.Name("Servie"));
            var select2 = new SelectElement(selectElement2); select2.SelectByText("Child Care");

            driver.FindElement(By.Name("Submit")).Submit();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void multiplewind()
        {
            string originalWin = driver.CurrentWindowHandle;
            driver.Navigate().GoToUrl("https://www.alberta.ca/child-care-subsidy#jumpslinks-4");
            driver.FindElement(By.LinkText("online subsidy estimator"));
            foreach (string window in driver.WindowHandles)
            {
                if (originalWin != window) ;
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            //diver.Manage().Timeouts().ImpliciWait = TimeSpan.FromSeconds(5);
            Assert.That(driver.FindElement(By.XPath("/html/body/form/div/div[2]/h1")).Text, Is.EqualTo("Child Care Subsidy Estimator"));

            /* WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
             * Assert.That(wait.Until(ExpectedConditions.ElementIsVisisble(By.XPath("/html/body/form/div/div[2]/h1"))).Text, IsEqualTo("Child Care Subsidy Estimator)); */
        }

        [Test]
        public void WebElementText()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Assert.That(driver.FindElement(By.XPath("/html/body/div/main/h1")).Text, Is.EqualTo("Web Elements and Locators"));
            Assert.That(driver.FindElement(By.XPath("/html/body/div/main/h2[1]")).Text, Is.EqualTo("CHILD CARE REGISTRATION"));
        }
        [TearDown]
        public void TearDown()
        {
            Dispose();
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}