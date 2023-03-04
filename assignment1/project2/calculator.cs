using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class calculator : Form
    {
        public calculator()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = Double.Parse(textBox1.Text.Trim());
            char operation = textBox3.Text[0];
            double num2 = Double.Parse(textBox2.Text.Trim());
            switch (operation)
            {
                case '+':
                    textBox4.Text = $"{num1 + num2}";
                    break;
                case '-':
                    textBox4.Text = $"{num1 - num2}";
                    break;
                case '*':
                    textBox4.Text = $"{num1 * num2}";
                    break;
                case '/':
                    textBox4.Text = $"{num1 / num2}";
                    break;
                case '%':
                    textBox4.Text = $"{num1 % num2}";
                    break;
                default:
                    textBox4.Text = "error";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
