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
        List<string> clipboardList = new List<String>(); //������ � �������
        String[] clipboard = new String[10]; //������ � ���������� ������ ������
        int clipCount = 0; //���-�� ��������� � �������

        public Form1() {
			InitializeComponent();
		}

        private void Form1_Load(object sender, EventArgs e) {
            gkh.HookedKeys.Add(Keys.A);
            gkh.HookedKeys.Add(Keys.B);
            gkh.HookedKeys.Add(Keys.C); // - C
            gkh.HookedKeys.Add(Keys.V);
            gkh.HookedKeys.Add(Keys.LControlKey); //����� Ctrl

            //��� ����
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
            for(int i=0; i<10; i++) //��� �� ��� ����
            {
                gkh.HookedKeys.Add(k[i]);
            }

            //gkh.HookedKeys.Add(Keys.D1);

            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown); //�������
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);

		}
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //����� ��������� ��� ������� ����������
            //textBox1.Text = e.ToString();
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
            
            //������������� ����� ��� ������� 
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


            //�������� - ������ �� ����������
            if (CTRL && C)
            {
                textBox1.Text += "Ctrl+C pressed"+ Environment.NewLine;
                String lastClipboar = Clipboard.GetText(); //�������� �������� ������ � ����������
                //Array.add(clipboard, lastClipboar);  //��������� �������� ������ � ����� 
                //MessageBox.Show("Ctrl+C");

                if (clipCount < 10) //���� ���� ����� � ������ - �������� � ����� ������� �����������
                {
                    clipboard[clipCount + 1] = lastClipboar;
                    clipCount++;
                }
                else //����� �������
                {
                    clipboard[clipCount] = clipboard[clipCount + 1];
                    clipboard[10] = lastClipboar;
                }

            }

            if (CTRL && V ) //�������� ���� ������
            {
                //textBox1.Text += "Ctrl+V" + Environment.NewLine;
                Clipboard.SetText(string.Concat(clipboard)); // ������� ������� �������� � ����� ������
            }

            if (CTRL && V && e.KeyCode == Keys.D1) //D1, D2, D3... D9
            {
                textBox1.Text += "Ctrl+V" + e.KeyCode.ToString() + " - c���� ���������� ���� ������" + Environment.NewLine;
                //Clipboard.SetText(clipboard.ToString()); // ������� ������� �������� � ����� ������
            }


            e.Handled = false; //���� false, �� ���������� ������� ������
            e.Handled = false; //���� false, �� ���������� ������� ������
        }

        void gkh_KeyUp(object sender, KeyEventArgs e) {
			lstLog.Items.Add("Up\t" + e.KeyCode.ToString());

            //������� ����� ��� �������
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