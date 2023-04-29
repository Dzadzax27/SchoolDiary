using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDiary.Diary
{
    public partial class Students : Form
    {
        public Students(int num)
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if(textBox1.Width>300)
            {
                textBox1.Width = 0;
                iconButton3.Show();
            }
            else
            {
                textBox1.Width = 400;
                iconButton3.Hide();
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (textBox2.Width > 300)
            {
                textBox2.Width = 0;
                iconButton2.Show();
                iconButton3.Location = new Point(98, 132);
            }
            else
            {
                textBox2.Width = 400;
                iconButton2.Hide();
                iconButton3.Location = new Point(45,132);
            }
        }
    }
}
