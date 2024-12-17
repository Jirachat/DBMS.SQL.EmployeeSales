using Microsoft.Data.SqlClient;
using System.Data;

namespace DBMS.SQL.EmployeeSales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ประกาศตัวแปร connect
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void connectDB()
        {
            string server = @"LAPTOP-5N08LR59\SQLEXPRESS";
            string db = "Northwind";
            string strCon = string.Format(@"Data Source={0}; Initial Catalog={1};"
                      + "Integrated Security=True;Encrypt=False", server, db);
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        private void disconnectDB()
        {
            conn.Close();
        }

        private void showdata(string sql, DataGridView dgv)
        {
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgv.DataSource = ds.Tables[0];
        }
        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectDB();
            string sqlQuery = "select * from EmployeeList";
            showdata(sqlQuery, dgvEmployees);
        }


        private void dgvEmployees_CellMouseUp_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                {
                    int id = Convert.ToInt32(dgvEmployees.CurrentRow.Cells[0].Value);
                    string sqlQuery = "select * from OrderList2 where EmployeeID = @id";
                    cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dgvOrderList.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
