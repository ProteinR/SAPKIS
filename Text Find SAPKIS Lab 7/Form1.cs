using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Text_Find_SAPKIS_Lab_7
{
    public partial class Form1 : Form
    {
        int countWords = 0; //кол-во найденных совпадений
        int currentWord = 0; //текущее подствеченное совпадение
        int startIndex = 0; //индекс последнего вхождения текущей подсветки
        int oldStartIndex = 0; //старый индекс (для возврата предыдущего вхождения)
        List<int> indexes = new List<int> { }; //массив с индексами

        public Form1()
        {
            InitializeComponent();
        }

        public void clearSelectionColor() //метод для очистки подсветки
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.TextLength;
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
        }

        public void textFind() //поиск по тексту
        {
            clearSelectionColor(); //очистка прошлой подсвтетки
            String text = richTextBox1.Text; //haystack - текст в котором ищем

            String needle = textBox1.Text; //needle - искомый текст 
            int index = 0; // начальное положеие курсора (откуда ведеться поиск)
            countWords = 0; // сбрасываем кол-во найденных соападений

            while (index < text.LastIndexOf(needle))
            {
                richTextBox1.Find(needle, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                indexes.Add(richTextBox1.Find(needle, index, richTextBox1.TextLength, RichTextBoxFinds.None)); //добавляем все инд в массив
                richTextBox1.SelectionBackColor = Color.Yellow;
                index = text.IndexOf(needle, index) + 1;
                countWords += 1; //при нахождении каждого совпадения - считаем его
            }
        }

        //навигация и подсветка другим цветом
        public void textFindNav() //навигация по подвеченному тексту
        {
            if (countWords != 0)
            {
                //отладочные данные
                //String n = richTextBox1.Text;
                //Console.WriteLine("startIndex = "+ startIndex +" => "+ n[startIndex]+ " ");
                //

                richTextBox1.Find(textBox1.Text, startIndex, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.SelectionBackColor = Color.Orange; 
                //startIndex++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                clearSelectionColor(); //сбросить подсветку если ничего не введено
                countWords = 0; //сбросить счетчики
                currentWord = 0;
                startIndex = 0;
                label1.Visible = false;
                textBox1.BackColor = SystemColors.Window;
            }
            if (textBox1.Text.Length != 0)
            {
                textFind(); // поиск
            }

            if (countWords > 0) //нашли хотя бы одно совпадение
            {
                textBox1.BackColor = Color.LightGreen;
                textFindNav(); //навигация по найденным  участкам
                currentWord = 1; //по умолчанию подсвечиваем первый найденный текст
                button1.Visible = true;
                button2.Visible = true;
                label1.Visible = true;
            }
            else if (countWords == 0)
            {
                currentWord = 0;
                if (textBox1.Text.Length != 0) textBox1.BackColor = Color.LightPink; //что-то ввели, но не найдено - красный цвет
                button1.Visible = false;
                button2.Visible = false;
            }
            label1.Text = currentWord.ToString() + "/" + countWords.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (currentWord < countWords) // переходим на следующее слово, либо на самое первое
            {
                currentWord++;
                oldStartIndex = startIndex;
                startIndex++;
                startIndex = richTextBox1.Find(textBox1.Text, startIndex, richTextBox1.TextLength, RichTextBoxFinds.None)+ textBox1.Text.Length;
            }
            else
            {
                currentWord = 1;
                startIndex = 0; //переместили курсор в начало
            }
            textFind();
            textFindNav();
            label1.Text = currentWord.ToString() + "/" + countWords.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //дебаг
            int[] arrIndexes = indexes.ToArray();
            for (int i = 0; i < arrIndexes.Length; i++)
            {
                //Console.WriteLine("sas");
                Console.WriteLine(i + " => " + indexes[i]);
            }
            //

            if (currentWord == 1)
            {
                currentWord = countWords;
            }else
            {
                currentWord--;
                startIndex = richTextBox1.Find(textBox1.Text, oldStartIndex, richTextBox1.TextLength, RichTextBoxFinds.None);
            }
            textFind();
            textFindNav();
            label1.Text = currentWord.ToString() + "/" + countWords.ToString();
        }
    }
}
