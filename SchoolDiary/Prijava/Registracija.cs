using DiaryData2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDiary.Prijava
{
    public partial class Registracija : Form
    {
        DiaryData2.DiaryDBContext ctb = ConnectionToBase._base;
        public Registracija()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            GenerisiKorIme();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GenerisiKorIme();
        }

        private void GenerisiKorIme()
        {
            txtKorisnickoIme.Text = $"{textBox1.Text}.{textBox2.Text}";
        }

        private void txtLozinka_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registracija_Load(object sender, EventArgs e)
        {
            txtLozinka.Text += Generator.GenerisLozinku();
            txtKorisnickoIme.Text += textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Nastavnici _nastavnik = new Nastavnici
            {
                Ime = textBox1.Text,
                Prezime = textBox2.Text,
                StrucnaSprema = textBox3.Text,
                DatumRodjenja = dateTimePicker1.Value,
                KorisnickoIme = txtKorisnickoIme.Text,
                Sifra = txtLozinka.Text
            };
            ctb.Nastavnici.Add(_nastavnik);
            ctb.SaveChanges();
            Close();
        }
        
    }
    public class Generator
    {
        public static string GenerisLozinku(int brojZnakova = 10)
        {
            var lozinka = "";
            var dozvoljeniKarakteri = "dasp98fdsdfja98fd#$&%&/(2356442";
            var rand = new Random();
            for (int i = 0; i < brojZnakova; i++)
            {
                int lokacijaZnaka = rand.Next(0, dozvoljeniKarakteri.Length);//20
                lozinka += dozvoljeniKarakteri[lokacijaZnaka];//2p#
            }
            return lozinka;



        }
    }
}
