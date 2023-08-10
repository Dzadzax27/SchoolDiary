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
    public partial class NewSubject : Form
    {
        DiaryDBContext baza = ConnectionToBase._base;

        public NewSubject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && isThereTheSame())
            { 
                Subjects sub=new Subjects();
                sub.Name = textBox1.Text;
                baza.Subjects.Add(sub);
                baza.SaveChanges();
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("There is already item with that name");
            }
        }

        private bool isThereTheSame()
        {
            foreach (var subj in baza.Subjects)
            {
                if (textBox1.Text == subj.Name)
                    return false;
            }
            return true;
        }
    }
}
