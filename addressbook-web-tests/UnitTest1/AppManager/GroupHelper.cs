﻿using System;
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
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModificaton();
            manager.Navigator.GotoGroupsPage();
            return this;

        }

        private List<GroupData> groupCache = null;
       
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GotoGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }
                }
            }
            
            return new List<GroupData> (groupCache);
        }

        public GroupHelper SubmitGroupModificaton()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GotoGroupsPage();

            SelectGroup(p);
            RemoveGroup();
            manager.Navigator.GotoGroupsPage();
            return this;

        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("input[name='selected[]']")).Count;
            //return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.GotoGroupsPage();
            NewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GotoGroupsPage();

            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
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

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper NewGroupIfEmpty()
            {
            manager.Navigator.GotoGroupsPage();
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
