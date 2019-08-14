
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactsTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.NewContact();
            app.Contact.FillContactData(new ContactData("Иван", "Иванов"))
                .Submit(); 
        }

        [Test]
        public void EpmtyContactCreationTest()
        {
            app.Navigator.NewContact();
            app.Contact.FillContactData(new ContactData("", ""))
                .Submit();
        }

        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GotoContacts();
            app.Contact.EditContact();

        }

        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GotoContacts();
            app.Contact.SelectContact(4);
            app.Contact.DeleteContact();

        }




    }
}
