using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Page270_Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Text = "Modal Windows";
            f.Width = 200;
            f.Height = 100;
            f.BackColor = Color.Blue;

            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Text = "Modaless Windows";
            f.Width = 200;
            f.Height = 100;
            f.BackColor = Color.Blue;

            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("오라클자바커뮤니티", "메시지박스", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
