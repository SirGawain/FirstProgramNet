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

        public MainForm()
        {
            InitializeComponent();
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
    }
}
