using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projektas.Repository;
using System.Data.SqlClient;

namespace projektas
{
    public partial class TeacherMenu : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Server=LOPTEPAS;Database=praktika;User Id=sa;Password=123456");


        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        DataTable dt2;
        SqlDataAdapter da2;
        DataSet ds2;
        public TeacherMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button4.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = true;
            textBox4.Visible = true;
            button5.Visible = true;
        }

        private void TeacherMenu_Load(object sender, EventArgs e)
        {
            BindData();
        }


        public void BindData()
        {
            UserRepository repository = new UserRepository();
            string teacher_id = repository.GetUserId(Form1.LoggedInUser.GetUserName());


            conn.Open();
            SqlCommand cmd = new SqlCommand("select id, name, group_id from subject where teacher_id=@teacher_id", conn);
            da2 = new SqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
            da2.Fill(ds2);
            comboBox1.DataSource = ds2.Tables[0];
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "ID";
            comboBox1.Enabled = true;
            this.comboBox1.SelectedIndex = 0;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            //Fill grades--------------------------------------------------
            listView1.Columns.Add("ID", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("Surname", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("Grade", 60, HorizontalAlignment.Center);
            listView1.View = View.Details;

            int fid;
            bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);

            conn.Open();
            SqlCommand cmd = new SqlCommand("select grades.id, [users].name, [users].surname, grades.grade from [grades] " +
                "INNER JOIN [users] ON grades.student_id=[users].id WHERE grades.subject_id=@subject_id", conn);
            UserRepository repository = new UserRepository();

            cmd.Parameters.AddWithValue("@subject_id", fid);
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
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button4.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;
            textBox4.Visible = false;
            button5.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                GradesRepository repository = new GradesRepository();
                repository.CheckGradeExistence(textBox4.Text);
                repository.DeleteGrade(textBox4.Text);
                Scan();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error message: " + exc.Message);
            }
        }

        public void Scan()
        {
            listView1.Clear();
            //Fill grades--------------------------------------------------
            listView1.Columns.Add("ID", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("Surname", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("Grade", 60, HorizontalAlignment.Center);
            listView1.View = View.Details;

            int fid;
            bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);

            conn.Open();
            SqlCommand cmd = new SqlCommand("select grades.id, [users].name, [users].surname, grades.grade from [grades] " +
                "INNER JOIN [users] ON grades.student_id=[users].id WHERE grades.subject_id=@subject_id", conn);
            UserRepository repository = new UserRepository();

            cmd.Parameters.AddWithValue("@subject_id", fid);
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
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int fid;
            bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);

            GradesRepository repository = new GradesRepository();
            UserRepository repository1 = new UserRepository();
            string userid = repository1.GetUserIdNameSurname(textBox1.Text, textBox2.Text);
            repository.AddGrade(fid, userid, textBox3.Text, repository1.GetUserGroup(userid));

            Scan();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
