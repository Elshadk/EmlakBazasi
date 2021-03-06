﻿using EmlakBazasi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace EmlakBazasi.DAL
{
    public class Methods
    {
        static SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PropertyDB"].ConnectionString);
        string Connectionstring = sqlConnection.ConnectionString;
        int rowGroup = 0;
        int rowCount = 0;

        //filter method
        public List<View_rem_user> filterUsers(int filter)
        {
            try
            {
                List<View_rem_user> lu = new List<View_rem_user>();
                string sql = @"SELECT * FROM VIEW_REM_USER t WHERE " + getCondition(filter);

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                rowCount = 0;
                rowGroup = 0;
                int rowGeneral = 0;
                while (reader.Read())
                {
                    rowCount++;
                    rowGeneral++;

                    View_rem_user u = new View_rem_user();
                    u.id_user = reader.GetInt32(0);
                    u.fk_id_rem_user_type = SafeGetInt(reader, 1);
                    u.user_type_name = SafeGetString(reader, 2);
                    u.user = SafeGetInt(reader, 3);
                    u.office_name = SafeGetString(reader, 4);
                    u.full_name = SafeGetString(reader, 5);
                    u.service_price = SafeGetInt(reader, 6);
                    u.phone_number = SafeGetString(reader, 7);
                    u.phone_number_ex = SafeGetString(reader, 8);
                    u.email_address = SafeGetString(reader, 9);
                    u.start_date = SafeGetDate(reader, 10);
                    u.is_active = SafeGetInt(reader, 11);
                    u.is_deleted = SafeGetInt(reader, 12);
                    u.tag = SafeGetInt(reader, 13);
                    u.subscriber_tag = SafeGetInt(reader, 14);
                    u.last_request_date = SafeGetDate(reader, 15);
                    u.version = SafeGetString(reader, 16);
                    u.last_request_result = SafeGetInt(reader, 17);
                    u.payment_date = SafeGetDate(reader, 18);
                    u.reminder_date = SafeGetDate(reader, 19);
                    u.reminder_note = SafeGetString(reader, 20);
                    u.utils = utils(u, rowGeneral);

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

        //status methods
        public string getCondition(int filter)
        {
            string condition = "";
            switch (filter)
            {
                case 0: condition = "t.is_deleted=0"; break;
                case 1: condition = "t.is_deleted=0 AND t.is_active=1"; break;
                case 2: condition = "t.is_deleted=0 AND t.fk_id_rem_user_type=2"; break;
                case 3: condition = "t.is_deleted=0 AND t.fk_id_rem_user_type=4"; break;
                case 4: condition = "t.is_deleted=0 AND DATEDIFF(day, last_request_date, GETDATE())>12 AND DATEDIFF(day, last_request_date, GETDATE())<24"; break;
                case 5: condition = "t.is_deleted=0 AND DATEDIFF(day, last_request_date, GETDATE())>24"; break;
                case 6: condition = "t.is_deleted=1"; break;
                case 7: condition = "t.is_deleted=0 AND t.tag=1"; break;
                case 8: condition = "t.is_deleted=0 AND t.tag=0"; break;
                default: condition = "t.is_deleted=0"; break;
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

        public List<View_source_status> getSourcesStatistics()
        {
            try
            {
                List<View_source_status> lu = new List<View_source_status>();
                string sql = @"SELECT * FROM View_source_status";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    View_source_status u = new View_source_status();
                    u.id_source = reader.GetInt32(0);
                    u.source_name = SafeGetString(reader, 1);
                    u.last_reading_date = SafeGetDate(reader, 2);
                    u.last_read_property_type = SafeGetString(reader, 3);

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

        //note methods
        public List<Rem_user_note> allNoteList()
        {
            try
            {
                List<Rem_user_note> lu = new List<Rem_user_note>();
                string sql = @"SELECT * FROM REM_USER_NOTE";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Rem_user_note u = new Rem_user_note();
                    u.fk_id_rem_user = reader.GetInt32(0);
                    u.date = SafeGetDate(reader, 1);
                    u.note_date = SafeGetDate(reader, 2);
                    u.IP = SafeGetString(reader, 3);
                    u.note = SafeGetString(reader, 4);
                    u.is_deleted = SafeGetInt(reader, 5);

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

        public bool addNote(Rem_user_note item)
        {
            try
            {
                List<Rem_user_note> lu = new List<Rem_user_note>();
                string sql = @"INSERT INTO rem_user_note 
                                 (fk_id_rem_user,date,note_date, IP, note, is_deleted) 
                               VALUES (@fk_id_rem_user, @date, @note_date, @IP, @note, @is_deleted)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@fk_id_rem_user";
                p[0].Value = item.fk_id_rem_user;
                p[1] = new SqlParameter();
                p[1].ParameterName = "@date";
                p[1].Value = item.date;
                p[2] = new SqlParameter();
                p[2].ParameterName = "@note_date";
                p[2].Value = item.note_date;
                p[3] = new SqlParameter();
                p[3].ParameterName = "@IP";
                p[3].Value = item.IP;
                p[4] = new SqlParameter();
                p[4].ParameterName = "@note";
                p[4].Value = item.note;
                p[5] = new SqlParameter();
                p[5].ParameterName = "@is_deleted";
                p[5].Value = item.is_deleted;

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
            }
        }

        public List<Rem_user_note> showNote(int userId)
        {
            try
            {
                List<Rem_user_note> lu = new List<Rem_user_note>();
                string sql = @"SELECT * FROM rem_user_note WHERE fk_id_rem_user=@userId";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@userId";
                p[0].Value = userId;

                cmd.Parameters.AddRange(p);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Rem_user_note u = new Rem_user_note();
                    u.id_rem_user_note = reader.GetInt32(0);
                    u.fk_id_rem_user = SafeGetInt(reader, 1);
                    u.date = SafeGetDate(reader, 2);
                    u.note_date = SafeGetDate(reader, 3);
                    u.IP = SafeGetString(reader, 4);
                    u.note = SafeGetString(reader, 5);
                    u.is_deleted = SafeGetInt(reader, 6);

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

        public List<All_user_note> showAllNote()
        {
            try
            {
                List<All_user_note> lu = new List<All_user_note>();
                string sql = @"SELECT n.id_rem_user_note, n.note_date, n.note, u.full_name, u.office_name, u.phone_number 
                                FROM rem_user_note n
                                LEFT JOIN rem_user u ON u.id_rem_user = n.fk_id_rem_user
                                WHERE n.is_deleted=0";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    All_user_note u = new All_user_note();
                    u.id_rem_user_note = reader.GetInt32(0);
                    u.note_date = SafeGetDate(reader, 1);
                    u.note = SafeGetString(reader, 2);
                    u.full_name = SafeGetString(reader, 3);
                    u.office_name = SafeGetString(reader, 4);
                    u.phone_number = SafeGetString(reader, 5);

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

        //reminder methods
        public bool addReminder(Rem_user_reminder item)
        {
            try
            {
                List<Rem_user_reminder> lu = new List<Rem_user_reminder>();
                string sql = @"INSERT INTO rem_user_reminder 
                                 (fk_id_rem_user, date, reminder_date, IP, note, is_deleted) 
                               VALUES (@fk_id_rem_user, @date, @reminder_date, @IP, @note, @is_deleted)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@fk_id_rem_user";
                p[0].Value = item.fk_id_rem_user;
                p[1] = new SqlParameter();
                p[1].ParameterName = "@date";
                p[1].Value = item.date;
                p[2] = new SqlParameter();
                p[2].ParameterName = "@reminder_date";
                p[2].Value = item.reminder_date;
                p[3] = new SqlParameter();
                p[3].ParameterName = "@IP";
                p[3].Value = item.IP;
                p[4] = new SqlParameter();
                p[4].ParameterName = "@note";
                p[4].Value = item.note;
                p[5] = new SqlParameter();
                p[5].ParameterName = "@is_deleted";
                p[5].Value = item.is_deleted;

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
            }
        }

        public bool deleteReminder(int id_user)
        {
            try
            {
                string sql = @"UPDATE rem_user_reminder SET is_deleted=1 WHERE fk_id_rem_user=@id_user";

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

        //payment methoda
        public bool addPayment(Rem_user_payment item)
        {
            try
            {
                string sql = @"INSERT INTO rem_user_payment 
                                 (fk_id_rem_user, date, payment_date, sum, note, IP, id_deleted) 
                               VALUES (@fk_id_rem_user, @date, @payment_date, @sum, @note, @IP, @is_deleted)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[7];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@fk_id_rem_user";
                p[0].Value = item.fk_id_rem_user;
                p[1] = new SqlParameter();
                p[1].ParameterName = "@date";
                p[1].Value = item.date;
                p[2] = new SqlParameter();
                p[2].ParameterName = "@payment_date";
                p[2].Value = item.payment_date;
                p[3] = new SqlParameter();
                p[3].ParameterName = "@sum";
                p[3].Value = item.sum;
                p[4] = new SqlParameter();
                p[4].ParameterName = "@note";
                p[4].Value = item.note;
                p[5] = new SqlParameter();
                p[5].ParameterName = "@IP";
                p[5].Value = item.IP;
                p[6] = new SqlParameter();
                p[6].ParameterName = "@is_deleted";
                p[6].Value = item.id_deleted;

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
            }
        }

        public List<Rem_user_payment> showPayment(int userId)
        {
            try
            {
                List<Rem_user_payment> lu = new List<Rem_user_payment>();
                string sql = @"SELECT * FROM rem_user_payment WHERE fk_id_rem_user=@userId";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter();
                p[0].ParameterName = "@userId";
                p[0].Value = userId;

                cmd.Parameters.AddRange(p);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Rem_user_payment u = new Rem_user_payment();
                    u.id_user_payment = reader.GetInt32(0);
                    u.fk_id_rem_user = SafeGetInt(reader, 1);
                    u.date = SafeGetDate(reader, 2);
                    u.payment_date = SafeGetDate(reader, 3);
                    u.sum = SafeGetInt(reader, 4);
                    u.note = SafeGetString(reader, 5);
                    u.IP = SafeGetString(reader, 6);
                    u.id_deleted = SafeGetInt(reader, 7);

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

        public List<All_user_payment> showAllPayment()
        {
            try
            {
                List<All_user_payment> lu = new List<All_user_payment>();
                string sql = @"SELECT n.id_user_payment, n.payment_date, n.sum, n.note, u.full_name, u.office_name, u.phone_number 
                                FROM rem_user_payment n
                                LEFT JOIN rem_user u ON u.id_rem_user = n.fk_id_rem_user
                                WHERE n.id_deleted=0";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    All_user_payment u = new All_user_payment();
                    u.id_user_payment = reader.GetInt32(0);
                    u.payment_date = SafeGetDate(reader, 1);
                    u.sum = reader.GetInt32(2);
                    u.note = SafeGetString(reader, 3);
                    u.full_name = SafeGetString(reader, 4);
                    u.office_name = SafeGetString(reader, 5);
                    u.phone_number = SafeGetString(reader, 6);

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

        //tags methods
        public bool changeTag(int id_user)
        {
            try
            {
                string sql = @"UPDATE rem_user SET tag=1 WHERE id_rem_user=@id_user";

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
        public bool clearTag(int id_user)
        {
            try
            {
                string sql = @"UPDATE rem_user SET tag=0 WHERE id_rem_user=@id_user";

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
        public bool clearAllTags()
        {
            try
            {
                string sql = @"UPDATE rem_user SET tag=0 WHERE is_deleted=0";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
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

        //message and user type list methods
        public List<Rem_user_type> getAllUserType()
        {
            try
            {
                List<Rem_user_type> lu = new List<Rem_user_type>();
                string sql = @"SELECT * FROM rem_user_type";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Rem_user_type u = new Rem_user_type();
                    u.id_rem_user_type = reader.GetInt32(0);
                    u.type_name = SafeGetString(reader, 1);
                    u.status = SafeGetInt(reader, 2);

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

        public List<Message_type> getAllMessageType()
        {
            try
            {
                List<Message_type> lu = new List<Message_type>();
                string sql = @"SELECT * FROM message_type";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Message_type u = new Message_type();
                    u.id_message_type = reader.GetInt32(0);
                    u.message_code = SafeGetString(reader, 1);
                    u.message_description = SafeGetString(reader, 2);

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

        //add user methods
        public int getUserForAddUser()
        {
            Random rand = new Random();
            int user = 0;
            try
            {
                List<Message_type> lu = new List<Message_type>();
                string sql = @"SELECT MAX(r.[user]) FROM rem_user r";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = reader.GetInt32(0) + rand.Next(100);
                }
                sqlConnection.Close();
                return user;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public bool addUser(Rem_user item)
        {
            try
            {
                List<Rem_user_note> lu = new List<Rem_user_note>();
                string sql = @"INSERT INTO rem_user 
                                 ([user], office_name, full_name, reference, MAC, service_price, phone_number,
                                  phone_number_ex, email_address, start_date, reading_data_count, fk_id_rem_user_type, believe, 
                                  is_active, fk_id_message_type, last_IP, last_request_date, last_request_result, version, note, 
                                  subscriber_tag, tag, is_deleted, additional_client) 
                               VALUES (@user, @office_name, @full_name, @reference, @MAC, @service_price, @phone_number,
                                  @phone_number_ex, @email_address, @start_date, @reading_data_count, @fk_id_rem_user_type, @believe, 
                                  @is_active, @fk_id_message_type, @last_IP, @last_request_date, @last_request_result, @version, @note, 
                                  @subscriber_tag, @tag, @is_deleted, @additional_client)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@user", item.user);
                cmd.Parameters.AddWithValue("@office_name", item.office_name);
                cmd.Parameters.AddWithValue("@full_name", item.full_name);
                cmd.Parameters.AddWithValue("@reference", item.reference);
                cmd.Parameters.AddWithValue("@MAC", item.MAC);
                cmd.Parameters.AddWithValue("@service_price", item.service_price);
                cmd.Parameters.AddWithValue("@phone_number", item.phone_number);
                cmd.Parameters.AddWithValue("@phone_number_ex", item.phone_number_ex);
                cmd.Parameters.AddWithValue("@email_address", item.email_address);
                cmd.Parameters.AddWithValue("@start_date", item.start_date);
                cmd.Parameters.AddWithValue("@reading_data_count", item.reading_data_count);
                cmd.Parameters.AddWithValue("@fk_id_rem_user_type", item.fk_id_rem_user_type);
                cmd.Parameters.AddWithValue("@believe", item.believe);
                cmd.Parameters.AddWithValue("@is_active", item.is_active);
                cmd.Parameters.AddWithValue("@fk_id_message_type", item.fk_id_message_type);
                cmd.Parameters.AddWithValue("@last_IP", item.last_IP);
                cmd.Parameters.AddWithValue("@last_request_date", item.last_request_date);
                cmd.Parameters.AddWithValue("@last_request_result", item.last_request_result);
                cmd.Parameters.AddWithValue("@version", item.version);
                cmd.Parameters.AddWithValue("@note", item.note);
                cmd.Parameters.AddWithValue("@subscriber_tag", item.subscriber_tag);
                cmd.Parameters.AddWithValue("@tag", item.tag);
                cmd.Parameters.AddWithValue("@is_deleted", item.is_deleted);
                cmd.Parameters.AddWithValue("@additional_client", item.additional_client);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return false;
            }
        }

        //update user methods
        public Rem_user getUserInfoForUpdateUser(int id_user)
        {
            try
            {
                string sql = @"SELECT id_rem_user, [user], office_name, full_name, reference, MAC, service_price, phone_number,
                                  phone_number_ex, email_address, start_date, reading_data_count, fk_id_rem_user_type, believe, 
                                  fk_id_message_type, last_IP, last_request_date, last_request_result, version, note, tag, is_active, is_deleted, subscriber_tag
                              FROM rem_user WHERE id_rem_user=@id_user";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id_user", id_user);

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Rem_user u = new Rem_user();
                while (reader.Read())
                {
                    u.id_rem_user = reader.GetInt32(0);
                    u.user = SafeGetInt(reader, 1);
                    u.office_name = SafeGetString(reader, 2);
                    u.full_name = SafeGetString(reader, 3);
                    u.reference = SafeGetString(reader, 4);
                    u.MAC = SafeGetString(reader, 5);
                    u.service_price = SafeGetInt(reader, 6);
                    u.phone_number = SafeGetString(reader, 7);
                    u.phone_number_ex = SafeGetString(reader, 8);
                    u.email_address = SafeGetString(reader, 9);
                    u.start_date = SafeGetDate(reader, 10);
                    u.reading_data_count = reader.GetInt32(11);
                    u.fk_id_rem_user_type = SafeGetInt(reader, 12);
                    u.believe = SafeGetInt(reader, 13);
                    u.fk_id_message_type = SafeGetInt(reader, 14);
                    u.last_IP = SafeGetString(reader, 15);
                    u.last_request_date = SafeGetDate(reader, 16);
                    u.last_request_result = SafeGetInt(reader, 17);
                    u.version = SafeGetString(reader, 18);
                    u.note = SafeGetString(reader, 19);
                    u.tag = SafeGetInt(reader, 20);
                    u.is_active = SafeGetInt(reader, 21);
                    u.is_deleted = SafeGetInt(reader, 22);
                    u.subscriber_tag = SafeGetInt(reader, 23);
                }
                sqlConnection.Close();
                return u;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw ex;
            }
        }

        public bool updateUser(Rem_user item)
        {
            try
            {
                List<Rem_user_note> lu = new List<Rem_user_note>();
                string sql = @"UPDATE  rem_user SET
                                 [user]=@user, office_name=@office_name, full_name=@full_name, reference=@reference, MAC=@MAC, service_price=@service_price, phone_number=@phone_number,
                                  phone_number_ex=@phone_number_ex, email_address=@email_address, start_date=@start_date, reading_data_count=@reading_data_count, fk_id_rem_user_type=@fk_id_rem_user_type, 
                                  believe=@believe, is_active=@is_active, fk_id_message_type=@fk_id_message_type, last_IP=@last_IP, last_request_date=@last_request_date, last_request_result=@last_request_result,
                                  version=@version, note=@note, subscriber_tag=@subscriber_tag, tag=@tag, is_deleted=@is_deleted, additional_client=@additional_client 
                               WHERE id_rem_user=@id_rem_user";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@user", item.user);
                cmd.Parameters.AddWithValue("@office_name", item.office_name);
                cmd.Parameters.AddWithValue("@full_name", item.full_name);
                cmd.Parameters.AddWithValue("@reference", item.reference);
                cmd.Parameters.AddWithValue("@MAC", item.MAC);
                cmd.Parameters.AddWithValue("@service_price", item.service_price);
                cmd.Parameters.AddWithValue("@phone_number", item.phone_number);
                cmd.Parameters.AddWithValue("@phone_number_ex", item.phone_number_ex);
                cmd.Parameters.AddWithValue("@email_address", item.email_address);
                cmd.Parameters.AddWithValue("@start_date", item.start_date);
                cmd.Parameters.AddWithValue("@reading_data_count", item.reading_data_count);
                cmd.Parameters.AddWithValue("@fk_id_rem_user_type", item.fk_id_rem_user_type);
                cmd.Parameters.AddWithValue("@believe", item.believe);
                cmd.Parameters.AddWithValue("@is_active", item.is_active);
                cmd.Parameters.AddWithValue("@fk_id_message_type", item.fk_id_message_type);
                cmd.Parameters.AddWithValue("@last_IP", item.last_IP);
                cmd.Parameters.AddWithValue("@last_request_date", item.last_request_date);
                cmd.Parameters.AddWithValue("@last_request_result", item.last_request_result);
                cmd.Parameters.AddWithValue("@version", item.version);
                cmd.Parameters.AddWithValue("@note", item.note);
                cmd.Parameters.AddWithValue("@subscriber_tag", item.subscriber_tag);
                cmd.Parameters.AddWithValue("@tag", item.tag);
                cmd.Parameters.AddWithValue("@is_deleted", item.is_deleted);
                cmd.Parameters.AddWithValue("@additional_client", item.additional_client);
                cmd.Parameters.AddWithValue("@id_rem_user", item.id_rem_user);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return false;
            }
        }


        //helper methods
        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public DateTime SafeGetDate(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            return DateTime.MinValue;
        }

        public int SafeGetInt(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return 0;
        }

        public Util utils(View_rem_user item, int rowGeneral)
        {
            Util u = new Util();
            string s = "";
            if (item.is_active == 1)
            {
                s = "Aktiv";
                u.trFontStyle = "normal";
            }
            else
            {
                s = "Deaktiv";
                u.trFontStyle = "italic";
            };
            u.trBgColor = item.fk_id_rem_user_type == 2 ? "#e8e8e8" : "white";
            u.last_request_period = Convert.ToInt32(DateTime.Now.Subtract(Convert.ToDateTime(item.last_request_date)).TotalDays);
            if (u.last_request_period <= 2)
            {
                u.status = s + ", Yaxşı";
                u.trTextColor = "green";

                rowCount = rowGroup != 1 ? 1 : rowCount;
                rowGroup = 1;
            }
            else if (u.last_request_period <= 12)
            {
                u.status = s + ", Normal";
                u.trTextColor = "black";

                rowCount = rowGroup != 2 ? 1 : rowCount;
                rowGroup = 2;
            }
            else if (u.last_request_period >= 12 && u.last_request_period <= 24)
            {
                u.status = s + ", Gecikmə";
                u.trTextColor = "#CA6F1E";

                rowCount = rowGroup != 3 ? 1 : rowCount;
                rowGroup = 3;
            }
            else if (u.last_request_period > 24 && u.last_request_period <= 36)
            {
                u.status = s + ", Gecikmə +24";
                u.trTextColor = "#C0392B";

                rowCount = rowGroup != 4 ? 1 : rowCount;
                rowGroup = 4;
            }
            else if (u.last_request_period > 36)
            {
                u.status = s + ", Gecikmə +36";
                u.trTextColor = "#78281F";

                rowCount = rowGroup != 5 ? 1 : rowCount;
                rowGroup = 5;
            }
            u.rowCount = rowCount;
            u.rowGeneral = rowGeneral;
            u.reminderColor = item.reminder_date != null && item.reminder_date != DateTime.MinValue ? DateTime.Now >= item.reminder_date ? "bgcolor04" : "" : "";
            u.readingStatusLastDate = item.last_request_date != null ? Convert.ToDateTime(item.last_request_date).ToString("yyyy-MM-dd hh:mm:ss") : DateTime.MinValue.ToString("yyyy-MM-dd hh:mm:ss");
            u.readingStatusHours = Convert.ToInt32(DateTime.Now.Subtract(Convert.ToDateTime(item.last_request_date)).TotalHours);
            u.readingStatusVersion = " versiya : " + item.version + ", elan: " + item.last_request_result;
            u.subscriberColor = item.subscriber_tag == 1 ? "bgcolor03" : item.subscriber_tag == 2 ? "bgcolor05" : "";
            u.tagColor = item.tag == 1 ? "bgcolor02" : "";
            return u;
        }
    }
}