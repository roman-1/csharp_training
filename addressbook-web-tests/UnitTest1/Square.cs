using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class Square : Figure

    {
        private int size;


        public Square(int size)  // Конструктор
        {
            this.size = size;
        }

        public int Size // - Проперти  (спец констр для сеттеров )
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }
    }
}
