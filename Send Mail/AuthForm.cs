using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Send_Mail
{

    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Email.login = textBox1.Text;
            Email.pass = textBox2.Text;

            if (Email.IsValidEmail(Email.login))
            {
                //email for auth test - ismailauth@gmail.com : qpzmqpzm1
                try
                {
                    Email.SendMail("smtp.gmail.com", Email.login, Email.pass, "ismailauth@gmail.com", "auth", "auth body");
                }
                catch (Exception ex) {return; }
            }else
            {
                MessageBox.Show("Введите корректный email");
                return;
            }
            if (checkBox1.Checked == false) //если компьютер не чужой - сохраняем авторизационные данные в файл
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\1.txt", Email.login + "|" + Email.pass);
            }else
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\1.txt");
            }
            
            Form1 mainWindow = new Form1();
            mainWindow.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "rgzcsharpmail@gmail.com";
            textBox2.Text = "qpzmqpzm1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 mainWindow = new Form1();
            mainWindow.Show();
            this.Visible = false;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            //textBox1.Text = Directory.GetCurrentDirectory();

            if (File.Exists(Directory.GetCurrentDirectory() + @"\1.txt")) //подставляем значение из сохраннного файла
            {
                string tempData = File.ReadAllText(Directory.GetCurrentDirectory()+ @"\1.txt");
                string[] tempArr = tempData.Split('|');

                textBox1.Text = tempArr[0];
                textBox2.Text = tempArr[1];
            }
        }
    }
}
