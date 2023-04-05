using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cipher;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private VigenerHelper vigenerHelper;

        public Form1()
        {
            InitializeComponent();
            vigenerHelper = new VigenerHelper();
        }

        private string prepareText(string text)
        {
            text = text.Trim().ToLower();

            return text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = prepareText(this.userText.Text);
            string key = prepareText(this.userKey.Text);

            if (text.Length == 0)
            {
                MessageBox.Show("Ви не ввели текст!", "Помилка!!!");
            } else if (key.Length == 0)
            {
                MessageBox.Show("Ви не ввели ключ!", "Помилка!!!");
            } else
            {
                this.result.Text = vigenerHelper.getCipher(text, key);
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.result.Text = "";
            this.userText.Text = "";
            this.userKey.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cipher = prepareText(this.userText.Text);
            string key = prepareText(this.userKey.Text);

            if (cipher.Length == 0)
            {
                MessageBox.Show("Ви не ввели текст!", "Помилка!!!");
            }
            else if (key.Length == 0)
            {
                MessageBox.Show("Ви не ввели ключ!", "Помилка!!!");
            }
            else
            {
                this.result.Text = vigenerHelper.getText(cipher, key);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            vigenerHelper.changeAlphabet("Ukr");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            vigenerHelper.changeAlphabet("Eng");
        }
    }
}
