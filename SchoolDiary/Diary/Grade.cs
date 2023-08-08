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
using System.Windows.Navigation;

namespace SchoolDiary.Diary
{
    public partial class Grade : Form
    {
        Nastavnici nastavnik;
        public Grade(Nastavnici nastavnik)
        {
            InitializeComponent();
            this.nastavnik= nastavnik;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Prosirenje();
        }
        public void Prosirenje()
        {
            if (this.panelMenu.Width >= 200)
            {
                panelMenu.Width = 100;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button btnMenu in panelMenu.Controls.OfType<Button>())
                {
                    btnMenu.Width = 100;
                    btnMenu.Text = "";
                    btnMenu.ImageAlign = ContentAlignment.MiddleCenter;
                    btnMenu.Padding = new Padding(0);
                }
            }
            else
            {
                panelMenu.Width = 200;
                foreach (Button btnMenu2 in panelMenu.Controls.OfType<Button>())
                {
                    if (btnMenu2 != btnMenu && btnMenu2 != btnSkola)
                        btnMenu2.Text = btnMenu2.Tag.ToString();
                    btnMenu2.Width = 200;
                    btnMenu2.Padding = new Padding(10, 0, 0, 0);
                    btnMenu2.ImageAlign = ContentAlignment.MiddleLeft;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void LoadCombo()
        {
            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9};
            comboBox1.DataSource= list;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form frm = new Licni_podaci(nastavnik);
            frm.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form frm = new Grade(nastavnik);
            frm.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            int num=int.Parse(comboBox1.SelectedItem.ToString());
            Form frm = new Students(num);
            frm.ShowDialog();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Form frm = new Licni_podaci(nastavnik);
            frm.Show();
            this.Hide();
        }

        private void btnSkola_Click(object sender, EventArgs e)
        {
            Form frm = new Pocetna(nastavnik);
            frm.Show();
            this.Hide();

        }

        private void Grade_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
    }
}
