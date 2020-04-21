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
    public partial class Login : Form
    {
        SqlCommand Cmd;
        SqlConnection Conn;
        SqlDataReader Reader;

        public Login()
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String RoleID = txtRoleID.Text;
            String Password = txtPassword.Text;
            Conn.Open();
            try
            {
                Cmd = new SqlCommand("LoginRole", Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@RoleID", RoleID));
                Cmd.Parameters.Add(new SqlParameter("@Password", Password));
                Reader = Cmd.ExecuteReader();
                Reader.Read();

                RoleID = Reader["RoleID"].ToString();

                Dashboard das = new Dashboard(RoleID);
                das.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show("RoleID or Password is Invalid");
            }
            Conn.Close();
        }

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
