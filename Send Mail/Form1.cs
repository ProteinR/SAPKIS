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

namespace Send_Mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mailTo = textBox1.Text;
            string subject = textBox2.Text;
            String attachment;
            String body = richTextBox1.Text;
            //Email.sendMail.mail.body.IsBodyHtml = true;

            if (textBox3.Text.Length == 0)
            {
                attachment = null;
            }else { attachment = textBox3.Text; }

            if (!Email.IsValidEmail(mailTo)) //проверка на корректность адреса
            {
                MessageBox.Show("Введите корректный Email");
                textBox1.BackColor = Color.LightPink;
                return;
            }

            //всё нормально - отправляем
            Email.SendMail("smtp.gmail.com", Email.login, Email.pass, mailTo, subject, body, attachment);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            }else
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
            //обернуть выделеный текст в <cener>
            string temp = "<cener>" + richTextBox1.SelectedText + "<cener>";
            richTextBox1.SelectedText = temp;
            richTextBox1.Select();
        }
    }
}
