using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibanachi
{
    public class Operation
    {
        public uint radioButtonType(RadioButton rbFIB, RadioButton rbDEC, string input, int numChisl) // для первых 2 чисел
        {
            //Fibonachi fibanachi = new Fibonachi();
            uint output = 0;

            //if (rbFIB.Checked & !rbDEC.Checked) //Если число Фибоначчи, то преобразуем его в 10 вид
            //{
            //    //bool ifFIB;
            //    //output = fibanachi.ConvertToDEC_byte(input, out ifFIB);
            //}
            //else if (!rbFIB.Checked & rbDEC.Checked) //если число 10, то оставим как есть
            //{
            //    //output = input; //нужна проверка
            //}
            //else
            //{
            //    //output = "0";
            //    MessageBox.Show($"Выбитите тип для {numChisl} числа");
            //}

            //
            Fibonachi fib;
            if (rbFIB.Checked & !rbDEC.Checked)
            {
                bool ifFib;
                fib = Fibonachi.ConvertToDEC(input, out ifFib);
                if (ifFib == true)
                    output = fib.Znach;
                else
                    MessageBox.Show("Ошибка ввода");
            }
            else if (!rbFIB.Checked & rbDEC.Checked)
            {
                output = Convert.ToUInt32(input);
            }

            return output;
        }

        public string radioButtonRach(RadioButton rbFIB, RadioButton rbDEC, uint input) //для расчета
        {
            //Fibonachi fibanachi = new Fibonachi();
            string output = "";

            //if (rbFIB.Checked & !rbDEC.Checked) //если на выходе нам нужно число Фибоначчи
            //{
            //    output = fibanachi.ConvertToFib_byte(input);
            //}
            //else if (!rbFIB.Checked & rbDEC.Checked) //если нужно на выходе 10 число
            //{
            //    output = input.ToString(); //нужна проверка
            //}
            Fibonachi fib;
            if (rbFIB.Checked & !rbDEC.Checked)
            {
                fib = Fibonachi.ConvertToFIB(input);
                output = fib.St_znach;
            }
            else if (!rbFIB.Checked & rbDEC.Checked) //если нужно на выходе 10 число
            {
                output = input.ToString(); //нужна проверка
            }

            return output;
        }
    }
}
