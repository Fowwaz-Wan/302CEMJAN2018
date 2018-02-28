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
using System.Net.Mail;

namespace StandardPgm.Controllers
{
    [SessionExpire]
    [HandleError]
    public class AdminController : Controller
    {
        private StdPgmDBEntities db = new StdPgmDBEntities();

        // GET: Admin
        public ActionResult Index(string department, string group)
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.MenuName).FirstOrDefault();

            var list = db.M_User;
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(int txtID)
        {
            var item = db.M_User.Where(x => x.ID == txtID).FirstOrDefault();

            if (item != null)
            {
                db.M_User.Remove(item);
                db.SaveChanges();
            }
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.MenuName).FirstOrDefault();
            var list = db.M_User;
            return View(list);
        }

        // GET: Admin/Details/5

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.AccessTypeDropDown = db.M_DropDownParam.Where(x => x.Type == "AccessType");
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.MenuName).FirstOrDefault();
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(M_User m_User)
        {
            m_User.CreatedDate = DateTime.Now;
            m_User.UpdatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.M_User.Add(m_User);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(m_User);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.AccessTypeDropDown = db.M_DropDownParam.Where(x => x.Type == "AccessType");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_User m_User = db.M_User.Find(id);
            if (m_User == null)
            {
                return HttpNotFound();
            }
            return View(m_User);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(M_User m_User)
        {
            m_User.UpdatedDate = DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(m_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m_User);
        }

        public ActionResult Approval()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "202").Select(x => x.MenuName).FirstOrDefault();
            var list = db.T_Approval.ToList();

            return View("Approval", list);
        }

        public string ApproveSchedule(T_Approval ta)
        {
            var sender = db.M_User.Where(x => x.AccessType == "Admin").Select(x => x.Email).FirstOrDefault();
            var pendingSchedule = db.T_Approval.Where(x => x.ID == ta.ID).FirstOrDefault();
            var receiver = db.M_User.Where(x => x.UserID == pendingSchedule.RequestBy).Select(x => x.Email).FirstOrDefault();
            var removeOriginalSchedule = db.Subjects.Where(x => x.ID == ta.SubID).FirstOrDefault();
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

            string subject = "Class Replacement Approved!";
            string body = "Hi " + pendingSchedule.RequestBy + ", your request on Class Replacement is Approved!";

            var message = new MailMessage();
            message.From = new MailAddress(sender);
            message.To.Add(receiver);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = false;
            smtp.Send(message);

            removeOriginalSchedule.ID = removeOriginalSchedule.ID;
            removeOriginalSchedule.Subject1 = ta.Subject;
            removeOriginalSchedule.Startdate = ta.Startdate;
            removeOriginalSchedule.Enddate = ta.Enddate;
            removeOriginalSchedule.WeekNo = ta.WeekNo;
            removeOriginalSchedule.Classroom = ta.Classroom;
            removeOriginalSchedule.Time = ta.Time;
            removeOriginalSchedule.Day = ta.Day;
            removeOriginalSchedule.Lecturer = ta.Lecturer;
            
            db.T_Approval.Remove(pendingSchedule);
            db.SaveChanges();

            return "Class Replacement Approved!";
        }

        public string DenySchedule(T_Approval ta)
        {
            var sender = db.M_User.Where(x => x.AccessType == "Admin").Select(x => x.Email).FirstOrDefault();
            var pendingSchedule = db.T_Approval.Where(x => x.ID == ta.ID).FirstOrDefault();
            var receiver = db.M_User.Where(x => x.UserID == pendingSchedule.RequestBy).Select(x => x.Email).FirstOrDefault();
            var removeOriginalSchedule = db.Subjects.Where(x => x.ID == ta.SubID).FirstOrDefault();
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

            string subject = "Class Replacement Rejected!";
            string body = "Hi " + pendingSchedule.RequestBy + ", your request on Class Replacement is Rejected!";

            var message = new MailMessage();
            message.From = new MailAddress(sender);
            message.To.Add(receiver);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = false;
            smtp.Send(message);

            db.T_Approval.Remove(pendingSchedule);
            db.SaveChanges();

            return "Class Replacement Rejected!";
        }
        
        public FileResult DownloadExcel()
        {
            string path = "/Doc/Users.xlsx";
            return File(path, "application/vnd.ms-excel", "Users.xlsx");
        }


    }
}
