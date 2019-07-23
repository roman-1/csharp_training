
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GotoContacts();
            app.Contact.SelectContact(1)
                .EditContact()
                .FillContactData(new ContactData("Новик", "Новиков"))
                .SubmitContact();



        }
 


    }
}
