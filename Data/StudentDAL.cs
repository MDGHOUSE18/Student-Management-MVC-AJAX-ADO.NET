using StudentManagementSystem.Models;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace StudentManagementSystem.Data
{
    public class StudentDAL
    {
        private readonly string _conString;

        public StudentDAL(IConfiguration configuration)
        {
            _conString = configuration.GetConnectionString("DefaultConnection");
        }


        public List<Students> GetStudents()
        {
            var students = new List<Students>();
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("spGetStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Students student = new Students
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        Name = reader["Name"].ToString() ?? "",
                        Age = Convert.ToInt32(reader["Age"]),
                        Branch = reader["Branch"].ToString() ?? "",
                        PhoneNumber = reader["PhoneNumber"].ToString() ?? ""

                    };
                    students.Add(student);
                }


            }
            return students;

        }
        public Students GetStudent(int id)
        {
            Students student = null;
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("spGetStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    student = new Students
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        Name = reader["Name"].ToString() ?? "",
                        Age = Convert.ToInt32(reader["Age"]),
                        Branch = reader["Branch"].ToString() ?? "",
                        PhoneNumber = reader["PhoneNumber"].ToString() ?? ""

                    };
                }

                return student;
            }

        }

        public void AddStudent(Students student)
        {
            using(SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", student.StudentId);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Branch", student.Branch);
                cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void EditStudent(Students student)
        {
            using(SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("spEditStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id",student.StudentId);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Branch", student.Branch);
                cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteStudent(int id)
        {
            using(SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
