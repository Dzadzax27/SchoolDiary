using DiaryData2;
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
    public partial class AddStudent : Form
    {
        int num;
        DiaryDBContext baza = ConnectionToBase._base;
        public AddStudent(int n)
        {
            InitializeComponent();
            num=n; 
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            comboBox1.Text= num.ToString();
            comboBox1.Enabled= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Studenti student= new Studenti();
            student.Ime = textBox1.Text;
            student.Prezime=textBox2.Text;
            student.Razred = num;
            baza.Studenti.Add(student);
            baza.SaveChanges();
        }
    }
}
