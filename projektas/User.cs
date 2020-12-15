using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntrasAtsiskaitymas
{
    public class User : Person
    {

        protected string username;
        protected string password;
        protected string type;
        protected string group_id;
        private SqlConnection conn;
        
        public User(string name, string surname, DateTime birthDate, string username, string password, string type, string group_id) : base(name, surname, birthDate)
        {

            if (username.Length > 0)
                this.username = username;
            else throw new Exception("Username is required");

            if (password.Length > 0)
                this.password = password;
            else throw new Exception("Password is required");

            this.type = type;
            this.group_id = group_id;
            
            conn = new SqlConnection(@"Server=LOPTEPAS;Database=praktika;User Id=sa;Password=123456");
        }

        public string GetGroupId()
        {
            return group_id;
        }

        public string GetUserName()
        {
            return username;
        }
        public string GetPassword()
        {
            return password;
        }
        
        public string GetUserType()
        {
            return type;
        }
        public void SetUserType(string type)
        {
            this.type = type;
        }

   


    }
}
