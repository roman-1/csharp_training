using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));

                foreach (IWebElement element in elements)
                {
                    IWebElement firstnames = element.FindElement(By.CssSelector("td:nth-child(3)")); // 1
                    IWebElement lastnames = element.FindElement(By.CssSelector("td:nth-child(2)")); // 2
                    contactCache.Add(new ContactData(firstnames.Text, lastnames.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    }
                    );
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformaionFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformaionFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        private List<ContactData> contactCache = null;

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }


        public ContactHelper FillContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            
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
            SubmitContactCreation();
            contactCache = null;
            manager.Navigator.GoToHomePage();
            return this;
        }


        public ContactHelper NewContactIfEmpty()
        {
            if (IsElementPresent(By.Name("selected[]")))   // проверка наличия контакта
            {
                return this;
            }
            {
                ContactData defaultContactData = new ContactData("Сергей", "Теплов");
                defaultContactData.Address = "Neverland";
                defaultContactData.HomePhone = "+7 (111) 111 22 33";
                defaultContactData.MobilePhone = "+7 (222) 333 22 11";
                defaultContactData.WorkPhone = "+7 (333) 333 22 11";
                defaultContactData.Email1 = "asdfasdf@mylo.ru";
                defaultContactData.Email2 = "asdfasdf@qweqwe.ru";
                defaultContactData.Email3 = "asdfasdf@post.com";
                CreateContact(defaultContactData);
            }
            return this;
        }



        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper DeleteContact(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            manager.Navigator.GoToHomePage();
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
