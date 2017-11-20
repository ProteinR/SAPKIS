using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPKIS_lab_screenshot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String filename = "1";
            this.WindowState = FormWindowState.Minimized;
            timer1.Enabled = true;
            timer1.Start();
            //Hide();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics graph = null;

            var bmp = new Bitmap(1920, 1080);

            graph = Graphics.FromImage(bmp);

            graph.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            DateTime thisDay = DateTime.Now; //получаем дату
            Pen blackPen = new Pen(Color.Black, 3);

            // Create string to draw.
            String drawString = thisDay.ToString();
            Font drawFont = new Font("Arial", 36);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            PointF drawPoint = new PointF(1800, 750);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Draw string to screen.
            graph.DrawString(drawString, drawFont, drawBrush, drawPoint, drawFormat);

            Console.WriteLine(thisDay.ToString());
            pictureBox1.Image = bmp;
            bmp.Save("filename.bmp");
            timer1.Stop();
        }
    }
}
