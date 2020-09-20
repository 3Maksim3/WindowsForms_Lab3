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
            //  Проверяем на обишки и корректность вводимых значений
            try
            {  
                Fraction Drop1 = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text)); // Создаем объект класса и передаем ему значения знаменателя и числителя
                Fraction Drop2 = new Fraction(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox2.Text)); // Создаем объект класса и передаем ему значения знаменателя и числителя
                Fraction Drop = new Fraction(); // Создаем объект класса

                switch (comboBox1.Text) // Проверка на выбор операции двух дройбей 
                {
                    // Кейс с операцией сложения
                    case "+": 
                        if (Convert.ToInt32(textBox3.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0) // Проверка на 0 в знаменателе
                            MessageBox.Show("В знаменателе не может быть 0!");
                        Drop = Drop1 + Drop2; // Присваиваем объекту значение суммы двух дробей
                        richTextBox1.Text += Drop + "\n"; // Выводим значение дроби
                        richTextBox1.Text += "\nСокращенная:\n";
                        Drop.Simplify(); // С помощью метода сокращаем дробь
                        richTextBox1.Text += "\n" + Drop; // Выводим сокращенную дробь
                        break;
                    // Кейс с операцией разности
                    case "-":
                        if (Convert.ToInt32(textBox3.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0) // Проверка на 0 в знаменателе
                            MessageBox.Show("В знаменателе не может быть 0!");
                        Drop = Drop1 - Drop2; // Присваиваем объекту значение разности двух дробей
                        richTextBox1.Text += Drop + "\n";  // Выводим значение дроби
                        richTextBox1.Text += "\nСокращенная:\n";
                        Drop.Simplify(); // С помощью метода сокращаем дробь
                        richTextBox1.Text += "\n" + Drop; // Выводим сокращенную дробь
                        break;
                    // Кейс с операцией умножения
                    case "*":
                        if (Convert.ToInt32(textBox3.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0) // Проверка на 0 в знаменателе
                            MessageBox.Show("В знаменателе не может быть 0!");
                        Drop = Drop1 * Drop2; // Присваиваем объекту значение умножения двух дробей
                        richTextBox1.Text += Drop + "\n";  // Выводим значение дроби
                        richTextBox1.Text += "\nСокращенная:\n";
                        Drop.Simplify(); // С помощью метода сокращаем дробь
                        richTextBox1.Text += "\n" + Drop; // Выводим сокращенную дробь
                        break;
                    // Кейс с операцией деления
                    case "/":
                        if (Convert.ToInt32(textBox3.Text) == 0 || Convert.ToInt32(textBox2.Text) == 0) // Проверка на 0 в знаменателе 
                            MessageBox.Show("В знаменателе не может быть 0!");
                        Drop = Drop1 / Drop2; // Присваиваем объекту значение деления одной дроби на другую
                        richTextBox1.Text += Drop + "\n";  // Выводим значение дроби
                        richTextBox1.Text += "\nСокращенная:\n";
                        Drop.Simplify(); // С помощью метода сокращаем дробь
                        richTextBox1.Text += "\n" + Drop; // Выводим сокращенную дробь
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message); // Выводим сообщение об ошибке
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очищаем все поля для ввода и одно поле для вывода
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
        // Объявдем переменные
        int numerator;
        int denomirator;
        // Свойства переменных
        public int Numerator { get => numerator; set => numerator = value; }
        public int Denomirator { get => denomirator; set => denomirator = (value != 0 ? value : 1); }
        // Конструктор без параметров
        public Fraction()
        {
            this.denomirator = 1;
        }
        // Конструктор с 1 параметром
        public Fraction(int numerator)
        {
            this.numerator = numerator;
            this.denomirator = 1;
        }
        // Конструктор с 2 параметрами
        public Fraction(int numerator, int denomirator) : this(numerator)
        {
            Denomirator = denomirator;
        }
        // Метод вывода дроби
        override public String ToString()
        {
            return " " + this.numerator + "\n-----\n" + " " + this.denomirator;
        }
        // Перегрузка оператора сложения
        public static Fraction operator +(Fraction drop1, Fraction drop2)
        {
            Fraction temp = new Fraction(); // Создаем объект класса 

            temp.denomirator = drop1.denomirator * drop2.denomirator; // Перемножаем два знаменателя и присваиваем значение знаменателю объекта
            temp.numerator = drop1.numerator * drop2.denomirator + drop2.numerator * drop1.denomirator; // Суммируем умножения знаменателей и числитей и присваиваем значение чеслителю объекта

            return temp; // Возвращаем объект
        }
        // Перегрузка оператора разности
        public static Fraction operator -(Fraction drop1, Fraction drop2)
        {
            Fraction temp = new Fraction(); // Создаем объект класса 

            temp.denomirator = drop1.denomirator * drop2.denomirator; // Перемножаем два знаменателя и присваиваем значение знаменателю объекта
            temp.numerator = drop1.numerator * drop2.denomirator - drop2.numerator * drop1.denomirator; // Отнимае умножения знаменателей и числитей и присваиваем значение чеслителю объекта

            return temp; // Возвращаем объект
        }
        // Перегрузка оператора умножения
        public static Fraction operator *(Fraction drop1, Fraction drop2)
        {
            Fraction temp = new Fraction(); // Создаем объект класса

            temp.numerator = drop1.numerator * drop2.numerator; // Присваиваем переменной объекта умножение двух числителей
            temp.denomirator = drop1.denomirator * drop2.denomirator; // Присваиваем переменной объекта умножение двух знаменателей

            return temp; // Возвращаем объект
        }
        // Конструктор переворачивания дроби 
        public Fraction Reverse()
        {
            Fraction temp = new Fraction(); // Создаем объект класса

            temp.numerator = this.denomirator; // Присваиваем переменной объекта значение знаменателя
            temp.denomirator = this.numerator; // Присваиваем переменной объекта значение числителя

            return temp; // Возвращаем объект
        }
        // Перегрузка оператора деления
        public static Fraction operator /(Fraction drop1, Fraction drop2)
        {
            Fraction temp = new Fraction(); // Создаем объект класса

            temp = drop1 * drop2.Reverse(); // Присваиваем объекту умножение двух дробей, одна из которых перевернутая

            return temp; // Возвращаем объект
        }
        // Метод сокращения дроби
        public void Simplify()
        {
            int tNumerator = this.numerator; // Создаем переменную и присваиваем ей значение полученого числителя
            int tDenominator = this.denomirator; // Создаем переменную и присваиваем ей значение полученого знаменателя

            if (tDenominator % tNumerator == 0) // Проверка на то, можно ли подилить нацело знаменатель на числитель
            {
                denomirator /= numerator; // Делим знаменатель на числитель и присваиваем значение знаменателю
                numerator = 1; // Присваиваеи 1 числителю
                return; // Заканчиваем действие метода
            }
            // Создаем цикл для сокращения
            for (int i = 2; i < tNumerator; i++) // Начало итератора начинаем с 2, смысла делить на 0 и 1 нет, конец это значие числителя
            {
                if (tNumerator % i == 0 && tDenominator % i == 0) // Проверка на целочисленное деления занменателя и числителя на итератор
                {
                    tNumerator /= i; // Делим числитель на итератор и присваиваем значение числителю
                    tDenominator /= i; // Делим знаменитель на итератор и присваиваем значение знаменателю
                    i--; // Уменьшаем итератор на 1
                }
            }

            this.numerator = tNumerator; // Присваиваем полученое значение полученому числителю
            this.denomirator = tDenominator; // Присваиваем полученое значение полученому знаменателю
        }
    }
}
