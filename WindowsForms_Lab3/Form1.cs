using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Fraction Drop1 = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text));
                Fraction Drop2 = new Fraction(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox2.Text));
                Fraction Drop = new Fraction();

                switch (comboBox1.Text)
                {
                    case "+":
                        if (Convert.ToInt32(textBox3.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0)
                            MessageBox.Show("В знаменателе не может быть 0!");
                        Drop = Drop1 + Drop2;
                        richTextBox1.Text += Drop + "\n";
                        richTextBox1.Text += "\nСокращенная:\n";
                        Drop.Simplify();
                        richTextBox1.Text += "\n" + Drop;
                        break;
                    case "-":
                        if (Convert.ToInt32(textBox3.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0)
                            MessageBox.Show("В знаменателе не может быть 0!");
                        Drop = Drop1 - Drop2;
                        richTextBox1.Text += Drop + "\n";
                        richTextBox1.Text += "\nСокращенная:\n";
                        Drop.Simplify();
                        richTextBox1.Text += "\n" + Drop;
                        break;
                    case "*":
                        if (Convert.ToInt32(textBox3.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0)
                            MessageBox.Show("В знаменателе не может быть 0!");
                        Drop = Drop1 * Drop2;
                        richTextBox1.Text += Drop + "\n";
                        richTextBox1.Text += "\nСокращенная:\n";
                        Drop.Simplify();
                        richTextBox1.Text += "\n" + Drop;
                        break;
                    case "/":
                        if (Convert.ToInt32(textBox3.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0)
                            MessageBox.Show("В знаменателе не может быть 0!");
                        Drop = Drop1 / Drop2;
                        richTextBox1.Text += Drop + "\n";
                        richTextBox1.Text += "\nСокращенная:\n";
                        Drop.Simplify();
                        richTextBox1.Text += "\n" + Drop;
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

    class Fraction
    {
        int numerator;
        int denomirator;

        public int Numerator { get => numerator; set => numerator = value; }
        public int Denomirator { get => denomirator; set => denomirator = (value != 0 ? value : 1); }

        public Fraction()
        {
            this.denomirator = 1;
        }

        public Fraction(int numerator)
        {
            this.numerator = numerator;
            this.denomirator = 1;
        }

        public Fraction(int numerator, int denomirator) : this(numerator)
        {
            Denomirator = denomirator;
        }

        override public String ToString()
        {
            return " " + this.numerator + "\n-----\n" + " " + this.denomirator;
        }

        public static Fraction operator +(Fraction drop1, Fraction drop2)
        {
            Fraction temp = new Fraction();

            temp.denomirator = drop1.denomirator * drop2.denomirator;
            temp.numerator = drop1.numerator * drop2.denomirator + drop2.numerator * drop1.denomirator;

            return temp;
        }

        public static Fraction operator -(Fraction drop1, Fraction drop2)
        {
            Fraction temp = new Fraction();

            temp.denomirator = drop1.denomirator * drop2.denomirator;
            temp.numerator = drop1.numerator * drop2.denomirator - drop2.numerator * drop1.denomirator;

            return temp;
        }

        public static Fraction operator *(Fraction drop1, Fraction drop2)
        {
            Fraction temp = new Fraction();

            temp.numerator = drop1.numerator * drop2.numerator;
            temp.denomirator = drop1.denomirator * drop2.denomirator;

            return temp;
        }

        public Fraction Reverse()
        {
            Fraction temp = new Fraction();

            temp.numerator = this.denomirator;
            temp.denomirator = this.numerator;

            return temp;
        }

        public static Fraction operator /(Fraction drop1, Fraction drop2)
        {
            Fraction temp = new Fraction();

            temp = drop1 * drop2.Reverse();

            return temp;
        }

        public void Simplify()
        {
            int tNumerator = this.numerator;
            int tDenominator = this.denomirator;

            if (tDenominator % tNumerator == 0)
            {
                denomirator /= numerator;
                numerator = 1;
                return;
            }

            for (int i = 2; i < tNumerator; i++)
            {
                if (tNumerator % i == 0 && tDenominator % i == 0)
                {
                    tNumerator /= i;
                    tDenominator /= i;
                    i--;
                }
            }

            this.numerator = tNumerator;
            this.denomirator = tDenominator;
        }
    }
}
