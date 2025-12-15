using DemoMVC.ClsDemo;
using DemoMVC.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class TeacherController : Controller
    {
        ClsTeacher objTech = new ClsTeacher();
        ClsTeacherView objtechviw = new ClsTeacherView();
        // GET: Teacher
        public ActionResult Index()
        {
            var list = objtechviw.GetTeacherData();
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(TeacherModel obj)
        {
            if(!string.IsNullOrEmpty(obj.Name)&& !string.IsNullOrEmpty(obj.Subject) && !string.IsNullOrEmpty(obj.Class))
            {
                if(objTech.AddTeacher(obj))
                {
                    ViewBag.Mess = "Teacher Data Added SuccessFully";
                }
                else
                {
                    ViewBag.Error = "Teacher Data Not Added";
                }
            }
            else
            {
                ViewBag.Error = "Please Fill All Fild is Required";
            }
            var list = objtechviw.GetTeacherData();
            return View(list);

        }

        [HttpPost]
        public JsonResult UpdateTeacher(TeacherModel obj)
        {
            string str = "";
             if(!string.IsNullOrEmpty(obj.Name)&& !string.IsNullOrEmpty(obj.Subject) && !string.IsNullOrEmpty(obj.Class))
            {
                if(objTech.UpdateTeacher(obj))
                {
                    str = "success";

                }
                else
                {
                    str = "Teacher Data Not Added";
                }
            }
            else
            {
                ViewBag.Error = "Please Fill All Fild is Required";
            }
            return Json(new { result = str }, JsonRequestBehavior.AllowGet);

        }


        
        public JsonResult DeleteTeacher(TeacherModel obj)
        {
            string str = "";
            if(objTech.DeleteTeacher(obj.Id))
            {
                str = "success";
            }
            else
            {
                str = "Data Not Deleted";
            }
            return Json(new { result = str }, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public JsonResult GetTeacher()
        //{
        //    try
        //    {
        //        var data = objTech.GetTeacher();   // MUST return List<TeacherModel>
        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { error = ex.Message });
        //    }
        //}


        [HttpPost]
        public JsonResult GetTeacher()
        {
            try
            {
                var data = objTech.GetTeacher();   // fetch list only

                var json = JsonConvert.SerializeObject(
                    data,
                    Formatting.None,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }
                );

                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }



        [HttpGet]
        public JsonResult GetTeachers()
        
        {
            List<TeacherModel> list = new List<TeacherModel>();
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if(con.State==ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //string query = "SELECT * FROM teacher";

                    SqlCommand cmd = new SqlCommand("GetTeacher", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new TeacherModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name =Convert.ToString( dr["Name"])
                        });
                    }
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetClass()
        {
            List<TeacherModel> list = new List<TeacherModel>();
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using(SqlConnection con= new SqlConnection(strcon))
                {
                    if(con.State==ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("GetTeacher",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        list.Add(new TeacherModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Class = Convert.ToString(dr["class"])
                        });
                    }
                }
                return Json(list, JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetSubject()
        {
            List<TeacherModel> list = new List<TeacherModel>();
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using(SqlConnection con= new SqlConnection(strcon))
                {
                    if(con.State==ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("GetTeacher", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        list.Add(new TeacherModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Subject = Convert.ToString(dr["subject"])
                        });
                    }
                }
                return Json(list, JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}