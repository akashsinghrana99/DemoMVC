using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoMVC.ClsDemo
{
    public class ClsDemoView
    {
        ClsDemos obj = new ClsDemos();

        public List<DemoModel>GetDemoData()
        {
            DataTable dt = new DataTable();
            dt = obj.GetDemo();
            List<DemoModel> list = new List<DemoModel>();

            if(dt!=null && dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    DemoModel obj = new DemoModel
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        email = Convert.ToString(dr["email"]),
                        phone = Convert.ToString(dr["phone"]),
                        dob = Convert.ToDateTime(dr["dob"]),
                        ddlgender = Convert.ToString(dr["gender"]),
                        userid = Convert.ToString(dr["userid"]),
                        password = Convert.ToString(dr["password"]),
                        image = Convert.ToString(dr["image"]),
                        Class = Convert.ToString(dr["class"]),
                        subject = Convert.ToString(dr["subject"]),
                        teacher = Convert.ToString(dr["teacher"]),
                        address = Convert.ToString(dr["address"])
                    };
                    list.Add(obj);
                }
            }
            return list;
        }
    }
}