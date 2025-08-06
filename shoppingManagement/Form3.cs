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
using Oracle.ManagedDataAccess.Client;

namespace shoppingManagement
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "Data Source=DESKTOP-DG3SFBV\\SQLEXPRESS;Initial Catalog=TK_MK;Persist Security Info=True;User ID=sa;Password=11082002";
            try
            {
                SqlConnection con = new SqlConnection(connstr);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM stuffinfo WHERE username='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "'", con);
                DataTable data = new DataTable();
                adapter.Fill(data);

                if (data.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Form6 f6 = new Form6(txtUsername.Text, txtPassword.Text);
                    f6.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please check your username & password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
