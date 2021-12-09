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

namespace Banking
{
    public partial class Form2 : Form
    {
        public static Form2 instance;

        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bavel\source\repos\Banking\Database1.mdf;Integrated Security=True");

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand sm = new SqlCommand("insert into username values('"+textBoxName.Text+"','"+textBoxPin.Text+"','"+textBoxBalance.Text+"')",con1);

            con1.Open();

            sm.ExecuteNonQuery();

            con1.Close();

            MessageBox.Show("Data Saved Successfully");
        }
    }
}
