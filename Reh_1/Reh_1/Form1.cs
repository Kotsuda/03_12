using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Reh_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            textBox1.Text = dialog.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Выберите файл");
            }
            else
            {

                string[] lines = File.ReadAllLines(textBox1.Text);
                foreach (string s in lines)
                {
                    richTextBox1.Text += s + "\n";

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim().Count() != 0)
            {
                string tex = richTextBox1.Text;
                int k = 0;
                int x = 0;
                foreach (char s in tex)
                {

                    if (s.ToString() == "\n")
                    {
                        tex = tex.Replace(s.ToString(), "");
                        k++;
                    }
                }
                richTextBox2.Text = richTextBox2.Text + $"Перевод строки - {k}\n";
                k = 0;

                foreach (char s in tex)
                {

                    if (s.ToString() == " ")
                    {
                        tex = tex.Replace(s.ToString(), "");
                        k++;
                    }
                }
                richTextBox2.Text = richTextBox2.Text + $"Пробелы - {k}\n";

                while (tex.Length > 0)
                {
                    k = 0;
                    char c = tex[0];
                    foreach (char s in tex)
                    {
                        x = x + 1;
                        if (c == s)
                        {
                            k++;
                        }
                    }
                    tex = tex.Replace(c.ToString(), "");
                    richTextBox1.Text = tex;
                    richTextBox2.Text = richTextBox2.Text + $"{c} - {k}\n";
                }
            }
            else
            {
                MessageBox.Show($"Выбирете файл");
            }
        }
    }
}
