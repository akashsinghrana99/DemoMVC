using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoMVC.ClsDemo
{
    public class ClsTeacher
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public bool AddTeacher(TeacherModel obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("AddTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@class", obj.Class);
                cmd.Parameters.AddWithValue("@subject", obj.Subject);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if(i>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public DataTable GetTeacher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("GetTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt!=null && dt.Rows.Count>0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool UpdateTeacher(TeacherModel obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UpdateTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@class", obj.Class);
                cmd.Parameters.AddWithValue("@subject", obj.Subject);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if(i>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                   


            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool DeleteTeacher(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DeleteTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if(i>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}