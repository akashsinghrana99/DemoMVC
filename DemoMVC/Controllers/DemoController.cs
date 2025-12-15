using DemoMVC.ClsDemo;
using DemoMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DemoMVC.Controllers
{
    public class DemoController : Controller
    {
        ClsDemoView objdemview = new ClsDemoView();
        ClsTeacher objTech = new ClsTeacher();
        ClsDemos objDemo= new ClsDemos();
        // GET: Demo
        public ActionResult Index()
        {
            ViewBag.TxtUserid = "AS" + DateTime.Now.ToString("ddMMyyss");
            var list = objdemview.GetDemoData();
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(DemoModel obj)
        {
            if (obj.imagefile != null && obj.imagefile.ContentLength > 0)
            {
                string folderPath = Server.MapPath("~/Uploads/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filename = Path.GetFileName(obj.imagefile.FileName);

                // Correct order
                string fullpath = Path.Combine(folderPath, filename);

                obj.imagefile.SaveAs(fullpath);

                // Save path to DB
                obj.image = "~/Uploads/" + filename;
            }

            

            if (!string.IsNullOrEmpty(obj.name) && !string.IsNullOrEmpty(obj.email) && !string.IsNullOrEmpty(obj.phone) && !string.IsNullOrEmpty(obj.ddlgender)
                &&!string.IsNullOrEmpty(obj.Class)&& !string.IsNullOrEmpty(obj.subject)&& !string.IsNullOrEmpty(obj.teacher) && !string.IsNullOrEmpty(obj.address)
                &&!string.IsNullOrEmpty(obj.image)&& !string.IsNullOrEmpty(obj.userid)&& !string.IsNullOrEmpty(obj.password))
            {
                if(objDemo.AddDemo(obj))
                {
                    ViewBag.Mess = "Damo Data Inserted Successfully";
                }
                else
                {
                    ViewBag.Err = "Fail to Data Insert";
                }

            }
            else
            {
                ViewBag.Error = "Please Fill All Fild is Required";
            }
            var list = objdemview.GetDemoData();
            return View(list);
        }

        public JsonResult DeleteDemo(DemoModel obj)
        {
            string str = "";
            if(objDemo.DeleteDemo(obj.id))
            {
                str = "success";
            }
            else
            {
                str = "data deleted fail";
            }
            return Json(new { result = str }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateDemo(DemoModel obj)
        {
            string str = "";
            string oldImage = obj.image;   // Keep existing image

            // Handle image upload
            if (obj.imagefile != null && obj.imagefile.ContentLength > 0)
            {
                string folderPath = Server.MapPath("~/Uploads/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filename = Path.GetFileName(obj.imagefile.FileName);
                string fullpath = Path.Combine(folderPath, filename);

                obj.imagefile.SaveAs(fullpath);

                obj.image = "~/Uploads/" + filename;  // Save correct path
            }
            else
            {
                // No new file uploaded → keep old image
                obj.image = oldImage;
            }
            if (!string.IsNullOrEmpty(obj.name) && !string.IsNullOrEmpty(obj.email) && !string.IsNullOrEmpty(obj.phone) && !string.IsNullOrEmpty(obj.ddlgender)
                && !string.IsNullOrEmpty(obj.Class) && !string.IsNullOrEmpty(obj.subject) && !string.IsNullOrEmpty(obj.teacher) && !string.IsNullOrEmpty(obj.address)
                && !string.IsNullOrEmpty(obj.image) && !string.IsNullOrEmpty(obj.userid) && !string.IsNullOrEmpty(obj.password))
            {
                if (objDemo.UpdateDemo(obj))
                {
                    str = "success";
                }
                else
                {
                    str = "data update fail";
                }
                

            }
            else
            {
                ViewBag.Error = "Please Fill All Fild is Required";
            }
            return Json(new { result = str }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDemo()
        {
            try
            {
                var data = objDemo.GetDemo();   // fetch list only

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
    }
}