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
    public partial class RegisterSubject : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Server=LOPTEPAS;Database=praktika;User Id=sa;Password=123456");
        DataTable dt1;
        SqlDataAdapter da1;
        DataSet ds1; 
        
        public RegisterSubject()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            label1.Visible = true;
            button1.Visible = true;

            label4.Visible = true;
            comboBox2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label2.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button4.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            label1.Visible = false;
            button1.Visible = false;

            label4.Visible = true;
            comboBox2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label2.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            button4.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegisterSubject_Load(object sender, EventArgs e)
        {
            
            this.subjectTableAdapter.Fill(this.praktikaDataSet.subject);

            listView1.Clear();
            listView1.Columns.Add("Subject Name", 120);
            listView1.Columns.Add("Teacher Name", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("Teacher Surname", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("Group", 70, HorizontalAlignment.Right);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT subject.name, [users].name, [users].surname, groups.name " +
                "FROM subject INNER JOIN [users] ON subject.teacher_id=[users].id " +
                "INNER JOIN groups ON subject.group_id=groups.id", conn);
            da1 = new SqlDataAdapter(cmd1);
            ds1 = new DataSet();
            da1.Fill(ds1, "testTable1");
            conn.Close();
            
            dt1 = ds1.Tables["testTable1"];
            int j;
            for (j = 0; j <= dt1.Rows.Count - 1; j++)
            {
                listView1.Items.Add(dt1.Rows[j].ItemArray[0].ToString());
                listView1.Items[j].SubItems.Add(dt1.Rows[j].ItemArray[1].ToString());
                listView1.Items[j].SubItems.Add(dt1.Rows[j].ItemArray[2].ToString());
                listView1.Items[j].SubItems.Add(dt1.Rows[j].ItemArray[3].ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int fid;
            bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);

            GroupRepository repository = new GroupRepository();
            repository.DeleteSubject(fid);
            Scan();
            this.subjectTableAdapter.Fill(this.praktikaDataSet.subject);
        }

        public void Scan()
        {
            listView1.Clear();
            listView1.Columns.Add("Subject Name", 120);
            listView1.Columns.Add("Teacher Name", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("Teacher Surname", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("Group", 70, HorizontalAlignment.Right);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT subject.name, [users].name, [users].surname, groups.name " +
                "FROM subject INNER JOIN [users] ON subject.teacher_id=[users].id " +
                "INNER JOIN groups ON subject.group_id=groups.id", conn);
            da1 = new SqlDataAdapter(cmd1);
            ds1 = new DataSet();
            da1.Fill(ds1, "testTable1");
            conn.Close();

            dt1 = ds1.Tables["testTable1"];
            int j;
            for (j = 0; j <= dt1.Rows.Count - 1; j++)
            {
                listView1.Items.Add(dt1.Rows[j].ItemArray[0].ToString());
                listView1.Items[j].SubItems.Add(dt1.Rows[j].ItemArray[1].ToString());
                listView1.Items[j].SubItems.Add(dt1.Rows[j].ItemArray[2].ToString());
                listView1.Items[j].SubItems.Add(dt1.Rows[j].ItemArray[3].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
