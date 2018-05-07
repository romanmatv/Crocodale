using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Crocodale
{

    public partial class Form1 : Form
    {
        XmlDocument xDoc = new XmlDocument();
        List<int> alredyWords = new List<int>();
        List<String> words = new List<string>();
        int wordTime = 0, gameTime = 0;
        public Form1()
        {
            InitializeComponent();
            updateDic();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Form dict = new Dictionary();
            dict.ShowDialog();
            updateDic();
        }

        private void newWord()
        {
            wordTime = 0;
            if (words.Count == 0)
            {
                labelWord.Text = "Слово";
                timerGame.Stop();
                timerWord.Stop();
                MessageBox.Show("Игра окончена! Слова закончились");
            }
            else
            {
                Random rand = new Random();
                Console.WriteLine(words.Count);
                String word;
                if (checkBox1.Checked)
                {
                    //Незя повторять
                    int i = Convert.ToInt32(rand.Next(words.Count - 1));

                    word = words[i].ToString();
                    words.Remove(word);
                }
                else
                {
                    //Фигачим все подряд
                    int i = Convert.ToInt32(rand.Next(words.Count - 1));
                    word = words[i].ToString();
                }
                labelWord.Text = word;
            }
        }

        private bool updateDic()
        {
            FileInfo f = new FileInfo("dictionary.xml");
            if (f.Exists)
            {
                dataSet1.ReadXml("dictionary.xml", XmlReadMode.ReadSchema);
                words.Clear();
                foreach (DataRow row in dataSet1.Tables[0].Rows)
                {
                    words.Add(row.Field<String>("text"));
                }
                button1.Enabled = true;
                return true;
            }
            else
            {
                button1.Enabled = false;
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (updateDic())
            {
                timerGame.Start();
                timerWord.Start();
                newWord();
            }
            else
            {
                MessageBox.Show("Словарь пуст");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Convert.ToInt16(textBox1.Text) + 1);
            newWord();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Convert.ToInt16(textBox2.Text) + 1);
            newWord();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Convert.ToInt16(textBox3.Text) + 1);
            newWord();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(Convert.ToInt16(textBox4.Text) + 1);
            newWord();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(Convert.ToInt16(textBox5.Text) + 1);
            newWord();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(Convert.ToInt16(textBox6.Text) + 1);
            newWord();
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Convert.ToInt16(textBox1.Text) - 1);
            newWord();
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Convert.ToInt16(textBox2.Text) - 1);
            newWord();
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Convert.ToInt16(textBox3.Text) - 1);
            newWord();
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(Convert.ToInt16(textBox4.Text) - 1);
            newWord();
        }

        private void textBox6_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(Convert.ToInt16(textBox5.Text) - 1);
            newWord();
        }

        private void timerWord_Tick(object sender, EventArgs e)
        {
            wordTime++;
            labelTimeWord.Text = Convert.ToString(wordTime);
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            gameTime++;
            labelTimeGame.Text = Convert.ToString(gameTime);
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(Convert.ToInt16(textBox6.Text) - 1);
            newWord();
        }
    }
}
