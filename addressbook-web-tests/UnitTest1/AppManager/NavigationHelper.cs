using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; 


namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {

        protected string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GotoGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("new")))
            {   return;  }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            { return; }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void NewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GotoContacts()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }





    }
}
