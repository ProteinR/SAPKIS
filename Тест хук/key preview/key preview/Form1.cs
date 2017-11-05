using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Utilities;
using System.Collections.Generic;


namespace key_preview
{
    public partial class Form1 : Form
    {
        globalKeyboardHook gkh = new globalKeyboardHook();

        bool C = false;
        bool V = false;
        bool D = false; 
        bool CTRL = false;
        bool RCTRL = false;
        bool Q = false;

        String[] clipboard = new String[10]; //массив с содержимым буфера обмена
        int clipCount = 0; //кол-во элементов в массиве

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //хук на необходимые клавишы
        {
            gkh.HookedKeys.Add(Keys.A);
            gkh.HookedKeys.Add(Keys.D);
            gkh.HookedKeys.Add(Keys.C); // - C
            gkh.HookedKeys.Add(Keys.V);
            gkh.HookedKeys.Add(Keys.Q);

            gkh.HookedKeys.Add(Keys.LControlKey); //левый Ctrl
            gkh.HookedKeys.Add(Keys.RControlKey); //правый Ctrl


            //ряд цифр
            Keys[] k = new Keys[10];
            k[0] = Keys.D0;
            k[1] = Keys.D1;
            k[2] = Keys.D2;
            k[3] = Keys.D3;
            k[4] = Keys.D4;
            k[5] = Keys.D5;
            k[6] = Keys.D6;
            k[7] = Keys.D7;
            k[8] = Keys.D8;
            k[9] = Keys.D9;
            for (int i = 0; i < 10; i++) //хук на ряд цифр
            {
                gkh.HookedKeys.Add(k[i]);
            }

            //gkh.HookedKeys.Add(Keys.D1);

            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown); //события
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            Clipboard.Clear();

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //вывод сообщения при нажатии комбинации
            //textBox1.Text = e.ToString();
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            lstLog.Items.Add("Down\t" + e.KeyCode.ToString()); //запись в листбокс

            //устанавливаем флаги при нажатии 
            if (e.KeyCode == Keys.LControlKey)
            {
                CTRL = true;
            }
            if (e.KeyCode == Keys.RControlKey)
            {
                RCTRL = true;
            }
            else if (e.KeyCode == Keys.C)
            {
                C = true;
            }
            else if (e.KeyCode == Keys.V)
            {
                V = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                D = true;
            }
            else if (e.KeyCode == Keys.Q)
            {
                Q = true;
            }



            //проверка - нажата ли комбинация


            Keys[] k = new Keys[10];
            k[0] = Keys.D0;
            k[1] = Keys.D1;
            k[2] = Keys.D2;
            k[3] = Keys.D3;
            k[4] = Keys.D4;
            k[5] = Keys.D5;
            k[6] = Keys.D6;
            k[7] = Keys.D7;
            k[8] = Keys.D8;
            k[9] = Keys.D9;

            /*
            if (CTRL && V ) //D1, D2, D3... D9
            {
                for(int i=0; i<10; i++) //дополнительная проверка - нажата ли клавиша с цифрой
                {
                    if (e.KeyCode == k[i])
                    {
                        //textBox1.Text += "Ctrl+V" + e.KeyCode.ToString() + " - cупер комбинация была нажата" + Environment.NewLine;
                        Clipboard.SetText(clipboard[i]); // вставка нужного значения в буфер обмена
                    }
                }
            }
            */
            e.Handled = false; //Если false, то отправляем событие дальше
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)//события на key up
        {
            Keys[] k = new Keys[10];
            k[0] = Keys.D0;
            k[1] = Keys.D1;
            k[2] = Keys.D2;
            k[3] = Keys.D3;
            k[4] = Keys.D4;
            k[5] = Keys.D5;
            k[6] = Keys.D6;
            k[7] = Keys.D7;
            k[8] = Keys.D8;
            k[9] = Keys.D9;

            //добавление в массив при копировании
            if (CTRL && C)
            {
                textBox1.Text += "Ctrl+C pressed" + Environment.NewLine;
                String lastClipboar = Clipboard.GetText(); //записали значение буфера в переменную
                //Console.Out.WriteLine(Clipboard.GetText());
                Console.Out.WriteLine("\"" + lastClipboar + "\"");
                if (clipCount < 10) //если есть место в буфере - записали в конец крайнее копирование
                {
                    textBox1.Text += "clpcount = " + clipCount + " - сдвиг не нужен" + Environment.NewLine;
                    clipboard[clipCount] = lastClipboar;
                    //Console.Out.WriteLine("записали в " + clipCount + " элемент массива " + clipboard[clipCount]);
                    clipCount++;

                }
                else //сдвиг массива
                {
                    textBox1.Text += "clpcount = " + clipCount + " - сдвиг массива" + Environment.NewLine;

                    for (int i = 0; i < 9; i++)
                    {
                        clipboard[i] = clipboard[i + 1];
                    }
                    clipboard[9] = lastClipboar;
                }

            }


            //запись нужного элемента в буфер обмена
            try
            {
                // 0 
                if (CTRL && D && e.KeyCode == k[0] || RCTRL && e.KeyCode == k[0])
                {
                    //String clip0 = clipboard[0]; 
                    //Console.WriteLine("Нулевой элемент массива - " + clip0);
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[0]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
                // 1
                if ((CTRL && D && e.KeyCode == k[1]) || RCTRL && e.KeyCode == k[1])
                {
                    //Console.WriteLine(clipboard[1]);
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[1]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^"+ "V");
                }
                // 2
                if (CTRL && D && e.KeyCode == k[2] || RCTRL && e.KeyCode == k[2])
                {
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[2]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
                // 3
                if (CTRL && D && e.KeyCode == k[3] || RCTRL && e.KeyCode == k[3])
                {
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[3]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
                // 4
                if (CTRL && D && e.KeyCode == k[4] || RCTRL && e.KeyCode == k[4])
                {
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[4]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
                // 5
                if (CTRL && D && e.KeyCode == k[5] || RCTRL && e.KeyCode == k[5])
                {
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[5]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
                // 6
                if (CTRL && D && e.KeyCode == k[6] || RCTRL && e.KeyCode == k[6])
                {
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[6]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
                // 7
                if (CTRL && D && e.KeyCode == k[7] || RCTRL && e.KeyCode == k[7])
                {
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[7]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
                // 8
                if (CTRL && D && e.KeyCode == k[8] || RCTRL && e.KeyCode == k[8])
                {
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[8]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
                // 9
                if (CTRL && D && e.KeyCode == k[9] || RCTRL && e.KeyCode == k[9])
                {
                    Clipboard.Clear();
                    Clipboard.SetText(clipboard[9]); // вставка нужного значения в буфер обмена
                    SendKeys.Send("^" + "V");
                }
            }
            catch (Exception ex) { }


            lstLog.Items.Add("Up\t" + e.KeyCode.ToString()); //вывод key up в листбокс

            //убираем флаги при отжатии
            if (e.KeyCode == Keys.C)
            {
                C = false;
            }
            if (e.KeyCode == Keys.D)
            {
                D = false;
            }
            else if (e.KeyCode == Keys.LControlKey)
            {
                CTRL = false;
            }
            else if (e.KeyCode == Keys.RControlKey)
            {
                RCTRL = false;
            }
            else if (e.KeyCode == Keys.V)
            {
                V = false;
                //textBox1.Text += "V отжата";
            }
            else if (e.KeyCode == Keys.Q)
            {
                Q = false;
            }
            e.Handled = false;
        }

        private void lstLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
            textBox1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (String element in clipboard)
            {
                textBox3.Text += i + " => " + element + Environment.NewLine;
                i++;
            }
            textBox3.Text += Environment.NewLine;
        }
    }
}