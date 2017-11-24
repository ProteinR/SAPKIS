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


namespace Send_Mail
{
    public partial class Address_Book : Form
    {
        public static string Emailtext;
        public Address_Book()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String contactEmail = textBox1.Text;
            String contactName = textBox2.Text;

            if (!Email.IsValidEmail(contactEmail))
            {
                MessageBox.Show("Введите правильный Email");
                return;
            }

            String contact = contactEmail + " - " + contactName;

            if (!(listBox1.FindString(contact) >= 0)) // добавлем контакт, если он уникален
            {
                listBox1.Items.Add(contact);
                File.AppendAllText(Directory.GetCurrentDirectory() + @"\" + Email.login + "contacts", contact + Environment.NewLine); // записываем почту и имя нашего контакта
            }
            else
            {
                MessageBox.Show("Данный контакт уже содержится в адресной книге");
            }
        }

        private void Address_Book_Load(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\" + Email.login + "contacts")) //подставляем значение из сохраннного файла
            {
                String[] tempArrContacts = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\" + Email.login + "contacts"); //получаем весь файл в стрингу
                foreach (String oneContact in tempArrContacts)
                {
                    Console.WriteLine(oneContact);
                    listBox1.Items.Add(oneContact);
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //не добавляются значени
            string stringFromListBox = listBox1.SelectedItem.ToString();
            string[] listBoxData = stringFromListBox.Split(' '); //0 элемент - почта, 1 элемент - мусор


            Console.WriteLine("клик по элементу '" + listBoxData[0] + "'");
            //работает!       Form1.emailtext.Text = this.listBox1.SelectedItem.ToString(); //работает!
            Form1.emailtext.Text = listBoxData[0]; //работает!
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
