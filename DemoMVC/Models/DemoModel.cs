using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class DemoModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime dob { get; set; }
        public string ddlgender { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
        public string image { get;set; }
        public HttpPostedFileBase imagefile { get; set; }
        public string Class { get; set; }

        public string subject { get; set; }
        public string teacher { get; set; }
        public string address { get;set; }


    }
}