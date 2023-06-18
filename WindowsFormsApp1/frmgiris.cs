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
    public partial class frmgiris : Form
    {
        baglantisinif bgl = new baglantisinif();

        public frmgiris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtgiris_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(bgl.adres);
            conn.Open();
            SqlCommand komut1 = new SqlCommand("select * From Tbl_yonetici where kullaniciAd=@b1 and sifre=@b2", conn);
            komut1.Parameters.AddWithValue("@b1",txtkullaciciadi.Text);
            komut1.Parameters.AddWithValue("@b2", txtpassword.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            if (dr1.Read())
            {
                frmanaform frm = new frmanaform();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı giriş yaptınız , tekrar deneyiniz  ");
            }

            conn.Close();
        }

        private void frmgiris_Load(object sender, EventArgs e)
        {

        }
    }
}
