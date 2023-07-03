using Swachh_Bharat_Abhiyan_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swachh_Bharat_Abhiyan_Project.Controllers
{
    public class Default1Controller : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Registration_Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration_Form(string name,string fname,string gender,double nmbr,string mail,string dob,string city,string quali,string pswrd,string cpswrd)
        {
            string query = "insert into Registration_tbl values('"+name+"','"+fname+"','"+gender+"', '"+nmbr+"','"+mail+"','"+dob+"','"+city+"','"+quali+"','"+pswrd+"','"+DateTime.Now.ToShortDateString()+"', 1) ";
                       
            string query1 = "insert into Login_tbl values('"+mail+"','"+pswrd+"','User',1)";
            SBAManager sb = new SBAManager();    
            bool n = sb.InsertUpdateAndDelete(query);
            if (n == true)
            {
                bool n1 = sb.InsertUpdateAndDelete(query1);
                if (n1 == true)
                    ViewBag.n = "Registration Successful";
                else
                    ViewBag.n = "Failed for login";
            }
            else
                ViewBag.n = "Registration Failed";
        
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string uid,string psw)
        {
            string query2 = "select * from Login_tbl where Email='"+uid+"' and Pass='"+psw+"' and IsActive=1";
            SBAManager sb = new SBAManager();
            DataTable dt = new DataTable();
            dt=sb.GetAllRecord(query2);
            if (dt.Rows.Count > 0)
            {
                string role = dt.Rows[0]["Roles"].ToString();
                if (role == "Admin")
                {
                    Session["userid"] = dt.Rows[0]["Email"].ToString();
                    Response.Redirect("/Admin/Dashboard");
                }
            }
            else
                ViewBag.m = "You are not registered.";

            return View();
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(string em, double no, string sg )
        {
            string query3 = "insert into Sug_tbl values('"+em+"','"+no+"','"+sg+"')";
            SBAManager sb = new SBAManager();
            bool n2 = sb.InsertUpdateAndDelete(query3);
            if (n2 == true)
                ViewBag.t = "Done";
            else
                ViewBag.t = "Failed";

            

            return View();
        }
        [HttpGet]
        public ActionResult Donation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Donation(string nm,string pnam,double nmb, string email,string adrs,string prps,int rs,string dt,string acn,HttpPostedFileBase file)
        {
            string query4 = "insert into DN_tbl values('" + nm + "','" + pnam + "','" + nmb + "','" + email + "','" + adrs + "','" + prps + "','" + rs + "','" + dt + "','" + acn + "','" + file.FileName + "','" + DateTime.Now.ToShortDateString() + "' )";
            string p = Path.Combine(Server.MapPath("/Content/UploadImage"), file.FileName);
            file.SaveAs(p);
            SBAManager sb = new SBAManager();
            bool n3 = sb.InsertUpdateAndDelete(query4);
            if (n3 == true)
                ViewBag.d = "Donation Done";
            else
                ViewBag.d = "Donation Failed";
            return View();
        }
        public ActionResult Image()
        {
            return View();
        }

        public ActionResult TermsConditions()
        {
            return View();
        }

        public ActionResult Suggestions()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Seva()
        {
            return View();
        }

        public ActionResult Gobardhan()
        {
            return View();
        }

        public ActionResult SLWM()
        {
            return View();
        }

        public ActionResult Nmani()
        {

            return View();
        }

        public ActionResult Areas()
        {

            return View();
        }

        public ActionResult Impacts()
        {

            return View();
        }


    }
}
