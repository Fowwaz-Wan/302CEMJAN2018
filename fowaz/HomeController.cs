using StandardPgm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandardPgm.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private StdPgmDBEntities db = new StdPgmDBEntities();
        public ActionResult Index()
        {
            var item = db.M_SystemControl.Where(x => x.ControlType == "Announcement").FirstOrDefault();

            ViewBag.VLogo = db.M_SystemControl.Where(x => x.ControlType == "Logo").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VApplication = db.M_SystemControl.Where(x => x.ControlType == "Application").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCopyRight = db.M_SystemControl.Where(x => x.ControlType == "CopyRight").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCompanyDesc = db.M_SystemControl.Where(x => x.ControlType == "CompanyDesc").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VSponsor = db.M_SystemControl.Where(x => x.ControlType == "SponsoredComp").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VBackground = db.M_SystemControl.Where(x => x.ControlType == "Background").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VApplDesc1 = db.M_SystemControl.Where(x => x.ControlType == "ApplDesc1").Select(x => x.ControlValue).FirstOrDefault().Split('#');
                     
            return View(item);
            
        }


        [HttpPost]
        public ActionResult Index(string txtUsername, string txtPassword)
        {
            var item = db.M_User.Where(x => x.UserID == txtUsername && x.Password == txtPassword).FirstOrDefault();
            //try
            //{
            //}
            //catch (Exception ex) { MessageBox.Show(ex.InnerException.ToString()); }
            var item1 = db.M_SystemControl.Where(x => x.ControlType == "Announcement").FirstOrDefault();

            ViewBag.VMainCtrl = db.C_Menu.Where(x => x.MenuName == "Main Menu").Select(x => x.MenuController).FirstOrDefault();
            ViewBag.VMainView = db.C_Menu.Where(x => x.MenuName == "Main Menu").Select(x => x.MenuView).FirstOrDefault();
            
            ViewBag.VLogo = db.M_SystemControl.Where(x => x.ControlType == "Logo").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VApplication = db.M_SystemControl.Where(x => x.ControlType == "Application").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCopyRight = db.M_SystemControl.Where(x => x.ControlType == "CopyRight").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCompanyDesc = db.M_SystemControl.Where(x => x.ControlType == "CompanyDesc").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VSponsor = db.M_SystemControl.Where(x => x.ControlType == "SponsoredComp").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VBackground = db.M_SystemControl.Where(x => x.ControlType == "Background").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VApplDesc1 = db.M_SystemControl.Where(x => x.ControlType == "ApplDesc1").Select(x => x.ControlValue).FirstOrDefault().Split('#');

            if (item != null)
            {
                Session["username"] = txtUsername;
                Session["userID"] = item.UserID;
                Session["accesstype"] = item.AccessType;
                
              
                return RedirectToAction(ViewBag.VMainView, ViewBag.VMainCtrl);
            }
            else
            {
                ModelState.AddModelError("", "invalid username or password");
                return View(item1);
            }
        }

        public ActionResult Index1()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "000").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.AccessType = Session["accesstype"].ToString();


            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "101").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "101").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "101").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "101").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "101").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "102").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "102").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "102").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "102").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "102").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "103").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "103").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "103").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "103").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "103").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "104").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "104").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "104").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "104").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "104").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "201").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "202").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "202").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "202").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "202").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "202").Select(x => x.MenuController).FirstOrDefault();

            return View();

        }

        













        public ActionResult ChangePassword()
        {
            ViewBag.VLogo = db.M_SystemControl.Where(x => x.ControlType == "Logo").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VApplication = db.M_SystemControl.Where(x => x.ControlType == "Application").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCopyRight = db.M_SystemControl.Where(x => x.ControlType == "CopyRight").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCompanyDesc = db.M_SystemControl.Where(x => x.ControlType == "CompanyDesc").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VSponsor = db.M_SystemControl.Where(x => x.ControlType == "SponsoredComp").Select(x => x.ControlValue).FirstOrDefault();

            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuGroup == "Password").Select(x => x.MenuName).FirstOrDefault();

            string userID = Session["userID"].ToString();

            var item = db.M_User.Where(x => x.UserID == userID).FirstOrDefault();
            ViewBag.CurrentPassword = item.Password;

            return View(item);
        }

        [HttpPost]
        public ActionResult ChangePassword(M_User item)
        {
            string userID = Session["userID"].ToString();

            var row = db.M_User.Where(x => x.UserID == userID).FirstOrDefault();

            if (item.Password != null)
            {
                row.Password = item.Password;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            System.Threading.Thread.Sleep(3000);
            return RedirectToAction("Index1", "Home");
        }


        
    }
}