using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
       
        public ContactData(string firstname, string lastname)  
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other) // сравнение списков
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname; // сравнение по имени
        }


        public override int GetHashCode()
        {
            return Firstname.GetHashCode() ^ Lastname.GetHashCode(); //объединение
        }

        public override string ToString()
        {
            return "Firstname = " + Firstname + ", Lastname = " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) != 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Firstname.CompareTo(other.Firstname);
        }


        public string Firstname { get; set; }
       
        public string Lastname { get; set; }

        public string Id { get; set; }

    }
}
