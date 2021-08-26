using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NE_PO_GODAM_YMEN
{

    public partial class Form1 : Form
    {
        public string result;
        public int A10;
        public int B10;
        public string A2;
        public string B2;
        public int lenth_1;
        public int lenth_2;
        public string rez = "0000000000000000";
        public Form1()
        {
            InitializeComponent();
        }

        //Функция перевода в 10ую
        static int BinaryToDecimal(string binaryNumber)
        {
            int exponent = 0;
            int result = 0;
            for (var i = binaryNumber.Length - 1; i >= 0; i--)
            {
                if (binaryNumber[i] == '1')
                {
                    result += Convert.ToInt32(Math.Pow(2, exponent));
                }
                exponent++;
            }

            return result;
        }

        private string Add(string x, string y)
        {
            string z = "";
            char p = '0';//Перенос при сложении двух разрядов
            for (int i = y.Length - 1; i >= 0; i--)
            {
               // MessageBox.Show( " " + i);
                if (y[i] == '0' && x[i] == '0' && p == '0') { z = '0' + z; p = '0'; continue; }
                if (y[i] == '0' && x[i] == '0' && p == '1') { z = '1' + z; p = '0'; continue; }
                if (y[i] == '1' && x[i] == '0' && p == '0') { z = '1' + z; p = '0'; continue; }
                if (y[i] == '1' && x[i] == '0' && p == '1') { z = '0' + z; p = '1'; continue; }
                if (y[i] == '0' && x[i] == '1' && p == '0') { z = '1' + z; p = '0'; continue; }
                if (y[i] == '0' && x[i] == '1' && p == '1') { z = '0' + z; p = '1'; continue; }
                if (y[i] == '1' && x[i] == '1' && p == '0') { z = '0' + z; p = '1'; continue; }
                if (y[i] == '1' && x[i] == '1' && p == '1') { z = '1' + z; p = '1'; continue; }
            }
            return z;
        }

        public void Ymnojenie(string a2, string b2)
        {
            lenth_1 = a2.Length;
            for (; lenth_1 < 16; lenth_1++)
            {
                a2 = a2.Insert(0, "0");
            }
          // textBox3.Text = a2;

            lenth_2 = b2.Length;
            for (; lenth_2 < 16; lenth_2++)
            {
                b2 = b2.Insert(0, "0");
            }
            //textBox4.Text = b2;


            for (int i = b2.Length - 1; i >= 0; i--)
            {
                if (b2[i] == '1') rez = Convert.ToString(Add(rez, a2));

                a2 = a2 + '0'; // Это сдвиг
                a2 = a2.Substring(1);
                // MessageBox.Show(" " + a2);
            }
            result = Convert.ToString(BinaryToDecimal(Convert.ToString(rez)));          
            MessageBox.Show(" " + result);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            A10 = Convert.ToInt32(textBox1.Text);
            B10 = Convert.ToInt32(textBox2.Text);


            if (A10 >= 0)
            {
                textBox3.Text = ("0." + A2);
            }
            else if (B10 >= 0)
            {
                textBox4.Text = ("0." + B2);
            }
            else if (A10 < 0)
            {
                textBox3.Text = ("1." + A2);
            }
            else if (B10 < 0)
            {
                textBox4.Text = ("1." + B2);
            }

            if (A10<0 && B10 < 0)
            {
                A10 = -A10;
                B10 = -B10;

                A2 = Convert.ToString(A10, 2);
                // textBox3.Text = A2;
                B2 = Convert.ToString(B10, 2);
                // textBox4.Text = B2;
                Ymnojenie(A2, B2);

                textBox3.Text = ("1." + A2);
                textBox4.Text = ("1." + B2);
                textBox5.Text = Convert.ToString(result);
                textBox6.Text = Convert.ToString("0." + rez);
            } else if (A10>=0 && B10<0)
            {
                B10 = -B10;

                A2 = Convert.ToString(A10, 2);
                // textBox3.Text = A2;
                B2 = Convert.ToString(B10, 2);
                // textBox4.Text = B2;
                Ymnojenie(A2,B2);

                textBox3.Text = ("0." + A2);
                textBox4.Text = ("1." + B2);
                textBox5.Text = Convert.ToString("-" + result);
                textBox6.Text = Convert.ToString("1." + rez);
            }
            else if (A10 < 0 && B10 >= 0)
            {
                A10 = -A10;

                A2 = Convert.ToString(A10, 2);
                // textBox3.Text = A2;
                B2 = Convert.ToString(B10, 2);
                // textBox4.Text = B2;
                Ymnojenie(A2, B2);

                textBox3.Text = ("1." + A2);
                textBox4.Text = ("0." + B2);
                textBox5.Text = Convert.ToString("-" + result);
                textBox6.Text = Convert.ToString("1." + rez);
            }
            else if (A10 >= 0 && B10 >= 0)
            {
 
                A2 = Convert.ToString(A10, 2);
                // textBox3.Text = A2;
                B2 = Convert.ToString(B10, 2);
                // textBox4.Text = B2;
                Ymnojenie(A2, B2);

                textBox3.Text = ("0." + A2);
                textBox4.Text = ("0." + B2);
                textBox5.Text = Convert.ToString(result);
                textBox6.Text = Convert.ToString("0." + rez);
            }
            rez = "0000000000000000";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            A10 = 0;
            B10 = 0;
            rez = "0000000000000000";

        }
    }
}
