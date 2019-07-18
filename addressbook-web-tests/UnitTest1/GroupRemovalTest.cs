using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests
    {
        private IWebDriver driver;
        private string baseURL;


        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"C:\Drivers\chromedriver_win32-75\");
            baseURL = "http://localhost/addressbook/";
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupRemovalTest()
        {
            GoToHomePage();
            Login();
            GotoGroupsPage();
            SelectGroup();
            DeleteGroup();
            GotoGroupsPage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        private void SelectGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[1]")).Click();
        }

        private void GotoGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login()
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).SendKeys("admin");
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).SendKeys("secret");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
