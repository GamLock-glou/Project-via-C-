using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fraction_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            label1.Text = "+";
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            label1.Text = "-";
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            label1.Text = "*";
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            label1.Text = "/";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            condition();

        }

        void condition()
        {
            Chet c = new Chet(Convert.ToInt32(integer1.Text), Convert.ToInt32(integer2.Text),
                Convert.ToInt32(dividend1.Text), Convert.ToInt32(dividend2.Text),
                Convert.ToInt32(divider1.Text), Convert.ToInt32(divider1.Text));
            (int,int,int) i = c.signs(label1.Text);
            dividend3.Text = $"{i.Item1}";
            divider3.Text = $"{i.Item2}";
            integer3.Text = $"{i.Item3}";

            if (integer3.Text == "0")
                integer3.Text = "";
            if (dividend3.Text == "0")
            {
                dividend3.Text = "";
                divider3.Text = "";
            }


            /*
            try
            {
                int i_n1 = Convert.ToInt32(integer1.Text), i_n2 = Convert.ToInt32(integer2.Text); //Целые числа
                int dev_d1 = Convert.ToInt32(dividend1.Text), dev_d2 = Convert.ToInt32(dividend2.Text);//Делимые
                int dev_r1 = Convert.ToInt32(divider1.Text), dev_r2 = Convert.ToInt32(divider2.Text); //Делители
                int dev_r_CA = dev_r1 * dev_r2; //Делитель ср_ар
                int SM_dev_d1 = (i_n1 * dev_r1 + dev_d1) * dev_r2; //Делимое 1 (for + and -)
                int SM_dev_d2 = (i_n2 * dev_r2 + dev_d2) * dev_r1; //Делимое 2 (for + and -)
                //____________________________________
                int M_dev_d = (i_n1 * dev_r1 + dev_d1) * (i_n2 * dev_r2 + dev_d2);
                int M_dev_r = dev_r1 * dev_r2;
                //____________________________________
                int D_dev_d = (i_n1 * dev_r1 + dev_d1) * dev_r2;
                int D_dev_r = (i_n2 * dev_r2 + dev_d2) * dev_r1;
                //____________________________________
                if (label1.Text == "+")
                {
                    dividend3.Text = $"{(SM_dev_d1 + SM_dev_d2) % (dev_r_CA)}";
                    divider3.Text = $"{dev_r_CA}";
                    integer3.Text = $"{(SM_dev_d1 + SM_dev_d2) / dev_r_CA}";
                }
                else
                if (label1.Text == "-")
                {
                    dividend3.Text = $"{(SM_dev_d1 - SM_dev_d2) % dev_r_CA}";
                    divider3.Text = $"{dev_r_CA}";
                    integer3.Text = $"{(SM_dev_d1 - SM_dev_d2) / dev_r_CA}";
                }
                else
                if (label1.Text == "*")
                {
                    dividend3.Text = $"{M_dev_d % M_dev_r}";
                    divider3.Text = $"{M_dev_r}";
                    integer3.Text = $"{(M_dev_d) / M_dev_r}";
                }
                else
                if (label1.Text == "/")
                {
                    dividend3.Text = $"{D_dev_d % D_dev_r}";
                    divider3.Text = $"{D_dev_r}";
                    integer3.Text = $"{D_dev_d / D_dev_r}";
                }
                if (integer3.Text == "0")
                    integer3.Text = "";
            }
            catch (Exception)
            { label6.Text = "Ошибка: Заполните все ячейки!"; } */
        }

    }

    class Chet
    {
        public int integer1 { get; set; }
        public int integer2 { get; set; }


        public int dividend1 { get; set; }
        public int dividend2 { get; set; }

        public int divider1 { get; set; }
        public int divider2 { get; set; }


        public Chet(int integer1, int integer2, int dividend1, int dividend2,
            int divider1, int divider2)
        {
            this.integer1 = integer1;
            this.integer2 = integer2;
            this.dividend1 = dividend1;
            this.dividend2 = dividend2;
            this.divider1 = divider1;
            this.divider2 = divider2;
        }

        public (int, int, int) signs(string s)
        {
            if (s == "+")
                return sum();
            else if (s == "-")
                return den();
            else if (s == "*")
                return mult();
            else if (s == "/")
                return diff();
            else
                return (0,0,0);
        }
        public (int, int, int) sum()
        {
            int dev_r_CA = divider1 * divider2; //Делитель ср_ар
            int SM_dev_d1 = (integer1 * divider1 + dividend1) * divider2; //Делимое 1 (for + and -)
            int SM_dev_d2 = (integer2 * divider2 + dividend2) * divider1; //Делимое 2 (for + and -)
            return ((SM_dev_d1 + SM_dev_d2) % (dev_r_CA), dev_r_CA, (SM_dev_d1 + SM_dev_d2) / dev_r_CA);
        }

        public (int, int, int) den()
        {
            int dev_r_CA = divider1 * divider2; //Делитель ср_ар
            int SM_dev_d1 = (integer1 * divider1 + dividend1) * divider2; //Делимое 1 (for + and -)
            int SM_dev_d2 = (integer2 * divider2 + dividend2) * divider1; //Делимое 2 (for + and -)
            return ((SM_dev_d1 - SM_dev_d2) % dev_r_CA, dev_r_CA, (SM_dev_d1 - SM_dev_d2) / dev_r_CA);
        }

        public (int, int, int) mult()
        {
            int M_dev_d = (integer1 * divider1 + dividend1) * (integer2 * divider2 + dividend2);
            int M_dev_r = divider1 * divider2;
            return (M_dev_d % M_dev_r, M_dev_r, (M_dev_d) / M_dev_r);
        }

        public (int, int, int) diff()
        {
            int D_dev_d = (integer1 * divider1 + dividend1) * divider2;
            int D_dev_r = (integer2 * divider2 + dividend2) * divider1;
            return (D_dev_d % D_dev_r, D_dev_r, D_dev_d / D_dev_r);
        }
    }
}
