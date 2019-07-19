﻿
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GotoGroupsPage();
            groupHelper.NewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Footer = "fff";
            group.Header = "ddd";
            groupHelper.FillGroupForm(group);
            groupHelper.Submit();
            navigator.GotoGroupsPage();
            loginHelper.Logout();

        }

    }
}
