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
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.Surename);
            return this;
        }


        public ContactHelper SelectContact(int ind)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + ind + "]")).Click();
            return this;
        }



        public ContactHelper EditContact(int contact_num)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + contact_num + "]")).Click();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();

            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();


            return this;
        }

        public ContactHelper NewContactIfEmpty()
        {
            if (IsElementPresent(By.Name("selected[]")))
            {
                return this;
            }
            {
                manager.Navigator.NewContact();
                manager.Contact.FillContactData(new ContactData("Сергей", "Теплов"))
                    .Submit();
                manager.Navigator.GoToHomePage();   
            }
            return this;
        }





    }
}
