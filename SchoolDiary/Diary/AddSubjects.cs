using DiaryData2;
using SchoolDiary.ConnectiontoBase;
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
        Studenti stud;
        public AddSubjects(DiaryData2.Studenti st)
        {
            InitializeComponent();
             stud= st;
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
            LoadDGV();
        }

        private void LoadDGV()
        {
            var data = baza.SubjectsStudents.Where(x => x.Student.Id == stud.Id).ToList();
            List<itoSubjectClass> newList= new List<itoSubjectClass>();
            foreach (var i in data)
            {
                itoSubjectClass newObject=new itoSubjectClass();
                newObject.Id = i.Id;
                newObject.Student = i.Student.Ime;
                newObject.Subject = i.Subjects.Name;
                newObject.Grade = i.Grade;
                newList.Add( newObject );
            }
            dataGridView1.DataSource = newList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SubjectsStudent subStud = new SubjectsStudent();
            subStud.Student = stud;
            subStud.Subjects = cmbSubjects.SelectedItem as Subjects;
            subStud.Grade = int.Parse(cmbGrade.SelectedItem.ToString());
            baza.SubjectsStudents.Add(subStud);
            baza.SaveChanges();
        }
    }
}
class itoSubjectClass
{
    public int Id { get; set; }
    public string Student { get; set; }
    public string Subject { get; set; }
    public int Grade { get; set; }
}
