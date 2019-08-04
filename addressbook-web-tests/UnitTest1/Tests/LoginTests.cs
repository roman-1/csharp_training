using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class LoginTests : TestBase
    {
        [Test]

        public void LogInWithValidCredentials()
        {
            app.Auth.Logout(); //prepare

            AccountData account = new AccountData("admin", "secret"); //data
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account)); //verification
        }

        [Test]

        public void LogInWithInvalidCredentials()
        {
            app.Auth.Logout(); //prepare

            AccountData account = new AccountData("admin", "123123"); //data
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account)); //verification
        }



    }
}
