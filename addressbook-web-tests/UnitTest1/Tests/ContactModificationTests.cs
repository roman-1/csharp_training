
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
            app.Navigator.GoToHomePage();
            app.Contact.NewContactIfEmpty()
                .EditContact() // убрал номер редактируемого контакта
                .FillContactData(new ContactData("Дмитрий", "Сергеев"))
                .UpdateContact();  



        }
 


    }
}
