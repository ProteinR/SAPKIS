using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Files_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String currDirectory = Directory.GetCurrentDirectory();
            textBox2.Text = currDirectory;

            String[] filesArr = Directory.GetFiles(currDirectory); //в массиве имена всех файлов


            //string[] directories = Directory.GetDirectories(currDirectory);
            //foreach (string directory in directories)
            //{
            //    textBox1.Text += directory;
            //}
            string[] files = Directory.GetFiles(currDirectory, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                textBox1.Text += file + Environment.NewLine;
            }

            foreach (string fileName in filesArr)
            {
                //string folders = Directory.EnumerateFiles(currDirectory) + Environment.NewLine;
                //textBox1.Text += folders;
                //textBox1.Text += fileName + Environment.NewLine; //выводит список файлов с путями
            }
        }
    }
}
