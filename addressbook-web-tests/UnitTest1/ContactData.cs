using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string name;
        private string surename;

        public ContactData(string name, string surename)
        {
            this.name = name;
            this.surename = surename;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Surename
        {
            get
            {
                return surename;
            }

            set
            {
                surename = value;
            }


        }




    }
}
