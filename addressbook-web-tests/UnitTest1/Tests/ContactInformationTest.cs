using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactHomePageInformation()
        {
            app.Contact.NewContactIfEmpty();

            ContactData fromTable = app.Contact.GetContactInformaionFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformaionFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactDetailsInformation()
        {
            app.Contact.NewContactIfEmpty();

            ContactData fromDetails = app.Contact.GetContactInformationFromDetails(0);
            ContactData fromForm = app.Contact.GetContactInformaionFromEditForm(0);

            Assert.AreEqual(fromDetails.AllInfo, fromForm.AllInfo);
        }
    }
}