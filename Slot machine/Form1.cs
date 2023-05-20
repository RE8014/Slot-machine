using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slot_machine
{
    public partial class Form1 : Form
    {
        private int coin =  0;
        private int result;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.Visible = false;
            button1.Visible = false;
            label2.ForeColor = Color.Gray;
            label3.ForeColor = Color.Gray;
            label4.ForeColor = Color.Gray;
            Random random1 = new Random();
            for (int i = 0; i < 11; i++)
            {
                int first = random1.Next(1, 8);
                await Task.Delay(100);
                label2.Text = first.ToString();
            }
            label2.ForeColor = Color.Black;
            Random random2 = new Random();
            for (int i = 0; i < 11; i++)
            {
                int second = random2.Next(1, 8);
                await Task.Delay(100);
                label3.Text = second.ToString();

            }
            label3.ForeColor = Color.Black;
            Random random3 = new Random();
            for (int i = 0; i < 11; i++)
            {
                int third = random3.Next(1, 8);
                await Task.Delay(100);
                label4.Text = third.ToString();

            }
            label4.ForeColor = Color.Black;
            result = int.Parse(label2.Text + label3.Text + label4.Text);
            int slot1 = int.Parse(label2.Text);
            int slot2 = int.Parse(label3.Text);
            int slot3 = int.Parse(label4.Text);
            label5.Text = result.ToString();
            if (result == 777)
            {
                coin += 100;
            }
            else if (slot1 == slot2 && slot2 == slot3)
            {
                coin += 50;
            }
            else if (slot1 == slot2 || slot1 == slot3 || slot2 == slot3)
            {
                coin += 10;
            }
            else
            {
                coin += 0;
            }
            if (slot1%2 == 0 && slot2 % 2 == 0 && slot3 % 2 == 0)
            {
                coin += 5;
            }
            money.Text = coin.ToString();
            button1.Visible = true;
        }

        private async void button1_MouseUp(object sender, MouseEventArgs e)
        {
            await Task.Delay(200);
            pictureBox2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            money.Text = coin.ToString();
        }
    }
}
