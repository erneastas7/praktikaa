using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntrasAtsiskaitymas;
using projektas.Repository;
using static projektas.Repository.UserRepository;
using System.Data.SqlClient;

namespace projektas
{
    public partial class RegisterStudent : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Server=LOPTEPAS;Database=praktika;User Id=sa;Password=123456");
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;





        public RegisterStudent()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RegisterStudent_Load(object sender, EventArgs e)
        {

            this.groupsTableAdapter.Fill(this.praktikaDataSet.groups);



            listView1.Columns.Add("ID", 45);
            listView1.Columns.Add("Name", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Surname", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Birthdate", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Username", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("Password", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Type", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Group ID", 60, HorizontalAlignment.Right);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [users] where type = 'Student' ", conn);
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
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString().Substring(0, 10));
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text.Trim(' ').Equals("") || textBox1.Text == null)
                    throw new Exception("Empty Name!");
                else if (textBox2.Text.Trim(' ').Equals("") || textBox2.Text == null)
                    throw new Exception("Empty Surname!");
                
                int stringtoint;
                bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out stringtoint);
                User user = new User(textBox1.Text, textBox2.Text, dateTimePicker1.Value, textBox1.Text.ToLower() + "." + textBox2.Text.ToLower(), textBox2.Text.ToLower(), "Student", stringtoint.ToString());
                UserRepository repository = new UserRepository();
                user.GetType();
                user.SetUserType("Student");
                repository.ScanLogin(textBox1.Text.ToLower() + "." + textBox2.Text.ToLower());
                //repository.CheckLogin(usernameTextBox.Text);
                repository.RegisterStudent(user);
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Registration succesfull");
                Scan();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error message: " + exc.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dateTimePicker1.Visible = true;
            comboBox1.Visible = true;
            button1.Visible = true;

            label5.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            label6.Visible = false;
            label7.Visible = true;
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            dateTimePicker1.Visible = false;
            comboBox1.Visible = false;
            button1.Visible = false;

            label5.Visible = true;
            textBox3.Visible = true;
            button2.Visible = true;
            label6.Visible = true;
            label7.Visible = false;
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Scan()
        {
            listView1.Clear();

            listView1.Columns.Add("ID", 60);
            listView1.Columns.Add("Name", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Surname", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Birthdate", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Username", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("Password", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Type", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Group ID", 60, HorizontalAlignment.Right);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [users] where type = 'Student' ", conn);
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
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString().Substring(0, 10));
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this student? All grades will be removed and student too", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    
                    UserRepository repository = new UserRepository();
                    repository.ScanStudent(textBox3.Text);
                    repository.RemoveGrades(textBox3.Text);
                    repository.RemoveStudent(textBox3.Text);
                    Scan();
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
    }
}
