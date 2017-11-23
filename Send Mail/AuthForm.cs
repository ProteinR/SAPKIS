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
using System.Threading;

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
            Email.authNormal = true;
            Email.login = textBox1.Text;
            Email.pass = textBox2.Text;

            if (Email.IsValidEmail(Email.login))
            {
                progressBar1.Visible = true;
                progressBar1.Value = 50;
                timer1.Enabled = true;
                //email for auth test - ismailauth@gmail.com : qpzmqpzm1
                try
                {
                    button1.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                    while (backgroundWorker1.IsBusy)
                    {
                        Thread.Sleep(50);
                        Application.DoEvents();
                    }
                    if (Email.authNormal == false)
                    {
                        //MessageBox.Show("зашли в блок неправильного логина ии пасса в основном поткое");
                        progressBar1.Value = 0;
                        progressBar1.Visible = false;
                        return;
                    }
                }
                catch (Exception ex) {
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    return;
                }
                button1.Enabled = true;
            }else
            {
                MessageBox.Show("Введите корректный email");
                return;
            }

            if (checkBox1.Checked == false) //если компьютер не чужой - сохраняем авторизационные данные в файл
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\AuthData", Email.login + "|" + Email.pass);
            }else
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\AuthData");
            }
            Form1 mainWindow = new Form1();
            mainWindow.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e) //заполнение авторизационных данных - тестовыми
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
            if (File.Exists(Directory.GetCurrentDirectory() + @"\AuthData")) //подставляем значение из сохраннного файла
            {
                string tempData = File.ReadAllText(Directory.GetCurrentDirectory()+ @"\AuthData"); //получаем весь файл в стрингу
                string[] tempArr = tempData.Split('|'); //разбиваем стрингу по разделителю

                textBox1.Text = tempArr[0]; // 0 элемент - логин
                textBox2.Text = tempArr[1]; // 1 элемент - пасс
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //MessageBox.Show("начало работы фонового потока");
            try
            {
                Email.SendMail("smtp.gmail.com", Email.login, Email.pass, "ismailauth@gmail.com", "auth", "auth body");
            }catch(Exception ex)
            {
                Email.authNormal = false;
                //return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 90)
            {
                progressBar1.Value += 5;
            }
        }
    }
}
