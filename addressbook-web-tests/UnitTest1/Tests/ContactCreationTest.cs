﻿
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.NewContact();
            app.Contact.FillContactData(new ContactData("Иван", "Иванов"))
                .Submit();
        }




    }
}