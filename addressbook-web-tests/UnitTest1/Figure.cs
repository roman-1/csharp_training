using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class Figure
    {
        private bool colored = false;

        public bool Colored // - Проперти  (спец констр для сеттеров )
        {
            get
            {
                return colored;
            }

            set
            {
                colored = value;
            }
        }

    }
}
