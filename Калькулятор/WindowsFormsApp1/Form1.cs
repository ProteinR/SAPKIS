using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        float x1, x2, y;
        bool positive;
        int id;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text = textBox1.Text + ",";
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                x1 = float.Parse(textBox1.Text);
                textBox1.Clear();
                label1.Text = x1.ToString() + " + ";
                id = 1;
            }
                
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                x1 = float.Parse(textBox1.Text);
                textBox1.Clear();
                label1.Text = x1.ToString() + " - ";
                id = 2;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                x1 = float.Parse(textBox1.Text);
                textBox1.Clear();
                label1.Text = x1.ToString() + " * ";
                id = 4;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                x1 = float.Parse(textBox1.Text);
                textBox1.Clear();
                label1.Text = x1.ToString() + " ÷ ";
                id = 5;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        { if (textBox1.Text.Length != 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                x1 = float.Parse(textBox1.Text);
                y = (float)Math.Pow(x1, 2);
                textBox1.Text = y.ToString();
                label1.Text = "sqr(" + x1 + ")";
                //label1.Text = x1.ToString() + " ^ ";
                //id = 3;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            switch (id)
            {
                case 1:
                    x2 = float.Parse(textBox1.Text);
                    y = x1 + x2;
                    label1.Text = "";
                    textBox1.Text = y.ToString();
                    break;
                case 2:
                    x2 = float.Parse(textBox1.Text);
                    y = x1 - x2;
                    label1.Text = "";
                    textBox1.Text = y.ToString();
                    break;

                /*case 3:
                  x2 = float.Parse(textBox1.Text);
                  for (int i=0; i<x2; i++)
                  {
                      y = x1 * x1;
                  }
                  //y = x1 + x2;
                  label1.Text = "";
                  textBox1.Text = y.ToString();
                  break; */
                case 4:
                    x2 = float.Parse(textBox1.Text);
                    y = x1 * x2;
                    label1.Text = "";
                    textBox1.Text = y.ToString();
                    break;
                case 5:
                    x2 = float.Parse(textBox1.Text);
                    y = x1 / x2;
                    label1.Text = "";
                    textBox1.Text = y.ToString();
                    break;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Clear();
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                x1 = -(float.Parse(textBox1.Text));
                textBox1.Text = x1.ToString();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                x1 = float.Parse(textBox1.Text);
                label1.Text = "√(" + x1 + ")";
                textBox1.Text = Math.Sqrt(x1).ToString();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                x1 = float.Parse(textBox1.Text);
                label1.Text = "1/" + x1;
                textBox1.Text = (1/x1).ToString();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text == )
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))) e.Handled = true;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }
    }
}
