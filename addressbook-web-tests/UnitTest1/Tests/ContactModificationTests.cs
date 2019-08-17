
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
            newData.Address = "Doorlandia";
            newData.HomePhone = "+7(888) 8887799";
            newData.MobilePhone = "+7 (456) 654 654";
            newData.WorkPhone = "111122223333";
            newData.Email1 = "webeburning.net";
            newData.Email2 = "notconcerning.net";
            newData.Email3 = "whatnobodywannasay.net";

            app.Navigator.GoToHomePage();
            app.Contacts.CreateIfContactNotCreated(0);

            List<ContactData> oldContacts = app.Contacts.GetContactList(); //создаем список старых данных и изменяем контакт
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount()); //проверка изменения старого контакта

            List<ContactData> newContacts = app.Contacts.GetContactList();
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
