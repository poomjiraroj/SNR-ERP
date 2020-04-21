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

namespace SNR_ERP
{
    public partial class Dashboard : Form
    {
        SqlCommand Cmd;
        SqlConnection Conn;
        SqlDataReader Reader;
        String RoleID;

        public Dashboard(String RoleID)
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);
            this.RoleID = RoleID;
            setEmployee();
        }

        public void setEmployee()
        {
            Conn.Open();
            Cmd = new SqlCommand("EmployeeSelect", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));
            Reader = Cmd.ExecuteReader();
            Reader.Read();

            lbEmployee.Text = Reader["RoleID"].ToString() + ' ' + Reader["Employee"].ToString().ToUpper();

            Conn.Close();
        }

        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            ProductForm PF = new ProductForm(RoleID);
            PF.Show();
            this.Hide();
        }
    }
}