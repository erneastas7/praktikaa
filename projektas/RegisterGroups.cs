using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using projektas.Repository;

namespace projektas
{


   

    public partial class RegisterGroups : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Server=LOPTEPAS;Database=praktika;User Id=sa;Password=123456");
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;



        public RegisterGroups()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RegisterGroups_Load(object sender, EventArgs e)

        {

            this.groupsTableAdapter.Fill(this.praktikaDataSet.groups);

            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("Name", 70, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from groups", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            conn.Close();

            dt = ds.Tables["testTable"];
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = true;
            textBox1.Visible = true;                    
            button1.Visible = true; 
            button2.Visible = false;
            label6.Visible = false;
            label7.Visible = true;
            comboBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;
            textBox1.Visible = true;      
            button1.Visible = false;                 
            button2.Visible = true;
            label6.Visible = true;
            label7.Visible = false;
            comboBox1.Visible = true;
        }


        public void  Scan()
        {
            listView1.Clear();

            listView1.Columns.Add("ID", 60);
            listView1.Columns.Add("Name", 70, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from groups", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            conn.Close();

            dt = ds.Tables["testTable"];
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GroupRepository repository = new GroupRepository();
            repository.AddGroup(textBox1.Text);

            MessageBox.Show(" Group is added");

            Scan();

            this.groupsTableAdapter.Fill(this.praktikaDataSet.groups);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this group? Group will be deleted forever", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    int fid;
                    bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);
                    
                  

                    GroupRepository repository = new GroupRepository();


                   repository.RemoveGroup(fid);
                   
                   Scan();

                   this.groupsTableAdapter.Fill(this.praktikaDataSet.groups);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error message: " + exc.Message);
                }
            }
            else if (dr == DialogResult.No)
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
