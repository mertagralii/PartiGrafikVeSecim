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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=DBSECİMPROJE;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //İlçe Adlarını Combobox'a getirme.
            bgl.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLİLCE",bgl);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            bgl.Close();

            bgl.Open();
            SqlCommand komut2 = new SqlCommand("SELECT SUM(APARTİ),SUM(BPARTİ),SUM(CPARTİ),SUM(DPARTİ),SUM(EPARTİ) FROM TBLİLCE",bgl);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["PARTİLER"].Points.AddXY("A Parti", dr2[0]);
                chart1.Series["PARTİLER"].Points.AddXY("B Parti", dr2[1]);
                chart1.Series["PARTİLER"].Points.AddXY("C Parti", dr2[2]);
                chart1.Series["PARTİLER"].Points.AddXY("D Parti", dr2[3]);
                chart1.Series["PARTİLER"].Points.AddXY("E Parti", dr2[4]);

            }
            bgl.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut3 = new SqlCommand("SELECT * FROM TBLİLCE WHERE İLCEAD=@P1", bgl);
            komut3.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                progressBar1.Value = int.Parse(dr3[2].ToString());
                progressBar2.Value = int.Parse(dr3[3].ToString());
                progressBar3.Value = int.Parse(dr3[4].ToString());
                progressBar4.Value = int.Parse(dr3[5].ToString());
                progressBar5.Value = int.Parse(dr3[6].ToString());

                LblAParti.Text = dr3[2].ToString();
                LblBParti.Text = dr3[3].ToString();
                LblCParti.Text = dr3[4].ToString();
                LblDParti.Text = dr3[5].ToString();
                LblEParti.Text = dr3[6].ToString();
            }
            bgl.Close ();
        }
    }
}
