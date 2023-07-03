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
    public class AdminController : Controller
    {
        //
        string userid;
      public void Getseesion()
        {
            userid = Session["userid"]+"";
          if(userid=="")
          {
              Response.Redirect("/Default1/login");
          }
        }
     
        public ActionResult Dashboard()
        {
            Getseesion();
            return View();
        }

        [HttpGet]
        public ActionResult ViewRegistration()
        {
            Getseesion();
            string tr = "";
            SBAManager s = new SBAManager();
            string cmd = "select * from Registration_tbl";
            DataTable dt;
           dt= s.GetAllRecord(cmd);
            if(dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    tr += "<tr><td>" + i + "</td><td>" + dt.Rows[i]["Name"].ToString() + "</td><td>" + dt.Rows[i]["FatherName"].ToString() + "</td><td>" + dt.Rows[i]["Gender"].ToString() + "</td><td>" + dt.Rows[i]["MobileNo"].ToString() + "</td><td>" + dt.Rows[i]["Email"].ToString() + "</td><td>" + dt.Rows[i]["DateofBirth"].ToString() + "</td><td>" + dt.Rows[i]["State"].ToString() + "</td><td>" + dt.Rows[i]["Qualification"].ToString() + "</td><td>" + dt.Rows[i]["Rdate"].ToString() + "</td><td><a href='/Admin/EditProfile?id="+dt.Rows[i]["Email"]+"' class='btn btn-danger'>Edit</a><a href='/Admin/DeleteReg?id=" + dt.Rows[i]["Email"] + "' class='btn btn-warning'>Delete</a></td></tr>";
                }
                ViewBag.tr = tr;

            }

            return View();
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            Getseesion();
            string id = Session["userid"].ToString();
            string cmd = "select * from Registration_tbl where Email='"+id+"'";
            SBAManager sb = new SBAManager();
           DataTable tbl = sb.GetAllRecord(cmd);
            if(tbl.Rows.Count>0)
            {
                ViewBag.name= tbl.Rows[0]["Name"].ToString();
                ViewBag.gender=tbl.Rows[0]["Gender"].ToString();
                ViewBag.email=tbl.Rows[0]["Email"].ToString();
                ViewBag.mobile=tbl.Rows[0]["MobileNo"].ToString();
                ViewBag.dob=tbl.Rows[0]["DateofBirth"].ToString();
                ViewBag.fn = tbl.Rows[0]["FatherName"].ToString();
                ViewBag.state=tbl.Rows[0]["State"].ToString();
                ViewBag.qualification = tbl.Rows[0]["Qualification"].ToString();
            }
            return View();
        }
        [HttpGet]
              public ActionResult EditProfile(string eid)
        {
            Getseesion();
            string id = Session["userid"].ToString();
            if(eid==null||eid=="")
            {
                
            }
            else
            {
                id = eid;
            }
            
            string cmd = "select * from Registration_tbl where Email='"+id+"'";
            SBAManager sb = new SBAManager();
           DataTable tbl = sb.GetAllRecord(cmd);
           if (tbl.Rows.Count > 0)
           {
               ViewBag.name = tbl.Rows[0]["Name"].ToString();
               ViewBag.gender = tbl.Rows[0]["Gender"].ToString();
               ViewBag.email = tbl.Rows[0]["Email"].ToString();
               ViewBag.mobile = tbl.Rows[0]["MobileNo"].ToString();
               
               ViewBag.fn = tbl.Rows[0]["FatherName"].ToString();
               ViewBag.state = tbl.Rows[0]["State"].ToString();
               ViewBag.qualification = tbl.Rows[0]["Qualification"].ToString();
               ViewBag.user = tbl.Rows[0]["Email"].ToString();
           }
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(string name, string fname, string gender, double nmbr, string mail,  string city, string quali,string user)
        {
            Getseesion();
            string id=Session["userid"]+"";
            if (user == null || user == "")
            {
                
            }
            else
            {

            }
     string cmd = "update Registration_tbl set name='" + name + "',FatherName='" + fname + "',Gender='" + gender + "', MobileNo='" + nmbr + "',Email='" + mail + "',State='" + city + "',Qualification='" + quali + "' where Email='"+id+"' ";
            SBAManager sb = new SBAManager();
            bool t = sb.InsertUpdateAndDelete(cmd);
            if(t==true)
            {
                if(user!=null||user!="")
                {
                    Response.Redirect("/Admin/ViewRegistration");
                }
                else
                {
                    Response.Redirect("/Admin/MyProfile");
                }
                
            }
            else
            {
                Response.Write("Try again"); 

            }

            return View();
        }

        [HttpGet]
        public ActionResult ViewDonation()
        {
            Getseesion();
            string dn = " ";
            SBAManager s = new SBAManager();
            string cmd = "select * from DN_tbl";
            DataTable d;
            d = s.GetAllRecord(cmd);
            if(d.Rows.Count>0)
            {
                for(int i=0;i<d.Rows.Count;i++)
                {
                    dn += "<tr><td>" + i + "</td><td>" + d.Rows[i]["Name"].ToString() + "</td><td>" + d.Rows[i]["FatherName"].ToString() + "</td><td>" + d.Rows[i]["MobileNo"].ToString() + "</td><td>" + d.Rows[i]["Email"].ToString() + "</td><td>" + d.Rows[i]["Address"].ToString() + "</td><td>" + d.Rows[i]["DonationPurpose"].ToString() + "</td><td>" + d.Rows[i]["Amount"].ToString() + "</td><td>" + d.Rows[i]["DonorDT"].ToString() + "</td><td>" + d.Rows[i]["Ac_No"].ToString() + "</td><td>" + d.Rows[i]["PayReceipt"].ToString() + "</td><td>" + d.Rows[i]["D_date"].ToString() + "</td></tr>";
                }
                ViewBag.st = dn;
            }

            return View();
        }

        [HttpGet]
        public ActionResult ViewSug()
        {
            Getseesion();
            string f = " ";
            SBAManager s = new SBAManager();
            string cmd = "select * from Sug_tbl";
            DataTable dt;
            dt = s.GetAllRecord(cmd);
            if(dt.Rows.Count>0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    f += "<tr><td>" + i + "</td><td>" + dt.Rows[i]["Email"].ToString() + "</td><td>" + dt.Rows[i]["Number"].ToString() + "</td><td>" + dt.Rows[i]["Comment"].ToString() + "</td> </tr> ";
                }
                ViewBag.fd = f;
            }

            return View();
        }

        public ActionResult Logout()
        {
            Getseesion();
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/Admin/Dashboard");
            return View();

        }
        [HttpGet]
        public ActionResult AddGallery()
        {
            string f = " ";
            SBAManager s = new SBAManager();
            string cmd = "select * from Gallery_tbl where Isactive=1";
            DataTable dt;
            dt = s.GetAllRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    f += "<tr><td>" + (1 + i) + "</td><td>" + dt.Rows[i]["Title"] + "</td><td><img src='/Content/UploadImage/" + dt.Rows[i]["Image"] + "' height='50px'/></td><td><a href='/admin/DelGallery?id="+dt.Rows[i]["sr"]+"'><i class='fa fa-trash'></i></a></td></tr>";
                }
                ViewBag.fd = f;
            }
            return View();

        }
        [HttpPost]
        public ActionResult AddGallery(string title,HttpPostedFileBase img)
        {
            string cmd = "insert into Gallery_tbl values('" + title + "','" + img.FileName + "',1)";
            string p = Path.Combine(Server.MapPath("/Content/UploadImage"), img.FileName);
            img.SaveAs(p);
            SBAManager sb = new SBAManager();
            bool n3 = sb.InsertUpdateAndDelete(cmd);
            if (n3 == true)
                ViewBag.d = "<div class='alert alert-success alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>Well done!</strong> Image saved successfuly.</div>";
            else
                ViewBag.d1 = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>Warning!</strong> Image not saved.</div>";
            return View();

        }
        public ActionResult DelGallery(string id)
        {
            string cmd = "delete from Gallery_tbl where sr='" + id + "'";
            SBAManager sb = new SBAManager();
            bool t = sb.InsertUpdateAndDelete(cmd);
            if (t == true)
            {
                Response.Write("<script>alert('Successfully Delete')<script>");
                Response.Redirect("/Admin/AddGallery");
            }
            else
            {
                Response.Write("<script>alert('try again')<script>");

            }
            return View();

        }

        [HttpGet]
        public ActionResult AddNoti()
        {
            string f = " ";
            SBAManager s = new SBAManager();
            string cmd = "select * from Notificatio_tbl where Isactive=1";
            DataTable dt;
            dt = s.GetAllRecord(cmd);
            if(dt.Rows.Count>0)
            {
                
                    f += "<tr><td>" + (0) + "</td><td>" + dt.Rows[0]["Title"] + "</td><td>" + dt.Rows[0]["Description"] + "</td><td><a href='/admin/DelNoti?id=" + dt.Rows[0]["sr"] + "'><i class='fa fa-trash'></i></a></td></tr>";
            }
            ViewBag.fd = f;
            return View();
        }
        [HttpPost]
        public ActionResult AddNoti(string title,string description)
        {
            string cmd = "insert into Notificatio_tbl values('" + title + "','" + description + "',1) ";
            SBAManager sb = new SBAManager();
            bool n3 = sb.InsertUpdateAndDelete(cmd);
            if (n3 == true)
                ViewBag.d = "<div class='alert alert-success alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>Well done!</strong> Notification added successfuly.</div>";

            else
                ViewBag.d1 = "<div class='alert alert-warning alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>Warning!</strong> Notification not added.</div>";

            return View();
        }

        public ActionResult DelNoti(string id)
        {
            string cmd = "delete from Notificatio_tbl where sr='" + id + "'";
            SBAManager sb = new SBAManager();
            bool t = sb.InsertUpdateAndDelete(cmd);
            if (t == true)
            {
                Response.Write("<script>alert('Successfully Delete')<script>");
                Response.Redirect("/Admin/AddNoti");
            }
            else
            {
                Response.Write("<script>alert('try again')<script>");

            }
            return View();

        }



        public ActionResult DeleteReg( string id)
        {
            string cmd = "delete from Registration_tbl where Email='" + id + "'";
            SBAManager sb = new SBAManager();
            bool t = sb.InsertUpdateAndDelete(cmd);
            if (t == true)
            {
                Response.Write("<script>alert('Successfully Delete')<script>");
                Response.Redirect("/Admin/ViewRegistration");
            }
            else
            {
                Response.Write("<script>alert('try again')<script>");

            }

            return View();

        }

    }
}
