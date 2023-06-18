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
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        baglantisinif bgl = new baglantisinif();


        private void frmistatistik_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(bgl.adres);

            //TOPLAM PERSONEL SAYISI  
         conn.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_personel",conn);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                tpslbl.Text = dr1[0].ToString();
            }
         conn.Close();

            //EVLİ PERSONEL SAYISI 
            conn.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_personel where perdurum=1",conn);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                epslbl.Text = dr2[0].ToString();
            }
            conn.Close();

            //BEKAR PERSONEL SAYISI 
            conn.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from tbl_personel where perdurum=0",conn);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                bpslbl.Text = dr3[0].ToString();

            }
            conn.Close();

            //ŞEHİR SAYISI 
            conn.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir)) from tbl_personel",conn);
            SqlDataReader dr4= komut4.ExecuteReader();
            while (dr4.Read())
            {
               şslbl.Text = dr4[0].ToString();
            }
            conn.Close();

            //TOPLAM MAAŞ
            conn.Open();
            SqlCommand komut5 = new SqlCommand("select sum(permaaş) from tbl_personel",conn); 
            SqlDataReader dr5= komut5.ExecuteReader();
            while (dr5.Read())
            {
              tmlbl.Text = dr5[0].ToString();
            }
            conn.Close();
            

            //ORTALAMA MAAŞ 
           conn.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaaş) from tbl_personel", conn);
            SqlDataReader dr6= komut6.ExecuteReader();
            while (dr6.Read())
            {
                omlbl.Text = dr6[0].ToString();
            }
           conn.Close();

        }
    }
}
