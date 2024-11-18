using Microsoft.Data.SqlClient;
using System.Data;

namespace DBMS.SLQ_QueryData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void connect()
        {
            string server = @"LAPTOP-7KNTOGM4\SQLEXPRESS02";
            string db = "Minimart";
            string strCon = string.Format(@"Data Source={0};Initial Catalog={1};"
            + "Integrated Security=True;Encrypt=False", server, db);
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        private void disconnect()
        {
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            /*string sql = "SELECT * FROM Products";
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];*/
            showData("SELECT * FROM Products");
        }
        private void showData(string sql)
        {
            //string sql = "SELECT * FROM Products";
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData("SELECT EmployeeID,Title+FirstName+''+LastName EmpName, Position\r\nFROM Employees");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showData("SELECT * FROM Categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showData("SELECT * FROM Products");
        }
    }
}
