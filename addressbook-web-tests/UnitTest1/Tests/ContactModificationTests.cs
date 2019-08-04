
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GotoContacts();
            app.Contact.EditContact(5)
                .FillContactData(new ContactData("Дмитрий", "Сергеев"))
                .UpdateContact();



        }
 


    }
}
