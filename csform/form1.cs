using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;    
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wkeysys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Connection to mysql & Importing date from database to Datagrid
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=Replacewithserverip;port=3306;username=Replacewithdatabaseusername;password=Replacewithdatabasepassword");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Replacewithdatabasename.ukey", connection);
                connection.Open();

                //Connection succesfull import from mysql to datagrid
                DataSet ds = new DataSet();
                adapter.Fill(ds, "replacewithtablename");
                dataGridView1.DataSource = ds.Tables["replacewithtablename"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Either you aren't connected to the internet or our key system has fallen please DM ASAP if u believe that the Key system has fallen", "Error", MessageBoxButtons.OK);
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Dude.. Dont leave it blank!");
            }
            else
            {
                var exists = dataGridView1.Rows.Cast<DataGridViewRow>()
                         .Where(row => !row.IsNewRow)
                         .Select(row => row.Cells[0].Value.ToString())
                         .Any(x => this.textBox1.Text == x);

                if (exists)
                {
                    MessageBox.Show("Key is correct");

                }
                if (!exists)
                {
                    MessageBox.Show("Key is incorrect");
                }

            }

        }
    }
}
