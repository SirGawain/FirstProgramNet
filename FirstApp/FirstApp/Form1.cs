using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstApp
{
    public partial class MainForm : Form
    {
        int count = 0;
        Random rnd;

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа мои утилиты, содержит ряд небольших программ, которые могут пригодиться в жизни.", "О программе");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            label1.Text = count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count--;
            label1.Text = count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count=0;
            label1.Text = Convert.ToString(count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value)+1 );
            label2.Text=n.ToString();
            if (checkBox1.Checked == true)
            {
                if (textBox1.Text.IndexOf(n.ToString()) == -1)
                    textBox1.AppendText(n + "\n");
            }
            else
            {
                textBox1.AppendText(n + "\n");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void tsmiInsertDate_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(DateTime.Now.ToShortDateString()+"\n");
        }

        private void tsmiInsertTime_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SaveFile("natepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        void LoadText()
        {
            try
            {
                richTextBox1.LoadFile("natepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadText(); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadText();
        }
    }
}
