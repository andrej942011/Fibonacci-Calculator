using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibanachi
{
    public class Base
    {
        protected uint znach; //Числовое представление
        protected string st_znach; //строковое представление числа Фибоначчи

        public uint Znach { get { return znach; } }
        public string St_znach { get { return st_znach; } }

        public Base() //Конструктор без параметров
        {
            Random rnd = new Random();

            znach = Convert.ToUInt32(rnd.Next(0, 200));
        }

        public Base(uint znach_)
        {
            znach = znach_;
        }

        public Base(string znach_)
        {
            st_znach = znach_;
        }
    }
}
