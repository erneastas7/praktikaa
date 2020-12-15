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
    public partial class SubjectGrades : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Server=LOPTEPAS;Database=praktika;User Id=sa;Password=123456");
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        public SubjectGrades()
        {
            InitializeComponent();
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SubjectGrades_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Subject name", 130);
            listView1.Columns.Add("Grade", 130, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select subject.name, grades.grade from [grades] " +
                "INNER JOIN subject ON grades.subject_id=subject.id WHERE grades.student_id = @student_id", conn);
            UserRepository repository = new UserRepository();
            string student_id = repository.GetUserId(Form1.LoggedInUser.GetUserName());

            cmd.Parameters.AddWithValue("@student_id", student_id);
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
    }
}
