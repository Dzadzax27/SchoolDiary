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

namespace SchoolDiary
{
    public partial class LogIn : Form
    {
        DiaryData2.DiaryDBContext ctb = ConnectionToBase._base;
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if(ValidacijaPasvorda())
            {
                Nastavnici nastavnik = ctb.Nastavnici.Where(x => x.KorisnickoIme == textBox1.Text).First();
                Form frm = new Diary.Pocetna(nastavnik);
                
                frm.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Neuspjesna prijava!");
            }
        }

        private bool ValidacijaPasvorda()
        {
            foreach (var nastavnik in ctb.Nastavnici)
            {
                if (textBox1.Text == nastavnik.KorisnickoIme && textBox2.Text == nastavnik.Sifra)
                   return true;
            }
            return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new Prijava.Registracija();
            frm.ShowDialog();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
