using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задания
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract class Komplektyushie<artikyl>
        {
            public int price;
            public string godVIP;
            public artikyl artikyll;
            public Komplektyushie(int pricee, string god, artikyl art)
            {
                price = pricee;
                godVIP = god;
                artikyll = art;
            }
            public abstract void Display(ListBox listBox1);
        }


        class Cp : Komplektyushie<int>
        {
            protected int chastota;
            protected int kolvoYader;
            protected int kolVoPotokov;
            public Cp(int pricee, string god, int art, int chastotaa, int kolvoYaderr, int kolVoPotokovv) : base(pricee, god, art)
            {
                chastota = chastotaa;
                kolvoYader = kolvoYaderr;
                kolVoPotokov = kolVoPotokovv;
            }
            public int chastotaa { get { return chastota; } set { chastota = value; } }
            public int kolVoYaderr { get { return kolvoYader; } set { kolvoYader = value; } }
            public int kolVoPotokovv { get { return kolVoPotokov; } set { kolVoPotokov = value; } }

            public override void Display(ListBox listBox1)
            {
                listBox1.Items.Add($"Цена: {price} , Год выпуска: {godVIP} , Арктикул: {artikyll} , Частота: {chastotaa} , Кол-во ядер: {kolvoYader}, Кол-во потоков: {kolVoPotokov}");
            }
        }
        Cp cp1;

        class Videokarts : Komplektyushie<int>
        {
            int chastota2;
            string proisvodel;
            int pamyat;
            public Videokarts(int pricee, string god, int art, int chastotaaa, string proisv, int pam) : base(pricee, god, art)
            {
                chastota2 = chastotaaa;
                proisvodel = proisv;
                pamyat = pam;
            }
            public int chastotaaa { get { return chastota2; } set { chastota2 = value; } }
            public string proisv { get { return proisvodel; } set { proisvodel = value; } }
            public int pam { get { return pamyat; } set { pamyat = value; } }

            public override void Display(ListBox listBox1)
            {
                listBox1.Items.Add($"Цена: {price} , Год выпуска: {godVIP} , Арткиул: {artikyll} , Частота GPU: {chastota2} , Производитель: {proisvodel} , Объём Памяти: {pamyat}");

            }
        }
        Videokarts vid1;

        private void button1_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox1.Text);
            string godVIP = textBox2.Text;
            int chastota = Convert.ToInt32(textBox3.Text);
            int kolvoYader = Convert.ToInt32(textBox4.Text);
            int kolvoPotokov = Convert.ToInt32(textBox5.Text);
            int artikyll = Convert.ToInt32(textBox9.Text);
            cp1 = new Cp(price, godVIP, artikyll, chastota, kolvoYader, kolvoPotokov);
            cp1.Display(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox1.Text);
            string godVIP = textBox2.Text;
            int chastota = Convert.ToInt32(textBox6.Text);
            string proisvoditel = textBox7.Text;
            int pamyat = Convert.ToInt32(textBox8.Text);
            int artikyll = Convert.ToInt32(textBox9.Text);
            vid1 = new Videokarts(price, godVIP, artikyll, chastota, proisvoditel, pamyat);
            vid1.Display(listBox1);
        }
    }
}
