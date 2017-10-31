using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Utilities;

namespace key_preview {
	public partial class Form1 : Form {
		globalKeyboardHook gkh = new globalKeyboardHook();

		public Form1() {
			InitializeComponent();
		}

        private void Form1_Load(object sender, EventArgs e) {

            gkh.HookedKeys.Add(Keys.A);
            gkh.HookedKeys.Add(Keys.B);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);

            //int[] arr1Line = { 1, 2, 3, 4, 5 };
            Char[] chars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7','8', '9', '0' };
            for (int i=0; i<35; i++)
            {
                //gkh.HookedKeys.Add(Keys.chars[i]); -- не работает подстановка из массива
            }
		}
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                MessageBox.Show("you have pressed Ctrl + C");
            else if (e.Control && e.KeyCode == Keys.V)
                MessageBox.Show("You have pressed Ctrl + V");
            //else if (e.Control && e.KeyCode == Keys.V && Keys.(preg_match('[0-9]'));
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
            //if (e.Control && e.KeyCode == Keys.A)
            //    MessageBox.Show("you have pressed Ctrl + A");
            //else if (e.Control && e.Shift && e.KeyCode == Keys.A)
            //    MessageBox.Show("You have pressed Ctrl + Shift + A");
            //e.Handled = true;
        }

        void gkh_KeyUp(object sender, KeyEventArgs e) {
			lstLog.Items.Add("Up\t" + e.KeyCode.ToString());
			e.Handled = true;
            
        }  

        private void lstLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}