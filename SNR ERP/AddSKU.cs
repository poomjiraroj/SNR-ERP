using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNR_ERP
{
    public partial class AddSKU : Form
    {
        public AddSKU()
        {
            InitializeComponent();
        }

        private void AddSKU_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("ต้องการปิดจริงหรอ","คุณกำลังจัดการสินค้า",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
