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
using System.Xml.Linq;

namespace Design
{
    public partial class QL_Tài_Khoản___Khách_Hàng_Thân_Thiết : Form
    {

        private readonly SuaThongTinKhachHang suaThongTinKhachHang;
        public QL_Tài_Khoản___Khách_Hàng_Thân_Thiết()
        {
            InitializeComponent();
            suaThongTinKhachHang = new SuaThongTinKhachHang();
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void QL_Tài_Khoản___Khách_Hàng_Thân_Thiết_Load(object sender, EventArgs e)
        {
            laydanhsachkhachhang();
        }
        string chuoiketnoi = @"Server=HUYNH-TAN; Database=QLCHOCO; Integrated Security = true";

        private void laydanhsachkhachhang()
        {
            SqlConnection comn = new SqlConnection(chuoiketnoi);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG", comn);

            DataTable dtKHACHHANG = new DataTable();
            da.Fill(dtKHACHHANG);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dtKHACHHANG;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtb1.Text.Trim();

            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    string query = "SELECT * FROM KHACHHANG WHERE SODIENTHOAI = @phoneNumber";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;

                        // Assuming you have text boxes named txtName, txtAddress, txtEmail etc.
                        DataRow row = dataTable.Rows[0];
                        txthoten.Text = row["HOTEN"].ToString();
                        txtsdt.Text = row["SODIENTHOAI"].ToString();
                        txtdiachi.Text = row["DIACHI"].ToString();
                        // Add more fields as necessary
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin khách hàng.");

                        // Clear text boxes if no customer information is found
                        txthoten.Text = string.Empty;
                        txtsdt.Text = string.Empty;
                        txtdiachi.Text = string.Empty;
                        // Clear more fields as necessary
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        private void btSua_Click(object sender, EventArgs e)
        {
            try 
            {
                suaThongTinKhachHang.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlInsert = $"INSERT INTO KHACHHANG(HOTEN,DIACHI,SODIENTHOAI,DIEMTICHLUY) VALUES('{txthoten.Text}','{txtdiachi.Text}','{txtsdt.Text}','{txtpoint.Text}')";
                MessageBox.Show(sqlInsert);
                SqlConnection conn = new SqlConnection(chuoiketnoi);
                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
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

        private void button13_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txthoten.Text = string.Empty;
            txtdiachi.Text = string.Empty;
            txtsdt.Text = string.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txthoten.Text = dataGridView1.Rows[e.RowIndex].Cells["HOTEN"].Value.ToString();
            txtsdt.Text = dataGridView1.Rows[e.RowIndex].Cells["SODIENTHOAI"].Value.ToString();
            txtdiachi.Text = dataGridView1.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
