using EmlakBazasi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmlakBazasi.DAL
{
    public class Methods
    {
        static SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PropertyDB"].ConnectionString);
        string Connectionstring = sqlConnection.ConnectionString;

        public List<View_rem_user> filterUsers(int filter)
        {
            try
            {
                List<View_rem_user> lu = new List<View_rem_user>();
                string sql = @"SELECT * FROM VIEW_REM_USER t WHERE "+getCondition(filter);

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    View_rem_user u = new View_rem_user();
                    u.id_user = reader.GetInt32(0);
                    u.fk_id_rem_user_type = reader.GetInt32(1);
                    u.user_type_name = reader.GetString(2);
                    u.user = reader.GetInt32(3);
                    u.office_name = reader.GetString(4);
                    u.full_name = reader.GetString(5);
                    u.service_price = reader.GetInt32(6);
                    u.phone_number = reader.GetString(7);
                    u.phone_number_ex = reader.GetString(8);
                    u.email_address = reader.GetString(9);
                    u.start_date = reader.GetDateTime(10);
                    u.is_active = reader.GetInt32(11);
                    u.is_deleted = reader.GetInt32(12);
                    u.tag = reader.GetInt32(13);
                    u.subscriber_tag = reader.GetInt32(14);
                    u.last_request_date = reader.GetDateTime(15);
                    u.version = reader.GetString(16);
                    u.last_request_result = reader.GetInt32(17);
                    u.payment_date = reader.GetDateTime(18);
                    u.reminder_date = reader.GetDateTime(19);
                    u.reminder_note = reader.GetString(20);

                    lu.Add(u);
                }
                sqlConnection.Close();
                return lu;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public string getCondition(int filter)
        {
            string condition = "";
            switch (filter)
            {
                case 0: condition = "t.is_deleted=0"; break;
                case 1: condition = "t.is_deleted=0 AND t.is_active=1"; break;
                case 2: condition = "t.is_deleted=0 AND t.fk_id_rem_user_type=2"; break;
                case 3: condition = "t.is_deleted=0 AND t.fk_id_rem_user_type=4"; break;
                case 4: condition = "t.is_deleted=0"; break;
                case 5: condition = "t.is_deleted=0"; break;
                case 6: condition = "t.is_deleted=1"; break;
                case 7: condition = "t.is_deleted=0 AND t.tag=1"; break;
                case 8: condition = "t.is_deleted=0 AND t.tag=0"; break;
            }
            return condition;
        }

        public bool deactiveUser(int id_user)
        {
            try
            {
                string sql = @"UPDATE rem_user SET is_active=0, fk_id_message_type=6 WHERE id_rem_user=@id_user";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@id_user";
                p[0].Value = id_user;
              
                cmd.Parameters.AddRange(p);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return false;
                //throw ex;
            }
        }

        public bool blockUser(int id_user)
        {
            try
            {
                string sql = @"UPDATE rem_user SET is_active=0, fk_id_message_type=8 WHERE id_rem_user=@id_user";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@id_user";
                p[0].Value = id_user;

                cmd.Parameters.AddRange(p);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return false;
                //throw ex;
            }
        }

        public bool activateUser(int id_user)
        {
            try
            {
                string sql = @"UPDATE rem_user SET is_active=1, fk_id_message_type=6 WHERE id_rem_user=@id_user";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@id_user";
                p[0].Value = id_user;

                cmd.Parameters.AddRange(p);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return false;
                //throw ex;
            }
        }

        public bool changeAsSubscriber(int id_user)
        {
            try
            {
                string sql = @"UPDATE rem_user SET fk_id_rem_user_type=2, fk_id_message_type=6 WHERE id_rem_user=@id_user";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@id_user";
                p[0].Value = id_user;

                cmd.Parameters.AddRange(p);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return false;
                //throw ex;
            }
        }

        public bool deleteUser(int id_user)
        {
            try
            {
                string sql = @"UPDATE rem_user SET is_active=0, fk_id_message_type=6, is_deleted=1 WHERE id_rem_user=@id_user";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@id_user";
                p[0].Value = id_user;

                cmd.Parameters.AddRange(p);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return false;
                //throw ex;
            }
        }

    }
}