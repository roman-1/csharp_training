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
    public class GroupHelper : HelperBase
    {


        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }


        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.GotoGroupsPage();
            NewGroupCreation();
            FillGroupForm(group);
            Submit();
            return this;
        }



        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GotoGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GotoGroupsPage();
            return this;

        }

        

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GotoGroupsPage();
            SelectGroup(p);
            DeleteGroup();
            manager.Navigator.GotoGroupsPage();
            manager.Auth.Logout();
            return this;

        }



        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click(); 
            return this;
        }


        public GroupHelper FillGroupForm(GroupData group) // Переменные string name, string header, string footer)
        {
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper NewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

    }
}
