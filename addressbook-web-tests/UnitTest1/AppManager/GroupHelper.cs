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


        public GroupHelper Modify(int p, GroupData newData)
        {

            manager.Navigator.GotoGroupsPage();
            NewGroupIfEmpty();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModificaton();
            manager.Navigator.GotoGroupsPage();
            return this;

        }

        private void SubmitGroupModificaton()
        {
            driver.FindElement(By.Name("update")).Click();
        }

        private void InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GotoGroupsPage();
            NewGroupIfEmpty();
            SelectGroup(p);
            DeleteGroup();
            manager.Navigator.GotoGroupsPage();
            manager.Auth.Logout();
            return this;

        }


        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.GotoGroupsPage();
            NewGroupCreation();
            FillGroupForm(group);
            Submit();

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


        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            
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

        public GroupHelper NewGroupIfEmpty()
            {
                if (IsElementPresent(By.Name("selected[]")))
                {
                        return this;
                }
            { GroupData group = new GroupData("AAAAAAA");
                group.Footer = "BBBBBB";
                group.Header = "CCCCCC";
                CreateGroup(group);
                manager.Navigator.GotoGroupsPage(); 
            }
                return this;
            }



    }
}
