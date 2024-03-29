﻿using DiaryData2;
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
    public partial class Pocetna : Form
    {
        Nastavnici nastavnik;
        public Pocetna(Nastavnici nastavnik)
        {
            InitializeComponent();
            this.nastavnik = nastavnik;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pocetna_Load(object sender, EventArgs e)
        {
            
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Prosirenje();
        }

        public void Prosirenje()
        {
            if (this.panelMenu.Width>=200)
            {
                panelMenu.Width = 100;
                btnMenu.Dock = DockStyle.Top;
                foreach(Button btnMenu in panelMenu.Controls.OfType<Button>())
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
                    if(btnMenu2!=btnMenu && btnMenu2!=btnSkola)
                        btnMenu2.Text = btnMenu2.Tag.ToString();
                    btnMenu2.Width = 200;
                    btnMenu2.Padding = new Padding(10,0,0,0);
                    btnMenu2.ImageAlign = ContentAlignment.MiddleLeft;
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form frm= new Licni_podaci(nastavnik);
            frm.Show();
            this.Hide();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Form frm = new Grade(nastavnik);
            frm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
