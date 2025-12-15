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
    public class ClsDemos
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public bool AddDemo(DemoModel obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State== ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("AddDemoData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@email", obj.email);
                cmd.Parameters.AddWithValue("@phone", obj.phone);
                cmd.Parameters.AddWithValue("@dob", obj.dob);
                cmd.Parameters.AddWithValue("@gender", obj.ddlgender);
                cmd.Parameters.AddWithValue("@userid", obj.userid);
                cmd.Parameters.AddWithValue("@password", obj.password);
                cmd.Parameters.AddWithValue("@image", obj.image);
                cmd.Parameters.AddWithValue("@class", obj.Class);
                cmd.Parameters.AddWithValue("@subject", obj.subject);
                cmd.Parameters.AddWithValue("@teacher", obj.teacher);
                cmd.Parameters.AddWithValue("@address", obj.address);

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
            catch(Exception Ex)
            {
                return false;
            }

        }
        public DataTable GetDemo()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("GetDemo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
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
        public bool DeleteDemo(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DeleteDemoData", con);
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
        public bool UpdateDemo(DemoModel obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UpdateDemoData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.id);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@email", obj.email);
                cmd.Parameters.AddWithValue("@phone", obj.phone);
                cmd.Parameters.AddWithValue("@dob", obj.dob);
                cmd.Parameters.AddWithValue("@gender", obj.ddlgender);
                cmd.Parameters.AddWithValue("@userid", obj.userid);
                cmd.Parameters.AddWithValue("@password", obj.password);
                cmd.Parameters.AddWithValue("@image", obj.image);
                cmd.Parameters.AddWithValue("@class", obj.Class);
                cmd.Parameters.AddWithValue("@subject", obj.subject);
                cmd.Parameters.AddWithValue("@teacher", obj.teacher);
                cmd.Parameters.AddWithValue("@address", obj.address);

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