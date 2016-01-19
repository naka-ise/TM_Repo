using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using WpfApplication1.Controller;

namespace WpfApplication1.Model
{
    class MyModel: IModel
    {
        public static string connection = "Data Source=(LocalDB)\\v11.0;AttachDbFileName=\"C:\\Hallel\\Presonal\\TeachMe\\WpfApplication1\\Model\\TeachMe_DB.mdf\";Integrated Security=True";
        public static SqlConnection SqlCon= new SqlConnection(connection);
        static int LessonID=1;
        IController m_controller;

        public MyModel(IController con)
        {
            m_controller = con;
        }
        
        public void AddUser(string[] details, string user)
        {

            try
            {
                SqlCon.Open();
                string query;
                SqlCommand command;
                
                if (user == "Student")
                {
                    query = "INSERT INTO dbo.Students(Id, F_Name, L_Name, City, Phone, Email, AcademicDegree)  VALUES (@Id, @F_Name, @L_Name, @City, @Phone, @Email, @AcademicDegree)";
                    command = new SqlCommand(query, SqlCon);
                    command.Parameters.Add("@Id", details[0]);
                    command.Parameters.Add("@F_Name", details[1]);
                    command.Parameters.Add("@L_Name", details[2]);
                    command.Parameters.Add("@City", details[3]);
                    command.Parameters.Add("@Phone", details[4]);
                    command.Parameters.Add("@Email", details[5]);
                    command.Parameters.Add("@AcademicDegree", details[6]);
                }

                else //user=teacher
                {
                    query = "INSERT INTO dbo.Teacher(Id, F_Name, L_Name, City, Phone, Email, AcademicDegree)  VALUES (@Id, @F_Name, @L_Name, @City, @Phone, @Email, @AcamedicDegree)";
                    command = new SqlCommand(query, SqlCon);
                    command.Parameters.Add("@Id", details[0]);
                    command.Parameters.Add("@F_Name", details[1]);
                    command.Parameters.Add("@L_Name", details[2]);
                    command.Parameters.Add("@City", details[3]);
                    command.Parameters.Add("@Phone", details[4]);
                    command.Parameters.Add("@Email", details[5]);
                    command.Parameters.Add("@AcamedicDegree", details[6]);
                }

                command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                m_controller.Output(ex.Message);
            }

            finally
            {
                SqlCon.Close();
            }
        }

        public void DeleteUser(string[] details, string user)
        {
            try
            {
                SqlCon.Open();
        
                string query;
                SqlCommand command;
        
                if (user == "teacher")
                {
                    query = "DELETE *    FROM Teacher    Where Id=@Id";
                }
        
                else
                {
                    query = "DELETE *    FROM Students    Where Id=@Id";
                }
        
                command = new SqlCommand(query, SqlCon);
                command.Parameters.Add("@Id", details[0]);
                command.ExecuteNonQuery();
            }
        
            catch (Exception ex)
            {
                m_controller.Output(ex.Message);
            }
        
            finally
            {
                SqlCon.Close();
            }
        }
        
        /*public void UpdateTeacher(string[] details)
        {
            try
            {
                SqlCon.Open();
                string query = "UPDATE T  SET @parameter=@detail  FROM Teacher T    WHERE Id=@id";
                SqlCommand command = new SqlCommand(query, SqlCon);
                command.Parameters.Add("@parameter", details[1]);
                command.Parameters.Add("@detail", details[2]);
                command.Parameters.Add("@Id", details[0]);
                command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                SqlCon.Close();
            }
        }
        */


        public DataTable SearchLesson(string[] details)
        {
            try
            {
                SqlCon.Open();

                string query = "SELECT T.Id, T.F_Name, T.L_Name, T.City, T.Phone, T.Email, T.AcademicDegree   FROM Teacher T INNER JOIN TeacherProfessions TP ON T.Id=TP.TeacherID INNER JOIN Professions P ON TP.ProfessionCode=P.ProfessionCode   WHERE  P.ProfessionName='" + details[0] +"'" +  " AND T.City='" + details[1] + "'" + " AND TP.HourPrice<=" + details[2];

                SqlCommand command = new SqlCommand(query, SqlCon);
                SqlDataAdapter tableAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                tableAdapter.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                m_controller.Output(ex.Message);
            }

            finally
            {
                SqlCon.Close();
            }
        }
        
        public void SetNewLesson(string[] details){
            try
            {
                SqlCon.Open();

                string query = "SELECT P.ProfessionCode, P.ProfessionName, @StudentID AS StudentID, @TeacherID AS TeacherID, @Date AS [Date], @Hour AS [Hour], NULL AS AssingmentCode, @Duration AS Duration    INTO #TMP   FROM Professions P  WHERE ProfessionName=@ProfessionName   " +

                               " INSERT INTO StudentsLessons ( StudentID, TeacherID, ProfessionCode, [Date], [Hour], AssingmentCode, Duration)  " +
                               "SELECT  StudentID, TeacherID, ProfessionCode, [Date], [Hour], AssingmentCode, Duration " +    
                                "FROM #TMP  " +
                               "    DROP TABLE #TMP";
                                

                SqlCommand command = new SqlCommand(query, SqlCon);
                command.Parameters.Add("@StudentID", details[0]);
                command.Parameters.Add("@TeacherID", details[1]);
                command.Parameters.Add("@ProfessionName", details[2]);
                command.Parameters.Add("@Date", details[3].Split(' ')[0]);
                command.Parameters.Add("@Hour", details[4]);
                command.Parameters.Add("@Duration", details[5]);
                //
                command.ExecuteNonQuery();

                string UpdatePayment = "SELECT MAX(LessonID) AS LessonID " +
                                        "INTO #TMP	FROM StudentsLessons " +
                                        "INSERT INTO Payments SELECT LessonID, NULL FROM #TMP " +
                                        "DROP TABLE #TMP";

                SqlCommand command2 = new SqlCommand(UpdatePayment, SqlCon);
                command2.ExecuteNonQuery();
                LessonID++;

            }

            catch (Exception ex)
            {
                m_controller.Output(ex.Message);
            }

            finally
            {
                SqlCon.Close();
            }
        }

        public DataTable ShowUnpayedLessons(string id)
        {
            try
            {
                SqlCon.Open();

                string query = "SELECT SL.LessonID AS Lesson_Number, T.F_Name AS Teacher_First_Name, T.L_Name AS Teacher_Last_Name, P.ProfessionName, SL.[Date], SL.[Hour], SL.Duration " +
                                "FROM StudentsLessons SL INNER JOIN Teacher T ON SL.TeacherID=T.Id INNER JOIN Professions P ON P.ProfessionCode=SL.ProfessionCode INNER JOIN Payments PM ON SL.LessonID=PM.LessonID" +
                                " WHERE SL.StudentID=@StudentID AND PM.[DateOfPayment] IS NULL";
                SqlCommand command = new SqlCommand(query, SqlCon);
                command.Parameters.Add("@StudentID", id);
                SqlDataAdapter tableAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                tableAdapter.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                SqlCon.Close();
            }
        }
        
        public void PayForLesson(string lesson)
        {
            try
            {
                SqlCon.Open();
                string query = "UPDATE P    SET P.DateOfPayment=@DateOfPayment FROM Payments P WHERE LessonID=@LessonID";
                SqlCommand command = new SqlCommand(query, SqlCon);
                command.Parameters.Add("@LessonID", lesson);
                command.Parameters.Add("@DateOfPayment", DateTime.Now.ToString("en - GB"));

                command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                m_controller.Output(ex.Message);
            }

            finally
            {
                SqlCon.Close();
            }
        }

        public DataTable ShowLessonsForStudent(string id)
        {
            try
            {
                SqlCon.Open();
                string query = "SELECT SL.LessonID AS Lesson_Number, T.F_Name AS Teacher_First_Name, T.L_Name AS Teacher_Last_Name, P.ProfessionName, SL.Date, SL.Hour, SL.Duration " +
                                "FROM StudentsLessons SL INNER JOIN Teacher T ON SL.TeacherID=T.Id INNER JOIN Professions P ON P.ProfessionCode=SL.ProfessionCode " +
                                "WHERE SL.StudentID=@StudentID";

                SqlCommand command = new SqlCommand(query, SqlCon);
                command.Parameters.Add("@StudentID", id);
                SqlDataAdapter tableAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                tableAdapter.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                SqlCon.Close();
            }
        }
    }
}
