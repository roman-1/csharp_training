
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    { 

        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GotoContacts();
            app.Contact.SelectContact(1);
            app.Contact.DeleteContact();

        }




    }
}
