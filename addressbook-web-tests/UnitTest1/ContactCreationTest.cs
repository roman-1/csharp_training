﻿
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
    public class ContactCreationTests
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
           // Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            NewContact();
            FillContactData(new ContactData("Иван", "Иванов"));
            SubmitContactCreation();
        }

        private void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
        }

        private void FillContactData(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Surename);

        }

        private void NewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
