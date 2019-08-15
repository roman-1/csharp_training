
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest() 
        {
            ContactData contact = new ContactData("Алан", "Дзагоев");
            contact.Address = "Новокукуево, 89";
            contact.HomePhone = "+7(916) 8765432";
            contact.MobilePhone = "+7 (916) 87654321";
            contact.Email1 = "asdffdsa@mail.ru";
            contact.Email2 = "fdsafasd@hotbox.com";
            contact.Email3 = "hhhhhhhh@hotbox.com";

            List <ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void EpmtyContactCreationTest()
        {

            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.CreateContact(contact);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);




        }






    }
}
