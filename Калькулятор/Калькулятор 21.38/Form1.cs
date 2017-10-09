using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //global 
        float x1, x2, y; // x1-первый оп., х2-второй оп., у-третий оп.
        //bool positive; //
        int id; //id каждого действия
        bool old; //если тру - значит в текстбоксе содержиться результат
        float m; //буфер обмена

        public bool SetAutorunValue(bool autorun) //ф-ция добавления в автозагр.
        {
            const string name = "MyCalculator";
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 1;
            }
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 2;
            }
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 3;
            }
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 3;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 4;
            }
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 4;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 5;
            }
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 5;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 6;
            }
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 6;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String str_textbox = textBox1.Text;
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 7;
            }
            /*else if (textBox1.Text.Contains("0") && (str_textbox.Length==1)) {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 7;
            }*/
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 7;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text = textBox1.Text + ",";
            }

        }

        private void button17_Click(object sender, EventArgs e) {
            if (old != true) {
                textBox1.Text = textBox1.Text + 0;
            }
            else {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 0;
            }
        }

        private void button13_Click(object sender, EventArgs e) {
            if (textBox1.Text.Length != 0) {
                if (x1 != 0) {
                    x2 = float.Parse(textBox1.Text);
                    x1 += x2;
                    label1.Text = x1.ToString() + " + ";
                    old = true;
                    id = 1;
                    //x1 = 0;
                }
                else {
                    x1 = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    label1.Text = x1.ToString() + " + ";
                    id = 1;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0) {
                if (x1 != 0)
                {
                    x2 = float.Parse(textBox1.Text);
                    x1 -= x2;
                    label1.Text = x1.ToString() + " - ";
                    old = true;
                    id = 2;
                    //x1 = 0;
                }
                x1 = float.Parse(textBox1.Text);
                textBox1.Clear();
                label1.Text = x1.ToString() + " - ";
                id = 2;
            }
        }

        private void button11_Click(object sender, EventArgs e) {
            //if (textBox1.Text.Length != 0){
            //if (x1 != 0)
            //{
            //    x2 = float.Parse(textBox1.Text);
            //    x1 *= x2;
            //    label1.Text = x1.ToString() + " * ";
            //    old = true;
            //    id = 4;
            //    x1 = float.Parse(textBox1.Text);
            //}
            //    textBox1.Clear();
            //    label1.Text = x1.ToString() + " * ";
            //    id = 4;
            //}
            //else
            //{
            //    x1 = float.Parse(textBox1.Text);
            //    textBox1.Clear();
            //   label1.Text = x1.ToString() + " + ";
            //    id = 1;
            //}
            if (textBox1.Text.Length != 0)
            {
                if (x1 != 0)
                {
                    x2 = float.Parse(textBox1.Text);
                    x1 *= x2;
                    label1.Text = x1.ToString() + " * ";
                    old = true;
                    id = 4;
                }
                else
                {
                    x1 = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    label1.Text = x1.ToString() + " * ";
                    id = 1;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e) {
            if (textBox1.Text.Length != 0)
            {
                if (x1 != 0)
                {
                    x2 = float.Parse(textBox1.Text);
                    x1 /= x2;
                    label1.Text = x1.ToString() + " ÷ ";
                    old = true;
                    id = 2;
                    //x1 = 0;
                }
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
                //string result;
                //float first; //сохраняем сюда начальный операнд
                x1 = float.Parse(textBox1.Text);
                //first = x1;
                y = (float)Math.Pow(x1, 2);
                textBox1.Text = y.ToString();
                label1.Text = "sqr(" + x1 + ")";
                //label1.Text = "sqr(" + label1.Text + ")"; //не выводит сам операнд
            }
        }

        private void button10_Click(object sender, EventArgs e)
            
        {
            if (x1 != 0)
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
                old = true; //означает, что в edit записан результат вычисления
                x1 = 0;
                x2 = 0;
            }
        
        }


        private void button20_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            //label1.Clear();
            textBox1.Clear();
            x1 = 0;
            x2 = 0;
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
            if (textBox1.Text.Length != 0)
            {
                //m += Convert.ToDouble(textBox1.Text);
                m += float.Parse(textBox1.Text);
                button28.Enabled = true;
                button27.Enabled = true;
                //Clipboard.SetText(textBox1.Text);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                m -= float.Parse(textBox1.Text);
                button28.Enabled = true;
                button27.Enabled = true;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int x3;
            x3 = int.Parse(textBox1.Text);
            x2 = x1 / 100 * x3; //нашли проценты
            //x2 = y;
            label1.Text += x2.ToString();
            textBox1.Text = x2.ToString();
            //textBox1.Text = y.ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Text = m.ToString();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            m = 0;
            button28.Enabled = false;
            button27.Enabled = false;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                m = float.Parse(textBox1.Text);
                button28.Enabled = true;
                button27.Enabled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            

        }

        private void button25_Click(object sender, EventArgs e)
        {
            SetAutorunValue(true); //вызываем ф-цию добавления в автозагр.
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SetAutorunValue(false); //вызываем ф-цию добавления в автозагр. (убираем)
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }

        private void button26_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button26, "Убрать из автозагрузки");
        }

        private void button25_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button25, "Добавить в автозагрузку");
        }

        private void button29_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button29, "Добавление памяти");
        }

        private void button30_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button30, "Вычитание памяти");
        }

        private void button31_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button31, "Сохранение в памяти");
        }

        private void button28_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button28, "Вызов из памяти");
        }

        private void button27_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button27, "Очистка всей памяти");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 8;
            }
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 8;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (old != true)
            {
                textBox1.Text = textBox1.Text + 9;
            }
            else
            {
                old = false;
                textBox1.Clear();
                textBox1.Text = textBox1.Text + 9;
            }
        }
    }
}
