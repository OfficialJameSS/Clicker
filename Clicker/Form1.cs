using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int i { get; private set; }
        public int czas { get; private set; }
        public int dzieleniesredniej { get; private set; }
        public double srednia { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            i = 0;
            dzieleniesredniej = 30;
            czas = 30;
            timer1.Start();
            label1.Text = "Wynik = " + Convert.ToString(i);
            label2.Text = "Czas: " + Convert.ToString(czas) + "s";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czas--;
            label2.Text = "Czas: " + czas + "s";

            if (czas <= 0)
            {
                timer1.Stop();
                srednia = Convert.ToDouble(i) / Convert.ToDouble(dzieleniesredniej);
                DialogResult dialogResult = MessageBox.Show("Twój czas się skończył. Oto statystyki!\nWynik = " + i + "\nŚrednia = " + srednia , "Czy chcesz ponowić próbę?" , MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    i = 0;
                    czas = 30;
                    timer1.Start();
                    label1.Text = "Wynik = " + Convert.ToString(i);
                    label2.Text = "Czas: " + Convert.ToString(czas);
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            label1.Text = "Wynik = " + Convert.ToString(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Masz 30 sekund, aby sprawdzić swoją szybkość klikania. Każde kliknięcie jest liczone za 1 punkt.");
        }
    }
}
