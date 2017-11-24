using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
    
        const String _MARGIN = "    ";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //get initial root dir
            System.IO.DirectoryInfo rootDir = System.IO.Directory.
                    CreateDirectory(System.IO.Directory.GetCurrentDirectory());

            WalkDirectoryTree(rootDir, "");//margin is empty for first call
        }

        void WalkDirectoryTree(System.IO.DirectoryInfo root, String margin)
            {
                System.IO.FileInfo[] files = null;
                System.IO.DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
                output.AppendText(margin + "\\"+root.Name+"\n");
            }
            catch (UnauthorizedAccessException e) { output.AppendText(e.Message); }
            catch (System.IO.DirectoryNotFoundException e) { output.AppendText(e.Message);}

                if (files != null)
                {
                    //FILES
                    foreach (System.IO.FileInfo fi in files)
                    {
                        //Print each filename with margin
                        output.AppendText(margin + _MARGIN + "|*" + fi.Name + "\n");
                    }

                    subDirs = root.GetDirectories();

                    //DIRS

                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                    {
                        // Rec. call for each sub dir with increase margin.
                        WalkDirectoryTree(dirInfo, margin+ _MARGIN);
                    }
                }
            }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }