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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\azizc\Documents\sporsalonuDb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void FillName()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select uyeAdSoyad from uyeTbl",baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt=new DataTable();
            dt.Columns.Add("uyeAdSoyad",typeof(string));
            dt.Load(rdr);
            AdSoyadCb.ValueMember = "uyeAdSoyad";
            AdSoyadCb.DataSource = dt;
            baglanti.Close();
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from odemeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            OdemeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void AdFiltreleme()
        {
            baglanti.Open();
            string query = "select * from odemeTbl where odemeUye='" + AraTb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            OdemeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            FillName();
            uyeler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdSoyadCb.Text = "";
            OdemeTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(AdSoyadCb.Text=="" || OdemeTb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi!");
            }
            else
            {
                string odemeperiyot = Periyot.Value.Month.ToString()+Periyot.Value.Year.ToString();
                baglanti.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from odemeTbl where odemeUye='" + AdSoyadCb.SelectedValue.ToString() + "' and odemeAy='"+odemeperiyot+"'",baglanti);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows[0][0].ToString()=="1")
                {
                    MessageBox.Show("Zaten Odeme Yapildi!");
                }
                else
                {
                    string query="insert into odemeTbl values('" + odemeperiyot + "','" + AdSoyadCb.SelectedValue.ToString() + "'," + OdemeTb.Text + ")";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tutar Basariyla Odendi");
                }
                baglanti.Close();
                uyeler();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdFiltreleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uyeler();
            AraTb.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
