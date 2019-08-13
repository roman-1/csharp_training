
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Fedor", "Potapov");
            app.Navigator.GoToHomePage();
            app.Contact.NewContactIfEmpty();

            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contact.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount()); //проверка изменения старого контакта

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData cont in newContacts)
            {
                if (cont.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, cont.Firstname);
                    Assert.AreEqual(newData.Lastname, cont.Lastname);
                }
            }

        }
 


    }
}
