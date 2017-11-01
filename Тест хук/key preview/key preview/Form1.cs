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
            gkh.HookedKeys.Add(Keys.D1);
            gkh.HookedKeys.Add(Keys.D2);
            gkh.HookedKeys.Add(Keys.D3);
            gkh.HookedKeys.Add(Keys.D4);
            gkh.HookedKeys.Add(Keys.D5);
            gkh.HookedKeys.Add(Keys.D6);
            gkh.HookedKeys.Add(Keys.D7);
            gkh.HookedKeys.Add(Keys.D8);
            gkh.HookedKeys.Add(Keys.D9);

            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            
            //�������� ������
            Char[] chars = {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'X', 'Y',
                'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            //for (int i=0; i<32; i++)
            //{
            //    Char symbol = chars[i];
            //    gkh.HookedKeys.Add(Keys.symbol); 
            //}
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
                textBox1.Text += "Ctrl+C pressed";
                String lastClipboar = Clipboard.GetText(); //�������� �������� ������ � ����������
                //Array.add(clipboard, lastClipboar);  //��������� �������� ������ � ����� 
                //MessageBox.Show("Ctrl+C");

                if (clipCount < 9) //���� ���� ����� � ������ - �������� � ����� ������� �����������
                {
                    clipboard[clipCount + 1] = lastClipboar; 
                }

            }
            //else if (CTRL && V) //������� ���������� ctrl+v
            //{
            //    textBox1.Text += "Ctrl+V pressed";
            //}
            else if (CTRL && V && e.KeyCode == Keys.D1)
            {
                textBox1.Text += "Ctrl+V - c���� ���������� ���� ������";
                textBox1.Text += "Ctrl+V" + e.KeyCode.ToString() +  " pressed";
            }

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