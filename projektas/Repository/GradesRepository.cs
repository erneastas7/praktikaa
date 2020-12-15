using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektas.Repository
{
    class GradesRepository
    {
        private SqlConnection conn;

        public GradesRepository()
        {
            conn = new SqlConnection(@"Server=LOPTEPAS;Database=praktika;User Id=sa;Password=123456");
        }

        public void DeleteGrade(string id)
        {
            try
            {
                string sql = "delete from grades " +
                         "where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Grade deleted");
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


        public void AddGrade(int subject_id, string student_id, string grade, string group_id)
        {
            try
            {
                string sql = "insert into grades(subject_id, student_id, grade, group_id) " +
                                   "values (@subject_id, @student_id, @grade, @group_id)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@student_id", student_id);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@group_id", group_id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Grade has been added");
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

        
        public void CheckGradeExistence(string id)
        {
            try
            {
                string sql = "select count(*) from grades " +
                         "where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    throw new Exception("This grade does not exist");
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
    }
}
