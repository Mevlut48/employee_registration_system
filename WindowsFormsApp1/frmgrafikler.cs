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

namespace WindowsFormsApp1
{
    public partial class frmgrafikler : Form
    {
        baglantisinif bgl = new baglantisinif();

        public frmgrafikler()
        {
            InitializeComponent();
        }

        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(bgl.adres);
            //GRAFİK 1 
            conn.Open();
            SqlCommand komut1 = new SqlCommand("select persehir,count(*) from Tbl_personel group by persehir", conn);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["şehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            conn.Close();

            //GRAFİK 2 
            conn.Open();
            SqlCommand komut2 = new SqlCommand("select permeslek,avg(permaaş) from tbl_personel group by permeslek",conn);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["meslek-maaş"].Points.AddXY(dr2[0], dr2[1]);   
            }
            conn.Close();
        }
    }
}
