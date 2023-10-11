using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task20.Controls;

namespace Task20
{
    public class Tests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Test1()
        {
            LoginInput login = new LoginInput();

            //// Doing login from the demo page. NOTE: this page is often unreachable
            //driver.Navigate().GoToUrl("https://phptravels.com/demo");
            //var loginBtn = driver.FindElement(login.ByLinkedText);
            //loginBtn.Click();

            //driver.SwitchTo().Window(driver.WindowHandles.Last());

            driver.Navigate().GoToUrl("https://phptravels.org/");

            var loginInput = driver.FindElement(login.ByXpath);
            loginInput.SendKeys("mycoolemail@gmail.com");

            var passwordInput = driver.FindElement(By.XPath("//input[@name='password']"));
            passwordInput.SendKeys("z!SuiDzaw9oj");

            // Can't automate captcha, so just verify that alert is displayed
            //var captchaChk = driver.FindElement(By.XPath("//div[@id='google-recaptcha-domainchecker1']"));
            //captchaChk.Click();

            var loginButton = driver.FindElement(By.XPath("//button[@id='login']"));
            loginButton.Click();

            var alertLabel = driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));

            // Login process won't complete because it is needed to handle captcha input, so I have to verify that alert is displayed
            Assert.IsTrue(alertLabel.Displayed, "Error: alert is not displayed!");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}