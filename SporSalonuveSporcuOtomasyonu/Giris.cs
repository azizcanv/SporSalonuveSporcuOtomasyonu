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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciTb.Text = "";
            sifreTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(KullaniciTb.Text =="" || sifreTb.Text =="")
            {
                MessageBox.Show("Eksik Bilgi!");
            }
            else if(KullaniciTb.Text =="admin" && sifreTb.Text =="123456")
            {
                AnaSayfa anasayfa=new AnaSayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali Kullanici Adi ya da Sifre!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
