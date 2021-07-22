using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibanachi
{
    public partial class Form1 : Form
    {
        Fibonachi[] fibArr;
        //расчет чисел фибаначчи
        //f(n) = f(n-1)+f(n-2)
        //1,1,2,3,5,8,13,21,...
        //f(0)=0 f(1)=1

        public Form1()
        {
            InitializeComponent(); 
        }

        private void clear()
        {
            label12.Text = "false";
            label11.Text = "false";
            label10.Text = "false";
            label9.Text = "false";
            label8.Text = "false";
            label7.Text = "false";
        }

        private void BT_rach_Click(object sender, EventArgs e) //операции над числами
        {
            Operation operation = new Operation();

            uint chisl1, chisl2, chisl3 =0;

            chisl1 = operation.radioButtonType(RB_chisl_fib1, RB_chisl_Dec1, textBox1.Text, 1);
            chisl2 = operation.radioButtonType(RB_chisl_fib2, RB_chisl_Dec2, textBox4.Text, 2);

            if (comboBox1.SelectedItem == "+")
                chisl3 = chisl1 + chisl2;
            else if (comboBox1.SelectedItem == "-")
                chisl3 = chisl1 - chisl2;
            else if (comboBox1.SelectedItem == "*")
                chisl3 = chisl1 * chisl2;
            else if (comboBox1.SelectedItem == "/") //проработать деление на 0
                chisl3 = chisl1 / chisl2;
            else
            {
                MessageBox.Show("Операция не выбрана");
            }

            textBox2.Text = operation.radioButtonRach(RB_chisl_fib3, RB_chisl_Dec3, chisl3);
        }

        private void BT_Otn_Click(object sender, EventArgs e) //отношения над числами
        {
            Operation operation = new Operation();

            uint chisl1, chisl2;
            chisl1 = operation.radioButtonType(RB_chisl_fib1, RB_chisl_Dec1, textBox11.Text, 1);
            chisl2 = operation.radioButtonType(RB_chisl_fib2, RB_chisl_Dec2, textBox10.Text, 2);

            Console.WriteLine(chisl1 + " " + chisl2);

            clear(); //очистка

            if (chisl1 > chisl2)
                label12.Text = "true";
            else if (chisl1 < chisl2)
                label11.Text = "true";

            if (chisl1 == chisl2)
                label10.Text = "true";

            if (chisl1 != chisl2)
                label9.Text = "true";

            if (chisl1 >= chisl2)
                label8.Text = "true";
            else if (chisl1 <= chisl2)
                label9.Text = "true";
        }

        private void buttonSTEPEN_Click(object sender, EventArgs e) //степень над числом
        {
            Fibonachi fibanachi = new Fibonachi();
            Operation operation = new Operation();
            uint chisl, stepen;
            double rash = 0;
            bool correctFIB, correctFIB1;

            string chisl_ = fibanachi.ConvertToDEC_byte(textBox14.Text, out correctFIB);
            chisl = Convert.ToUInt32(chisl_);
            string stepen_ = fibanachi.ConvertToDEC_byte(textBox13.Text, out correctFIB);
            stepen = Convert.ToUInt32(stepen_);

            Fibonachi fib1 = Fibonachi.ConvertToDEC(textBox14.Text, out correctFIB); //число
            Fibonachi fib2 = Fibonachi.ConvertToDEC(textBox13.Text, out correctFIB1); //степень

            if(correctFIB == true & correctFIB1 == true)
            {
                rash = Math.Pow(fib1.Znach, fib2.Znach);//chisl ^ stepen;
            }

            textBox12.Text = operation.radioButtonRach(radioButton8, radioButton7, (uint)rash);

            Console.WriteLine(rash);
        }

        #region Методы конвертации
        private void BTconvertToFib_Click(object sender, EventArgs e) //перевод в Фибоначчи(имеется переполнение)
        {
            uint znach = Convert.ToUInt32(textBox5.Text);
            Fibonachi fib = Fibonachi.ConvertToFIB(znach);

            textBox7.Text = fib.St_znach;
        }
        private void BTconvertToDec_Click(object sender, EventArgs e)//проверка, является ли числом Фибоначчи
        {
            bool ifFIB;
            Fibonachi fib = Fibonachi.ConvertToDEC(textBox6.Text, out ifFIB);
            if (ifFIB == false)
            {
                label5.Text = "Не является числом Фибоначчи";
            }
            else
            {
                label5.Text = fib.Znach.ToString();
            }
        }

        #endregion

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            Fibonachi.fibArr.Clear();

            for (int i=0; i<10; i++)
            {
                Fibonachi fib_ = new Fibonachi();
                fib_ = Fibonachi.ConvertToFIB(fib_.Znach);
                Thread.Sleep(50); //задержка необходима, для генерации Random

                Fibonachi.fibArr.Add(fib_);//добавляем в List
            }
            fibArr = Fibonachi.fibArr.ToArray(); //приводим к массиву

            dataGridView1.DataSource = Fibonachi.fibArr;
        }

        private void buttonSortDown_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            FibonachiSortDown down = new FibonachiSortDown();
            Array.Sort(fibArr, down);

            dataGridView2.DataSource = fibArr;
        }

        private void buttonSortUp_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            FibonachiSortUp up = new FibonachiSortUp();
            Array.Sort(fibArr, up);

            dataGridView2.DataSource = fibArr;
        }
    }
}
