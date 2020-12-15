using projektas.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektas
{
    public partial class Form2 : Form
    {
        RegisterStudent fc = new RegisterStudent();
        RegisterTeachers fr = new RegisterTeachers();
        RegisterGroups fv = new RegisterGroups();
        SubjectGrades sg = new SubjectGrades();
        TeacherMenu tm = new TeacherMenu();
        RegisterSubject fa = new RegisterSubject();

        public Form2()
        {
            InitializeComponent();
        }
        

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.LoggedInUser.GetName() + " " + Form1.LoggedInUser.GetSurname();

            GroupRepository repository = new GroupRepository();
            label3.Text = repository.GetGroupName(Form1.LoggedInUser.GetGroupId());



            

            if (Form1.LoggedInUser.GetUserType() == "Admin")
            {
                adminMenuToolStripMenuItem.Visible = true;
                teacherMenuToolStripMenuItem.Visible = false;
                teachersToolStripMenuItem.Visible = true;
                groupsToolStripMenuItem.Visible = true;
                subjectToolStripMenuItem.Visible = true;
                label2.Visible = true;
                label3.Visible = false;
                label5.Visible = false;
                label6.Visible = true;
                label4.Text = "Admin";

                label2.Text = Form1.LoggedInUser.GetName() + " " + Form1.LoggedInUser.GetSurname();

            }
            if (Form1.LoggedInUser.GetUserType() == "Teacher")
            {
                teacherMenuToolStripMenuItem.Visible =true;
                adminMenuToolStripMenuItem.Visible = false;
                teachersToolStripMenuItem.Visible = false;
                groupsToolStripMenuItem.Visible = false;
                subjectToolStripMenuItem.Visible = false;
                label4.Text = "Teacher";
                label2.Visible = true;
                label3.Visible = false;
                label5.Visible = false;
                label6.Visible = true;

                label2.Text = Form1.LoggedInUser.GetName() + " " + Form1.LoggedInUser.GetSurname();
            }
            if (Form1.LoggedInUser.GetUserType() == "Student")
            {
                adminMenuToolStripMenuItem.Visible = false;
                teacherMenuToolStripMenuItem.Visible = false;
                teachersToolStripMenuItem.Visible = false;
                groupsToolStripMenuItem.Visible = false;
                subjectToolStripMenuItem.Visible = false;
                label4.Text = "Student";

                panel1.Visible = true;
                panel1.Controls.Clear();
                panel1.Controls.Add(sg);
                sg.Show();
            }
            }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registerStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void adminMenuToolStripMenuItem_Click(object sender, EventArgs e)
        { 

            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(fc);
            fc.Show();

        }

        private void addTeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registerNewGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(fr);
            fr.Show();
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(fa);
            fa.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(fv);
            fv.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
            Form1.LoggedInUser = null;
        }

        private void teacherMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(tm);
            tm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }
    }
}
