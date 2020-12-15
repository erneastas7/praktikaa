using AntrasAtsiskaitymas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektas.Repository
{
    
    
        public class UserRepository
        {
            private static List<User> usersList;

            private SqlConnection conn;

            public List<User> GetUsers()
            {
                return usersList;
            }

            public UserRepository()
            {
                conn = new SqlConnection(@"Server=LOPTEPAS;Database=praktika;User Id=sa;Password=123456");
            }

            public User Login(string username, string password)
            {
                try
                {
                    string sql = "select name, surname, birthdate, username, password, type, group_id from [users] " +
                            "where username=@username and password=@password";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    conn.Open();



                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            string surname = reader["surname"].ToString();
                            DateTime date = DateTime.Parse(reader["birthdate"].ToString());
                            string usrname = reader["username"].ToString();
                            string pass = reader["password"].ToString();
                            string type = reader["type"].ToString();
                            string group_id = reader["group_id"].ToString();
                            return new User(name, surname, date, usrname, pass, type, group_id);
                        }
                    }
                    conn.Close();
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
                throw new Exception("Bad credentials");
            }

            public string GetNameSurname(string userid)
            {
                try
                {
                    string username = "";
                    conn.Open();
                    string sql = "select id, name, surname, birthdate, username, password, type, group_id from [users] " +
                             "where id=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader sReader;
                    cmd.Parameters.AddWithValue("@id", userid);
                    sReader = cmd.ExecuteReader();
                    if (sReader.Read())
                    {
                        username = sReader["name"].ToString() + " " + sReader["surname"].ToString();
                    }
                    return username;

                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            public string GetUserGroup(string userid)
            {
                try
                {
                    string group_id = "";
                    conn.Open();
                    string sql = "select id, name, surname, birthdate, username, password, type, group_id from [users] " +
                    "where id=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader sReader;
                    cmd.Parameters.AddWithValue("@id", userid);
                    sReader = cmd.ExecuteReader();
                    if (sReader.Read())
                    {
                        group_id = sReader["group_id"].ToString();
                    }
                    return group_id;

                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            public void RegisterStudent(User user)
            {
                try
                {
                    string sql = "insert into [users](name, surname, birthdate, username, password, type, group_id) " +
                        "values (@name, @surname, @birthdate, @username, @password, @type, @group_id)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", user.GetName());
                    cmd.Parameters.AddWithValue("@surname", user.GetSurname());
                    cmd.Parameters.AddWithValue("@username", user.GetUserName());
                    cmd.Parameters.AddWithValue("@password", user.GetPassword());
                    cmd.Parameters.AddWithValue("@type", "Student");
                    cmd.Parameters.AddWithValue("@birthdate", user.GetBirthDate());
                    cmd.Parameters.AddWithValue("@group_id", user.GetGroupId());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }

            public void ScanLogin(string username)
            {
                try
                {
                    string sql = "select name, surname, birthdate, username, password, type, group_id from [users] " +
                            "where username=@username";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string usrname = reader["username"].ToString();
                            if (username == usrname)
                            {
                                throw new Exception("User with the same username exists");
                            }
                        }
                    }
                    conn.Close();
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }

        public void ScanStudent(string id)
        {
            try
            {
                string sql = "select count(*) from [users] " +
                         "where id=@id and type='Student'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    throw new Exception("Student doesn't exist!");
                }

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public void RemoveStudent(string id)
        {
            try
            {
                string sql = "delete from [users] " +
                         "where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student with his grades has been removed");
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public void RemoveGrades(string userid)
        {
            try
            {
                string sql = "delete from grades " +
                         "where student_id=@student_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@student_id", userid);
                conn.Open();
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public void RegisterTeacher(User user)
        {
            try
            {
                string sql = "insert into [users](name, surname, birthdate, username, password, type) " +
                    "values (@name, @surname, @birthdate, @username, @password, @type )";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", user.GetName());
                cmd.Parameters.AddWithValue("@surname", user.GetSurname());
                cmd.Parameters.AddWithValue("@username", user.GetUserName());
                cmd.Parameters.AddWithValue("@password", user.GetPassword());
                cmd.Parameters.AddWithValue("@type", "Teacher");
                cmd.Parameters.AddWithValue("@birthdate", user.GetBirthDate());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }



        public void RemoveTeacher(string id)
        {
            try
            {
                string sql = "delete from [users] " +
                         "where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Teacher with his given grades to students has been removed");
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public void ScanTeacher(string id)
        {
            try
            {
                string sql = "select count(*) from [users] " +
                         "where id=@id and type='Teacher'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    throw new Exception("Teacher doesn't exist!");
                }

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetUserId(string username)
        {
            try
            {
                string userid = "";
                conn.Open();
                string sql = "select id, name, surname, birthdate, username, password, type, group_id from [users] " +
                         "where username=@username";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sReader;
                cmd.Parameters.AddWithValue("@username", username);
                sReader = cmd.ExecuteReader();
                if (sReader.Read())
                {
                    userid = sReader["id"].ToString();
                }
                return userid;

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetUserIdNameSurname(string name, string surname)
        {
            try
            {
                string userid = "";
                conn.Open();
                string sql = "select id, name, surname, birthdate, username, password, type, group_id from [users] " +
                         "where name=@name and surname=@surname";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sReader;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                sReader = cmd.ExecuteReader();
                if (sReader.Read())
                {
                    userid = sReader["id"].ToString();
                }
                return userid;

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }









    }
}
