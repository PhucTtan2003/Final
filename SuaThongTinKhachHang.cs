using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class SuaThongTinKhachHang : Form
    {
        public SuaThongTinKhachHang()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Server=HUYNH-TAN; Database=QLCHOCO; Integrated Security = true";

        private void laydanhsachkhachhang()
        {
            SqlConnection comn = new SqlConnection(chuoiketnoi);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG", comn);

            DataTable dtKHACHHANG = new DataTable();
            da.Fill(dtKHACHHANG);


        }
        private void SuaThongTinKhachHang_Load(object sender, EventArgs e)
        {

            laydanhsachkhachhang();
        }

            private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string sqlUpdate = "UPDATE KHACHHANG SET HOTEN = @HOTEN, DIACHI = @DIACHI, SODIENTHOAI= @SODIENTHOAI WHERE  MAKH = @MAKH ";
                MessageBox.Show(sqlUpdate);
                SqlConnection conn = new SqlConnection(chuoiketnoi);
                SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                cmd.Parameters.AddWithValue("@HOTEN", txthoten.Text);
                cmd.Parameters.AddWithValue("@DIACHI", txtdiachi.Text);
                cmd.Parameters.AddWithValue("@SODIENTHOAI", txtsdt.Text); // Nếu đây là số điện thoại, nên là txtdienthoai.Text chứ không phải là txtdiachi.Text
                cmd.Parameters.AddWithValue("@MAKH", txtid.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                laydanhsachkhachhang();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

