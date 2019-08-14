
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {  

        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.NewContactIfEmpty();
            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData toBeRemoved = oldContacts[0];

            app.Contact.DeleteContact(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData cont in newContacts)
            {
                Assert.AreNotEqual(cont.Id, toBeRemoved.Id);
            }
        }
    }
}
