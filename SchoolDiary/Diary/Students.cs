using DiaryData2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Xunit;

namespace SchoolDiary.Diary
{
    public partial class Students : Form
    {
        int n;
        DiaryDBContext baza = ConnectionToBase._base;
        public Students(int num)
        {
            InitializeComponent();
            n = num;
            dataGridView1.AutoGenerateColumns = false;
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
            //if (textBox2.Width > 300)
            //{
            //    textBox2.Width = 0;
            //    iconButton2.Show();
            //    iconButton3.Location = new Point(75, 135);
            //}
            //else
            //{
            //    textBox2.Width = 400;
            //    iconButton2.Hide();
            //    iconButton3.Location = new Point(43,135);
            //}
            Form frm = new AddStudent(n);
            frm.ShowDialog();
            LoadDGV();
        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            // Primer provere teksta na dugmetu
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.iconButton3, "Add student");

        }

        private void iconButton2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.iconButton3, "Search for a student");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Students_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV(List<Studenti> stud=null)
        {
            if (stud == null)
            {
                List<Studenti> students = baza.Studenti.ToList();
                dataGridView1.DataSource = students.Where(x => x.Razred == n).ToList();
            }
            else
            {
                dataGridView1.DataSource=stud.Where(x => x.Razred == n).ToList();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var st = dataGridView1.SelectedRows[0].DataBoundItem as Studenti;
            if(e.ColumnIndex==4)
            {
                baza.Studenti.Remove(st);
                baza.SaveChanges();
                LoadDGV();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            var text = textBox1.Text;
            if (text != "")
            {
                var list = baza.Studenti.Where(x => x.Ime.ToLower().Contains(text.ToLower())
                || x.Prezime.ToLower().Contains(text.ToLower())).ToList();
                LoadDGV(list);
            }
            else
                LoadDGV();

        }
    }
}
