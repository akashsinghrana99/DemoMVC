using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoMVC.ClsDemo
{
    public class ClsTeacherView
    {
        ClsTeacher obj = new ClsTeacher();

        public List<TeacherModel> GetTeacherData()
        {
            DataTable dt = new DataTable();
            dt = obj.GetTeacher();
            List<TeacherModel> list = new List<TeacherModel>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TeacherModel obj = new TeacherModel
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["name"]),
                        Class = Convert.ToString(dr["class"]),
                        Subject = Convert.ToString(dr["subject"])

                    };
                    list.Add(obj);

                }
                
            }
            return list;

        }
    }


}

