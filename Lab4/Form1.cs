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

namespace Lab4
{
    public partial class Form1 : Form
    {
            
        private SqlConnection conn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = QLOTO; Integrated Security = True; TrustServerCertificate=True;");

        private void LoadDtgv()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("select * from Oto", conn);
            DataTable dataTable = new DataTable();
            cmd.Fill(dataTable);
            oto.DataSource = dataTable;
        }

        private void GetDataDtgv()
        {
            if (oto != null && oto.Rows.Count > 0)
            {
                int i = oto.CurrentRow.Index;
                maxe.Text = oto.Rows[i].Cells[0].Value.ToString();
                tenxe.Text = oto.Rows[i].Cells[1].Value.ToString();
                hangxe.Text = oto.Rows[i].Cells[2].Value.ToString();
                giaxe.Text = oto.Rows[i].Cells[3].Value.ToString();
                namsx.Text = oto.Rows[i].Cells[4].Value.ToString();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            LoadDtgv();
        }

        private void them_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Oto values (@MaXe, @TenXe, @HangXe, @GiaXe, @NamSX)", conn);
            cmd.Parameters.AddWithValue("@MaXe", maxe.Text);
            cmd.Parameters.AddWithValue("@TenXe", tenxe.Text);
            cmd.Parameters.AddWithValue("@HangXe", hangxe.Text);
            cmd.Parameters.AddWithValue("@GiaXe", giaxe.Text);
            cmd.Parameters.AddWithValue("@NamSX", namsx.Text);
            cmd.ExecuteNonQuery();
            LoadDtgv();
        }

        private void sua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Oto set TenXe = @TenXe, HangXe = @HangXe, GiaXe = @GiaXe, NamSX = @NamSX where MaXe = @MaXe", conn);
            cmd.Parameters.AddWithValue("@MaXe", maxe.Text);
            cmd.Parameters.AddWithValue("@TenXe", tenxe.Text);
            cmd.Parameters.AddWithValue("@HangXe", hangxe.Text);
            cmd.Parameters.AddWithValue("@GiaXe", giaxe.Text);
            cmd.Parameters.AddWithValue("@NamSX", namsx.Text);
            cmd.ExecuteNonQuery();
            LoadDtgv();
        }

        private void oto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataDtgv() ;
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Oto where MaXe = @MaXe", conn);
            cmd.Parameters.AddWithValue("@MaXe", maxe.Text);
            cmd.ExecuteNonQuery();
            LoadDtgv(); 
        }
    }
}
