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
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        public ContactHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }



        public ContactHelper FillContactData(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Surename);
            return this;
        }




    }
}
