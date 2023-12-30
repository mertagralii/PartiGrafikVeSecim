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

namespace Veri_Tabanli_Parti_Seçim_Grafik_İstatistik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=DBSECİMPROJE;Integrated Security=True");
        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm = new FrmGrafikler();
            frm.Show();
        }

        private void BtnOyGiris_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("İNSERT İNTO TBLİLCE (İLCEAD, APARTİ,BPART,CPARTİ,DPARTİ,EPARTİ) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", bgl);
            komut.Parameters.AddWithValue("@P1", TxtİlceAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtAParti.Text);
            komut.Parameters.AddWithValue("@P3", TxtBParti.Text);
            komut.Parameters.AddWithValue("@P4", TxtCParti.Text);
            komut.Parameters.AddWithValue("@P5", TxtDParti.Text);
            komut.Parameters.AddWithValue("@P6", TxtEParti.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Oy Girişi Gerçekleştirildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
