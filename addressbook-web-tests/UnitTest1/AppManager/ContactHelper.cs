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


        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']")); //список по css

            foreach (IWebElement element in elements)
            {
                IWebElement firstnames = element.FindElement(By.CssSelector("td:nth-child(3)")); // 1
                IWebElement lastnames = element.FindElement(By.CssSelector("td:nth-child(2)")); // 2

                contacts.Add(new ContactData(firstnames.Text, lastnames.Text));
            }
            return contacts;
        }







        public ContactHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        public ContactHelper FillContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }


        public ContactHelper SelectContact(int ind)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (ind+1) + "]")).Click();
            return this;
        }



        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }




        public ContactHelper CreateContact(ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            manager.Navigator.NewContact();
            FillContactData(newData);
            Submit();
            manager.Navigator.GoToHomePage();
            return this;
        }



        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();

            return this;
        }

        public ContactHelper DeleteContact(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.GoToHomePage();
            return this;

        }

        public ContactHelper NewContactIfEmpty()
        {
            if (IsElementPresent(By.Name("selected[]")))
            {
                return this;
            }
            {
                manager.Navigator.GoToHomePage();
                manager.Navigator.NewContact();
                FillContactData(new ContactData("Сергей", "Теплов"))
                    .Submit();
                manager.Navigator.GoToHomePage();   
            }
            return this;
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            FillContactData(newData);
            UpdateContact();
            manager.Navigator.GoToHomePage();
            return this;
        }





    }
}
