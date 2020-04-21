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
    public partial class ProductForm : Form
    {
        SqlCommand Cmd;
        SqlConnection Conn;
        SqlDataReader Reader;
        String RoleID;
        SqlDataAdapter Da;
        DataTable Dt;
        DataSet Ds;

        public ProductForm(String RoleID)
        {
            InitializeComponent();
            String SQL = "Data Source=JISURFACE;Initial Catalog=SNRWareHouseData;Integrated Security=True";
            Conn = new SqlConnection(SQL);
            this.RoleID = RoleID;
            setEmployee();
            setCombobox();
            setGV();
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

        public void setCombobox()
        {
            //Fill Color Combobox
            Conn.Open();
            Cmd = new SqlCommand("SelectColor", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbColor.DataSource = Dt;
            cbColor.DisplayMember = "Color";
            cbColor.ValueMember = "ColorID";
            Conn.Close();

            //Fill Vinyl Combobox
            Conn.Open();
            Cmd = new SqlCommand("SelectVinyl", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbVinyl.DataSource = Dt;
            cbVinyl.DisplayMember = "Vinyl";
            cbVinyl.ValueMember = "VNID";
            Conn.Close();

            //Fill Company Combobox
            Conn.Open();
            Cmd = new SqlCommand("SelectCompany", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbCompany.DataSource = Dt;
            cbCompany.DisplayMember = "CompanyName";
            cbCompany.ValueMember = "CompanyID";
            Conn.Close();

            //Fill Warehouse Combobox
            Conn.Open();
            Cmd = new SqlCommand("SelectWarehouse", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);

            cbWarehouse.DataSource = Dt;
            cbWarehouse.DisplayMember = "WarehouseName";
            cbWarehouse.ValueMember = "WarehouseID";
            Conn.Close();
        }

        private void txtSearchVehicle_TextChanged(object sender, EventArgs e)
        {
            Conn.Open();
            Cmd = new SqlCommand("VehicleProductSearch", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@textSearch", txtSearchVehicle.Text));
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);
            gvProducts.DataSource = Dt;
            Conn.Close();

            gvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void txtSKU_TextChanged(object sender, EventArgs e)
        {
            Conn.Open();
            Cmd = new SqlCommand("SKUProductSearch", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@SKU", txtSKU.Text));
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);
            gvProducts.DataSource = Dt;
            Conn.Close();

            gvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand("SKUbyColor", Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@ColorID", cbColor.SelectedValue.ToString()));
                Da = new SqlDataAdapter(Cmd);
                Dt = new DataTable();
                Da.Fill(Dt);
                gvProducts.DataSource = Dt;
                Conn.Close();

                gvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch(Exception ex)
            {

            }
        }

        private void cbVinyl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand("SKUbyVinyl", Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@VNID", cbVinyl.SelectedValue.ToString()));
                Da = new SqlDataAdapter(Cmd);
                Dt = new DataTable();
                Da.Fill(Dt);
                gvProducts.DataSource = Dt;
                Conn.Close();

                gvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception ex)
            {

            }
        }
        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand("SKUbyCompany", Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@CompanyID", cbCompany.SelectedValue.ToString()));
                Da = new SqlDataAdapter(Cmd);
                Dt = new DataTable();
                Da.Fill(Dt);
                gvProducts.DataSource = Dt;
                Conn.Close();

                gvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch(Exception ex)
            {

            }
        }
        private void cbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand("SKUbyWarehouse", Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@WarehouseID", cbWarehouse.SelectedValue.ToString()));
                Da = new SqlDataAdapter(Cmd);
                Dt = new DataTable();
                Da.Fill(Dt);
                gvProducts.DataSource = Dt;
                Conn.Close();

                gvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch(Exception ex)
            {

            }
        }

        public void setGV()
        {
            Conn.Open();
            Cmd = new SqlCommand("SelectSKU", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Dt = new DataTable();
            Da.Fill(Dt);
            gvProducts.DataSource = Dt;
            Conn.Close();

            gvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void ProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddSKU asku = new AddSKU();
            asku.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            setGV();
            setCombobox();
            txtSearchVehicle.Text = "";
            txtSKU.Text = "";
        }
    }
}
