using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace Send_Mail
{
    public partial class Form1 : Form
    {
        String mailTo;
        String subject;
        String body;
        String attachment;
        //String histrySendMailAdress;
        public static TextBox emailtext;
        public Form1()
        {
            InitializeComponent();
        }

        //Вызывается с формы с адресной книги. Не работает
        public void setEmail(String email) //метод для вписывания почт с адресной книги
        {
            textBox1.Text = email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0; //обнулили прогрессбар
            String[] tempArr = null;
            mailTo = textBox1.Text;
            subject = textBox2.Text;
            body = richTextBox1.Text;


            if (textBox3.Text.Length == 0)
            {
                attachment = null;
            }
            else { attachment = textBox3.Text; }
            progressBar1.Value = 30;


            if (!Email.IsValidEmail(mailTo)) //проверка на корректность адреса
            {
                MessageBox.Show("Введите корректный Email");
                textBox1.BackColor = Color.LightPink;
                return;
            }

            File.AppendAllText(Directory.GetCurrentDirectory() + @"\" + Email.login + "HistorymailTo", mailTo + Environment.NewLine); // записываем почту в файл с историей отправки
            textBox1.AutoCompleteCustomSource.Add(mailTo); // добавляем адрес на который отправили в список автодополнения текстбокса

            progressBar1.Value = 50;

            button1.Enabled = false;
            //всё нормально - отправляем
            backgroundWorker1.RunWorkerAsync();

            while (backgroundWorker1.IsBusy)
            {
                Thread.Sleep(50);
                Application.DoEvents();
            }
            button1.Enabled = true;
            //Email.SendMail("smtp.gmail.com", Email.login, Email.pass, mailTo, subject, body, attachment);
            progressBar1.Value = 100;
            MessageBox.Show("Письмо отправлено");
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            emailtext = this.textBox1;
           
            if (File.Exists(Directory.GetCurrentDirectory() + @"\" + Email.login + "HistorymailTo")) //подставляем значение из сохраннного файла
            {
                String[] tempArr = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + Email.login + "HistorymailTo"); //получаем весь файл в стрингу
                foreach (String oneEmail in tempArr)
                {
                    Console.WriteLine(oneEmail);
                }

                textBox1.AutoCompleteCustomSource.AddRange(tempArr);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = SystemColors.Window;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            textBox3.Text = "Дропнули";
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            textBox3.Text = "навели файл";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox3.Text = sender.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //обернуть выделеный текст в h1
            string temp = "<h1>" + richTextBox1.SelectedText + "</h1>";
            richTextBox1.SelectedText = temp;
            richTextBox1.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //обернуть выделеный текст в h2
            string temp = "<h2>" + richTextBox1.SelectedText + "</h2>";
            richTextBox1.SelectedText = temp;
            richTextBox1.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //обернуть выделеный текст в p
            string temp = "<p>" + richTextBox1.SelectedText + "</p>";
            richTextBox1.SelectedText = temp;
            richTextBox1.Select();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //обернуть выделеный текст в a
            if (richTextBox1.SelectedText != "")
            {
                string temp = "<a =\"вашаСсылка\">" + richTextBox1.SelectedText + "</a>";
                richTextBox1.SelectedText = temp;
            }
            else
            {
                string temp = "<a =\"вашаСсылка\">" + "текстСсылки" + "</a>";
                richTextBox1.SelectedText = temp;
            }
            richTextBox1.Select();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //обернуть выделеный текст в strong
            string temp = "<strong>" + richTextBox1.SelectedText + "</strong>";
            richTextBox1.SelectedText = temp;
            richTextBox1.Select();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //обернуть выделеный текст в курсив
            string temp = "<i>" + richTextBox1.SelectedText + "</i>";
            richTextBox1.SelectedText = temp;
            richTextBox1.Select();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //обернуть выделеный текст в <center>
            string temp = "<center>" + richTextBox1.SelectedText + "<center>";
            richTextBox1.SelectedText = temp;
            richTextBox1.Select();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String filePath = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(filePath);
                float fileLength = fi.Length;
                textBox3.BackColor = DefaultBackColor;

                if (fileLength < 1024 * 1024)
                {
                    textBox3.Text = filePath;
                }
                else
                {
                    textBox3.Clear();
                    //textBox3.BackColor = Color.LightPink;
                    MessageBox.Show("Выберите файл размером до 1 мб!");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //обернуть выделеный текст в список ul
            string temp = richTextBox1.SelectedText;
            String[] tempArrLi = temp.Split(null);

            temp = "<ul>" + Environment.NewLine;
            foreach (String str in tempArrLi)
            {
                temp += "<li>" + str + "</li>" + Environment.NewLine;
            }
            temp += "</ul>";

            richTextBox1.SelectedText = temp;
            richTextBox1.Select();
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Каждый элемент списка должен быть написан с новой строки", this.button10);
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Email.SendMail("smtp.gmail.com", Email.login, Email.pass, mailTo, subject, body, attachment);
            }
            catch (Exception ex)
            {
                Email.authNormal = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Address_Book address_Book = new Address_Book();
            address_Book.Show();
        }
    }
}
