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
    public partial class AddSubjects : Form
    {
        DiaryDBContext baza = ConnectionToBase._base;
        public AddSubjects(DiaryData2.Studenti st)
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form frm = new NewSubject();
            frm.ShowDialog();
        }

        private void AddSubjects_Load(object sender, EventArgs e)
        {
            cmbSubjects.DataSource = baza.Subjects.ToList();
            cmbSubjects.DisplayMember = "Name";
            List<int>  list = new List<int> { 1,2,3,4,5};
            cmbGrade.DataSource = list;
        }
    }
}
