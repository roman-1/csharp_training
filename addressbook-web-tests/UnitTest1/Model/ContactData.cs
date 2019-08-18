using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInfo;

        public ContactData(string allInfo)
        {
            AllInfo = allInfo;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }


        public bool Equals(ContactData other)//сравнение объектов и списков
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode() //оптимизация
        {
            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname = " + Firstname + "\nLastname = " + Lastname
                + "\nAddress = " + Address
                + "\nHomePhone = " + HomePhone + "\nMobilePhone = " + MobilePhone + "\nWorkPhone = " + WorkPhone
                + "\nEmail1 = " + Email1 + "\nEmail2 = " + Email2 + "\nEmail3 = " + Email3;

        }

        public int CompareTo(ContactData other)
        {
            string othernames = other.Firstname + other.Lastname;
            string names = Firstname + Lastname;
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return names.CompareTo(othernames);
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (PhoneCleanUp(HomePhone) + PhoneCleanUp(MobilePhone) + PhoneCleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }

        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (EmailModification(Email1) + EmailModification(Email2) + EmailModification(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    return (Firstname + " " + Lastname + "\r\n" + Address + "\r\n"
                        + PhoneModification(HomePhone, "H") + PhoneModification(MobilePhone, "M") + PhoneModification(WorkPhone, "W") + "\r\n"
                        + EmailModification(Email1) + EmailModification(Email2) + EmailModification(Email3)).Trim();
                }
            }
            set
            {
                allInfo = value;
            }
        }

        public string PhoneCleanUp(string phone)//  убираем лишние символы
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(phone, "[-( )]", "") + "\r\n";
            }
        }


        public string PhoneModification(string phone, string type)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                phone = $"\r\n{type}: {phone}";
                return phone;
            }

        }


        public string EmailModification(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                email = $"\r\n{email}";
                return email;
            }
        }

    }
}