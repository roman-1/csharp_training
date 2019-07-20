﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
 

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData ("admin","secret"));
            app.Navigator.GotoGroupsPage();
            app.Group.SelectGroup(1);
            app.Group.DeleteGroup();
            app.Navigator.GotoGroupsPage();
            app.Auth.Logout();
        }

    }
}
