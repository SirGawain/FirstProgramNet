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
        char[] mas_sym = new char[] {'&','%','@','+','-', '?' ,'|','!' };
        Dictionary <string, double> metrica;

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            metrica = new Dictionary <string, double>();
            metrica.Add("mm", 1);
            metrica.Add("cm", 10);
            metrica.Add("dm", 100);
            metrica.Add("m", 1000);
            metrica.Add("km", 1000000);
            metrica.Add("mile", 1609344);
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
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(2, true);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
                return;
            string password = "";
            for(int i=0; i<numericUpDown3.Value; i++)
            {
                int n = rnd.Next(0, checkedListBox1.CheckedItems.Count);
                switch(n)
                {
                    case 0:
                        password += rnd.Next(10).ToString();
                        break;
                    case 1:
                        password += Convert.ToChar(rnd.Next(65, 88)); //коды прописных букв
                        break;
                    case 2:
                        password += Convert.ToChar(rnd.Next(97, 122)); //коды строчных букв
                        break;
                    default:
                        password += mas_sym[rnd.Next(mas_sym.Length)];
                        break;
                }
            }
            textBox2.Text = password;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double m1 = metrica[comboBox1.Text];
            double m2 = metrica[comboBox2.Text];
            double n = Convert.ToDouble(textBox3.Text);
            textBox4.Text = (n * m1 / m2).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string temp;
            temp = comboBox1.Text;
            comboBox1.Text = comboBox2.Text;
            comboBox2.Text = temp;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.Text)
            {
                case "длина":
                    metrica.Clear();
                    metrica.Add("mm", 1);
                    metrica.Add("cm", 10);
                    metrica.Add("dm", 100);
                    metrica.Add("m", 1000);
                    metrica.Add("km", 1000000);
                    metrica.Add("mile", 1609344);
                    ///////////////////////////
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("mm");
                    comboBox1.Items.Add("cm");
                    comboBox1.Items.Add("dm");
                    comboBox1.Items.Add("m");
                    comboBox1.Items.Add("km");
                    comboBox1.Items.Add("mile");
                    comboBox1.Text="mm";
                    //////////////////////////////
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("mm");
                    comboBox2.Items.Add("cm");
                    comboBox2.Items.Add("dm");
                    comboBox2.Items.Add("m");
                    comboBox2.Items.Add("km");
                    comboBox2.Items.Add("mile");
                    comboBox2.Text = "mm";
                    break;
                case "вес":
                    metrica.Clear();
                    metrica.Add("g", 1);
                    metrica.Add("kg", 1000);
                    metrica.Add("t", 1000000);
                    metrica.Add("lb", 453.6);
                    ///////////////////////////
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("g");
                    comboBox1.Items.Add("kg");
                    comboBox1.Items.Add("t");
                    comboBox1.Items.Add("lb");
                    comboBox1.Text = "g";
                    //////////////////////////////
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("g");
                    comboBox2.Items.Add("kg");
                    comboBox2.Items.Add("t");
                    comboBox2.Items.Add("lb");
                    comboBox2.Text = "g";
                    break;
                default:
                    break;
            }
        }
    }
}
