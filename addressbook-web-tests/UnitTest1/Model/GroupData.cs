using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        
        private string header = "";
        private string footer;
         
        public GroupData(string name) // конструктор 
        {
            Name = name;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;

        }

        public override int GetHashCode()    // когда в обычн библ идет сравнение, то идет сравнение Хеш-кодов. Но после сравнения хешкодов идет сравнение методом Equals.
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }



        public string Name { get; set; } // свойства - геттеры сеттеры
       
        public string Header { get; set; }
        
        public string Footer { get; set; }
        
        public string Id { get; set; }
    }
}
