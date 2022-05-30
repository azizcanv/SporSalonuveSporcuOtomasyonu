using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sporsalonuotomasyonu
{
    public partial class UyeleriGoruntule : Form
    {
        public UyeleriGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\azizc\Documents\sporsalonuDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from uyeTbl";
            SqlDataAdapter sda=new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder=new SqlCommandBuilder();
            var ds=new DataSet();
            sda.Fill(ds);
            uyeDGV.DataSource=ds.Tables[0];
            baglanti.Close();
        }

        private void AdFiltreleme()
        {
            baglanti.Open();
            string query = "select * from uyeTbl where uyeAdSoyad='" + uyeAraTb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            uyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void UyeleriGoruntule_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdFiltreleme();
            uyeAraTb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyeler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
