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

namespace key_preview {
	public partial class Form1 : Form {
		globalKeyboardHook gkh = new globalKeyboardHook();
        
        bool C = false;
        bool V = false;
        bool CTRL = false;
        List<string> clipboardList = new List<String>(); //список с буфером
        String[] clipboard = new String[10]; //массив с содержимым буфера обмена
        int clipCount = 0; //кол-во элементов в массиве

        public Form1() {
			InitializeComponent();
		}

        private void Form1_Load(object sender, EventArgs e) {
            gkh.HookedKeys.Add(Keys.A);
            gkh.HookedKeys.Add(Keys.B);
            gkh.HookedKeys.Add(Keys.C); // - C
            gkh.HookedKeys.Add(Keys.V);
            gkh.HookedKeys.Add(Keys.LControlKey); //левый Ctrl

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
            for(int i=0; i<10; i++) //хук на ряд цифр
            {
                gkh.HookedKeys.Add(k[i]);
            }

            //gkh.HookedKeys.Add(Keys.D1);

            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown); //события
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);

		}
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //вывод сообщения при нажатии комбинации
            //textBox1.Text = e.ToString();
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
            
            //устанавливаем флаги при нажатии 
            if (e.KeyCode == Keys.LControlKey)
            { 
                CTRL = true;
            }
            else if (e.KeyCode == Keys.C)
            { 
                C = true;
            }
            else if (e.KeyCode == Keys.V)
            { 
                V = true;
            }


            //проверка - нажата ли комбинация
            if (CTRL && C)
            {
                textBox1.Text += "Ctrl+C pressed"+ Environment.NewLine;
                String lastClipboar = Clipboard.GetText(); //записали значение буфера в переменную
                //Array.add(clipboard, lastClipboar);  //добавляем значение буфера в конец 
                //MessageBox.Show("Ctrl+C");

                if (clipCount < 10) //если есть место в буфере - записали в конец крайнее копирование
                {
                    clipboard[clipCount + 1] = lastClipboar;
                    clipCount++;
                }
                else //сдвиг массива
                {
                    clipboard[clipCount] = clipboard[clipCount + 1];
                    clipboard[10] = lastClipboar;
                }

            }

            if (CTRL && V ) //вставить весь массив
            {
                //textBox1.Text += "Ctrl+V" + Environment.NewLine;
                Clipboard.SetText(string.Concat(clipboard)); // вставка нужного значения в буфер обмена
            }

            if (CTRL && V && e.KeyCode == Keys.D1) //D1, D2, D3... D9
            {
                textBox1.Text += "Ctrl+V" + e.KeyCode.ToString() + " - cупер комбинация была нажата" + Environment.NewLine;
                //Clipboard.SetText(clipboard.ToString()); // вставка нужного значения в буфер обмена
            }


            e.Handled = false; //Если false, то отправляем событие дальше
            e.Handled = false; //Если false, то отправляем событие дальше
        }

        void gkh_KeyUp(object sender, KeyEventArgs e) {
			lstLog.Items.Add("Up\t" + e.KeyCode.ToString());

            //убираем флаги при отжатии
            if (e.KeyCode == Keys.C)
            {
                C = false;
            }
            else if (e.KeyCode == Keys.LControlKey)
            {
                CTRL = false;
            }
            else if (e.KeyCode == Keys.V)
            {
                V = false;
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

    }
}