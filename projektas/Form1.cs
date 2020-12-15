using AntrasAtsiskaitymas;
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
using static projektas.Repository.UserRepository;

namespace projektas
{
    public partial class Form1 : Form
    {
        public static User LoggedInUser;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            UserRepository repository = new UserRepository();
            try
            {
                Form1.LoggedInUser = repository.Login(textBox1.Text, textBox2.Text);
                Form2 g = new Form2();
                g.Show();
                this.Hide();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

