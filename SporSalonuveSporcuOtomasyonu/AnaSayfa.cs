using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sporsalonuotomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeEkle uyeekle=new UyeEkle();
            uyeekle.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UyeleriGoruntule ugoruntule = new UyeleriGoruntule();
            ugoruntule.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuncelleSil guncelle=new GuncelleSil();
            guncelle.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Odeme odeme=new Odeme();
            odeme.Show();
            this.Hide();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UyeProgramlariveBilgileri programekle = new UyeProgramlariveBilgileri();
            programekle.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UyeProgramlariGuncelle programguncelle = new UyeProgramlariGuncelle();
            programguncelle.Show();
            this.Hide();
        }
    }
}
