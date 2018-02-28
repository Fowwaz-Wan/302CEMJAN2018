using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LinqToExcel;
using System.Data.SqlClient;
using StandardPgm.Models;
using System.Diagnostics;
using System.Web.Security;
using System.Data.Entity.Infrastructure;
using System.Net.Mail;

namespace StandardPgm.Controllers
{
    public class SubjectController : Controller
    {
        private StdPgmDBEntities db = new StdPgmDBEntities();

        public ActionResult English()
        {
            ViewBag.VMainMenu = "English";
            var list = db.Subjects.Where(x => x.Subject1 == "English").ToList();

            return View("English", list);
        }
        public ActionResult EnglishEdit(int? id)
        {
            ViewBag.VMainMenu = "English";
            ViewBag.ClassroomList = db.M_DropDownParam.Where(x => x.Type == "RoomNo");
            ViewBag.ScheduleTimeList = db.M_DropDownParam.Where(x => x.Type == "ScheduleTime");
            ViewBag.WeekNoList = db.M_SpecialDropDown.Where(x => x.Type == "WeekNo");
            ViewBag.DayList = db.M_DropDownParam.Where(x => x.Type == "ScheduleDay");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subject = db.Subjects.Where(x => x.ID == id).FirstOrDefault();

            if (subject == null)
            {
                return HttpNotFound();
            }
            
            return View("EnglishEdit", subject);
        }

        public ActionResult BM()
        {
            ViewBag.VMainMenu = "BM";
            var list = db.Subjects.Where(x => x.Subject1 == "BM").ToList();

            return View("BM", list);
        }
        public ActionResult BMEdit(int? id)
        {
            ViewBag.VMainMenu = "BM";
            ViewBag.ClassroomList = db.M_DropDownParam.Where(x => x.Type == "RoomNo");
            ViewBag.ScheduleTimeList = db.M_DropDownParam.Where(x => x.Type == "ScheduleTime");
            ViewBag.WeekNoList = db.M_SpecialDropDown.Where(x => x.Type == "WeekNo");
            ViewBag.DayList = db.M_DropDownParam.Where(x => x.Type == "ScheduleDay");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subject = db.Subjects.Where(x => x.ID == id).FirstOrDefault();

            if (subject == null)
            {
                return HttpNotFound();
            }

            return View("BMEdit", subject);
        }


        public ActionResult Business()
        {
            ViewBag.VMainMenu = "Business";
            var list = db.Subjects.Where(x => x.Subject1 == "Business").ToList();

            return View("Business", list);
        }
        public ActionResult BusinessEdit(int? id)
        {
            ViewBag.VMainMenu = "Business";
            ViewBag.ClassroomList = db.M_DropDownParam.Where(x => x.Type == "RoomNo");
            ViewBag.ScheduleTimeList = db.M_DropDownParam.Where(x => x.Type == "ScheduleTime");
            ViewBag.WeekNoList = db.M_SpecialDropDown.Where(x => x.Type == "WeekNo");
            ViewBag.DayList = db.M_DropDownParam.Where(x => x.Type == "ScheduleDay");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subject = db.Subjects.Where(x => x.ID == id).FirstOrDefault();

            if (subject == null)
            {
                return HttpNotFound();
            }

            return View("BusinessEdit", subject);
        }


        public ActionResult History()
        {
            ViewBag.VMainMenu = "History";
            var list = db.Subjects.Where(x => x.Subject1 == "History").ToList();

            return View("History", list);
        }
        public ActionResult HistoryEdit(int? id)
        {
            ViewBag.VMainMenu = "History";
            ViewBag.ClassroomList = db.M_DropDownParam.Where(x => x.Type == "RoomNo");
            ViewBag.ScheduleTimeList = db.M_DropDownParam.Where(x => x.Type == "ScheduleTime");
            ViewBag.WeekNoList = db.M_SpecialDropDown.Where(x => x.Type == "WeekNo");
            ViewBag.DayList = db.M_DropDownParam.Where(x => x.Type == "ScheduleDay");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subject = db.Subjects.Where(x => x.ID == id).FirstOrDefault();

            if (subject == null)
            {
                return HttpNotFound();
            }

            return View("HistoryEdit", subject);
        }


        public string CheckSchedule(Subject s)
        {
            var existingSchedule = db.Subjects.Where(x => x.Classroom == s.Classroom &&
                                                          x.WeekNo == s.WeekNo &&
                                                          x.Day == s.Day &&
                                                          x.Time == s.Time).FirstOrDefault();
            var originalSchedule = db.Subjects.Where(x => x.ID == s.ID).FirstOrDefault();
            var senderUser = Session["userID"].ToString();
            var sender = db.M_User.Where(x => x.UserID == senderUser).Select(x => x.Email).FirstOrDefault();
            var senderName = db.M_User.Where(x => x.UserID == senderUser).Select(x => x.UserName).FirstOrDefault();
            var receiver = db.M_User.Where(x => x.AccessType == "Admin").Select(x => x.Email).FirstOrDefault();
            var Host = db.M_SystemControl.Where(x => x.ControlType == "SMTPServer").Select(x => x.ControlValue).FirstOrDefault();
            var Port = db.M_SystemControl.Where(x => x.ControlType == "SMTPPort").Select(x => x.ControlValue).FirstOrDefault();
            var CredentialsEmail = db.M_SystemControl.Where(x => x.ControlType == "SMTPUsername").Select(x => x.ControlValue).FirstOrDefault();
            var CredentialsPassword = db.M_SystemControl.Where(x => x.ControlType == "SMTPPassword").Select(x => x.ControlValue).FirstOrDefault();

            var smtp = new SmtpClient
            {
                Host = Host,
                Port = int.Parse(Port),
                //DeliveryMethod = SmtpDeliveryMethod.Network,
                //UseDefaultCredentials = false,
                //EnableSsl = false,
                Credentials = new NetworkCredential(CredentialsEmail, CredentialsPassword)
            };

            if (existingSchedule != null)
            {
                return "Request Failed!";
            }
            else
            {
                string subject = "Class Replacement Request";
                string body = "Class Replacement for " + originalSchedule.Subject1 + "is requested to change from Week No." 
                               + originalSchedule.WeekNo + " to " + s.WeekNo + ", on " + originalSchedule.Time + " to "
                               + s.Time + ", Room No." + originalSchedule.Classroom + " to " + s.Classroom;
                var message = new MailMessage();
                message.From = new MailAddress(sender);
                message.To.Add(receiver);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = false;
                smtp.Send(message);

                T_Approval ta = new T_Approval();
                ta.Subject = s.Subject1;
                ta.Startdate = s.Startdate;
                ta.Enddate = s.Enddate;
                ta.WeekNo = s.WeekNo;
                ta.Classroom = s.Classroom;
                ta.Time = s.Time;
                ta.Day = s.Day;
                ta.Lecturer = s.Lecturer;
                ta.Status = "Pending";
                ta.RequestBy = Session["username"].ToString();
                ta.SubID = s.ID;

                db.T_Approval.Add(ta);
                db.SaveChanges();

                return "Request Submitted Successfully!";
            }
        }

        public ActionResult BackToListBM()
        {
            return Redirect("~/Subject/BM");
        }

        public ActionResult BackToListHistory()
        {
            return Redirect("~/Subject/History");
        }

        public ActionResult BackToListEnglish()
        {
            return Redirect("~/Subject/English");
        }

        public ActionResult BackToListBusiness()
        {
            return Redirect("~/Subject/Business");
        }
    }
}