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
                Session["userGroup"] = item.UserGroupID;
              
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
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "000").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "000").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "001").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "001").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "001").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "001").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "001").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "002").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "002").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "002").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "002").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "002").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "003").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "003").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "003").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "003").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "003").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "004").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "004").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "004").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "004").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "004").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "005").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "005").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "005").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "005").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "005").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "006").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "006").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "006").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "006").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "006").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName7 = db.C_Menu.Where(x => x.MenuSeq == "007").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus7 = db.C_Menu.Where(x => x.MenuSeq == "007").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor7 = db.C_Menu.Where(x => x.MenuSeq == "007").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo7 = db.C_Menu.Where(x => x.MenuSeq == "007").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController7 = db.C_Menu.Where(x => x.MenuSeq == "007").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName8 = db.C_Menu.Where(x => x.MenuSeq == "008").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus8 = db.C_Menu.Where(x => x.MenuSeq == "008").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor8 = db.C_Menu.Where(x => x.MenuSeq == "008").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo8 = db.C_Menu.Where(x => x.MenuSeq == "008").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController8 = db.C_Menu.Where(x => x.MenuSeq == "008").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VStatus9 = db.C_Menu.Where(x => x.MenuSeq == "009").Select(x => x.Status).FirstOrDefault();
            ViewBag.VMenuName9 = db.C_Menu.Where(x => x.MenuSeq == "009").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VColor9 = db.C_Menu.Where(x => x.MenuSeq == "009").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo9 = db.C_Menu.Where(x => x.MenuSeq == "009").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController9 = db.C_Menu.Where(x => x.MenuSeq == "009").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VStatus10 = db.C_Menu.Where(x => x.MenuSeq == "010").Select(x => x.Status).FirstOrDefault();
            ViewBag.VMenuName10 = db.C_Menu.Where(x => x.MenuSeq == "010").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VColor10 = db.C_Menu.Where(x => x.MenuSeq == "010").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo10 = db.C_Menu.Where(x => x.MenuSeq == "010").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController10 = db.C_Menu.Where(x => x.MenuSeq == "010").Select(x => x.MenuController).FirstOrDefault();

            return View();

        }

        public ActionResult SMT()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "100").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "100").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "100").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "101" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "101" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "101" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "101" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "101").Select(x => x.MenuController).FirstOrDefault();
            ViewBag.UserGroup1 = Session["userGroup"];
            //ViewBag.VMenuSeq1 = db.C_Menu.Where(x => x.MenuSeq == "101").Select(x => x.MenuSeq).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "102" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "102" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "102" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "102" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "102").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "103" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "103" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "103" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "103" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "103").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "104" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "104" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "104" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "104" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "104").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "105" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "105" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "105" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "105" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "105").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "106" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "106" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "106" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "106" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "106").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName7 = db.C_Menu.Where(x => x.MenuSeq == "107" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus7 = db.C_Menu.Where(x => x.MenuSeq == "107" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor7 = db.C_Menu.Where(x => x.MenuSeq == "107" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo7 = db.C_Menu.Where(x => x.MenuSeq == "107" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController7 = db.C_Menu.Where(x => x.MenuSeq == "107").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName8 = db.C_Menu.Where(x => x.MenuSeq == "108" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus8 = db.C_Menu.Where(x => x.MenuSeq == "108" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor8 = db.C_Menu.Where(x => x.MenuSeq == "108" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo8 = db.C_Menu.Where(x => x.MenuSeq == "108" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController8 = db.C_Menu.Where(x => x.MenuSeq == "108").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName9 = db.C_Menu.Where(x => x.MenuSeq == "109" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus9 = db.C_Menu.Where(x => x.MenuSeq == "109" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor9 = db.C_Menu.Where(x => x.MenuSeq == "109" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo9 = db.C_Menu.Where(x => x.MenuSeq == "109" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController9 = db.C_Menu.Where(x => x.MenuSeq == "109").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName10 = db.C_Menu.Where(x => x.MenuSeq == "110" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus10 = db.C_Menu.Where(x => x.MenuSeq == "110" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor10 = db.C_Menu.Where(x => x.MenuSeq == "110" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo10 = db.C_Menu.Where(x => x.MenuSeq == "110" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController10 = db.C_Menu.Where(x => x.MenuSeq == "110").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName11 = db.C_Menu.Where(x => x.MenuSeq == "111" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus11 = db.C_Menu.Where(x => x.MenuSeq == "111" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor11 = db.C_Menu.Where(x => x.MenuSeq == "111" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo11 = db.C_Menu.Where(x => x.MenuSeq == "111" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController11 = db.C_Menu.Where(x => x.MenuSeq == "111").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName12 = db.C_Menu.Where(x => x.MenuSeq == "112" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus12 = db.C_Menu.Where(x => x.MenuSeq == "112" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor12 = db.C_Menu.Where(x => x.MenuSeq == "112" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo12 = db.C_Menu.Where(x => x.MenuSeq == "112" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController12 = db.C_Menu.Where(x => x.MenuSeq == "112").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName13 = db.C_Menu.Where(x => x.MenuSeq == "113" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus13 = db.C_Menu.Where(x => x.MenuSeq == "113" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor13 = db.C_Menu.Where(x => x.MenuSeq == "113" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo13 = db.C_Menu.Where(x => x.MenuSeq == "113" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController13 = db.C_Menu.Where(x => x.MenuSeq == "113").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName14 = db.C_Menu.Where(x => x.MenuSeq == "114" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus14 = db.C_Menu.Where(x => x.MenuSeq == "114" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor14 = db.C_Menu.Where(x => x.MenuSeq == "114" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo14 = db.C_Menu.Where(x => x.MenuSeq == "114" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController14 = db.C_Menu.Where(x => x.MenuSeq == "114").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName15 = db.C_Menu.Where(x => x.MenuSeq == "115" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus15 = db.C_Menu.Where(x => x.MenuSeq == "115" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor15 = db.C_Menu.Where(x => x.MenuSeq == "115" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo15 = db.C_Menu.Where(x => x.MenuSeq == "115" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController15 = db.C_Menu.Where(x => x.MenuSeq == "115").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName16 = db.C_Menu.Where(x => x.MenuSeq == "116" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus16 = db.C_Menu.Where(x => x.MenuSeq == "116" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor16 = db.C_Menu.Where(x => x.MenuSeq == "116" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo16 = db.C_Menu.Where(x => x.MenuSeq == "116" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController16 = db.C_Menu.Where(x => x.MenuSeq == "116").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName17 = db.C_Menu.Where(x => x.MenuSeq == "117" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus17 = db.C_Menu.Where(x => x.MenuSeq == "117" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor17 = db.C_Menu.Where(x => x.MenuSeq == "117" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo17 = db.C_Menu.Where(x => x.MenuSeq == "117" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController17 = db.C_Menu.Where(x => x.MenuSeq == "117").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName18 = db.C_Menu.Where(x => x.MenuSeq == "118" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus18 = db.C_Menu.Where(x => x.MenuSeq == "118" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor18 = db.C_Menu.Where(x => x.MenuSeq == "118" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo18 = db.C_Menu.Where(x => x.MenuSeq == "118" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController18 = db.C_Menu.Where(x => x.MenuSeq == "118").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName19 = db.C_Menu.Where(x => x.MenuSeq == "119" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus19 = db.C_Menu.Where(x => x.MenuSeq == "119" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor19 = db.C_Menu.Where(x => x.MenuSeq == "119" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo19 = db.C_Menu.Where(x => x.MenuSeq == "119" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController19 = db.C_Menu.Where(x => x.MenuSeq == "119").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName20 = db.C_Menu.Where(x => x.MenuSeq == "120" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus20 = db.C_Menu.Where(x => x.MenuSeq == "120" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor20 = db.C_Menu.Where(x => x.MenuSeq == "120" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo20 = db.C_Menu.Where(x => x.MenuSeq == "120" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController20 = db.C_Menu.Where(x => x.MenuSeq == "120").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName21 = db.C_Menu.Where(x => x.MenuSeq == "121" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus21 = db.C_Menu.Where(x => x.MenuSeq == "121" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor21 = db.C_Menu.Where(x => x.MenuSeq == "121" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo21 = db.C_Menu.Where(x => x.MenuSeq == "121" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController21 = db.C_Menu.Where(x => x.MenuSeq == "121").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName22 = db.C_Menu.Where(x => x.MenuSeq == "122" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus22 = db.C_Menu.Where(x => x.MenuSeq == "122" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor22 = db.C_Menu.Where(x => x.MenuSeq == "122" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo22 = db.C_Menu.Where(x => x.MenuSeq == "122" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController22 = db.C_Menu.Where(x => x.MenuSeq == "122").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName23 = db.C_Menu.Where(x => x.MenuSeq == "123" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus23 = db.C_Menu.Where(x => x.MenuSeq == "123" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor23 = db.C_Menu.Where(x => x.MenuSeq == "123" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo23 = db.C_Menu.Where(x => x.MenuSeq == "123" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController23 = db.C_Menu.Where(x => x.MenuSeq == "123").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName24 = db.C_Menu.Where(x => x.MenuSeq == "124" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus24 = db.C_Menu.Where(x => x.MenuSeq == "124" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor24 = db.C_Menu.Where(x => x.MenuSeq == "124" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo24 = db.C_Menu.Where(x => x.MenuSeq == "124" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController24 = db.C_Menu.Where(x => x.MenuSeq == "124").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName25 = db.C_Menu.Where(x => x.MenuSeq == "125" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus25 = db.C_Menu.Where(x => x.MenuSeq == "125" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor25 = db.C_Menu.Where(x => x.MenuSeq == "125" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo25 = db.C_Menu.Where(x => x.MenuSeq == "125" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController25 = db.C_Menu.Where(x => x.MenuSeq == "125").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName26 = db.C_Menu.Where(x => x.MenuSeq == "126" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus26 = db.C_Menu.Where(x => x.MenuSeq == "126" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor26 = db.C_Menu.Where(x => x.MenuSeq == "126" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo26 = db.C_Menu.Where(x => x.MenuSeq == "126" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController26 = db.C_Menu.Where(x => x.MenuSeq == "126").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName27 = db.C_Menu.Where(x => x.MenuSeq == "127" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus27 = db.C_Menu.Where(x => x.MenuSeq == "127" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor27 = db.C_Menu.Where(x => x.MenuSeq == "127" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo27 = db.C_Menu.Where(x => x.MenuSeq == "127" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController27 = db.C_Menu.Where(x => x.MenuSeq == "127").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName28 = db.C_Menu.Where(x => x.MenuSeq == "128" && x.MenuGroup == "SMT").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus28 = db.C_Menu.Where(x => x.MenuSeq == "128" && x.MenuGroup == "SMT").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor28 = db.C_Menu.Where(x => x.MenuSeq == "128" && x.MenuGroup == "SMT").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo28 = db.C_Menu.Where(x => x.MenuSeq == "128" && x.MenuGroup == "SMT").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController28 = db.C_Menu.Where(x => x.MenuSeq == "128").Select(x => x.MenuController).FirstOrDefault();

            return View();
        }
        
        public ActionResult BackEnd()
        {

            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "200").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "200").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "200").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "202" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "202" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "202" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "202" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "202").Select(x => x.MenuController).FirstOrDefault();


            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "203" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "203" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "203" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "203" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "203").Select(x => x.MenuController).FirstOrDefault();


            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "204" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "204" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "204" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "204" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "204").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "205" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "205" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "205" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "205" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "205").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "206" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "206" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "206" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "206" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "206").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "207" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "207" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "207" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "207" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "207").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName7 = db.C_Menu.Where(x => x.MenuSeq == "208" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus7 = db.C_Menu.Where(x => x.MenuSeq == "208" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor7 = db.C_Menu.Where(x => x.MenuSeq == "208" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo7 = db.C_Menu.Where(x => x.MenuSeq == "208" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController7 = db.C_Menu.Where(x => x.MenuSeq == "208").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName8 = db.C_Menu.Where(x => x.MenuSeq == "209" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus8 = db.C_Menu.Where(x => x.MenuSeq == "209" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor8 = db.C_Menu.Where(x => x.MenuSeq == "209" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo8 = db.C_Menu.Where(x => x.MenuSeq == "209" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController8 = db.C_Menu.Where(x => x.MenuSeq == "209").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName9 = db.C_Menu.Where(x => x.MenuSeq == "210" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus9 = db.C_Menu.Where(x => x.MenuSeq == "210" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor9 = db.C_Menu.Where(x => x.MenuSeq == "210" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo9 = db.C_Menu.Where(x => x.MenuSeq == "210" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController9 = db.C_Menu.Where(x => x.MenuSeq == "210").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName10 = db.C_Menu.Where(x => x.MenuSeq == "211" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus10 = db.C_Menu.Where(x => x.MenuSeq == "211" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor10 = db.C_Menu.Where(x => x.MenuSeq == "211" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo10 = db.C_Menu.Where(x => x.MenuSeq == "211" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController10 = db.C_Menu.Where(x => x.MenuSeq == "211").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName11 = db.C_Menu.Where(x => x.MenuSeq == "212" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus11 = db.C_Menu.Where(x => x.MenuSeq == "212" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor11 = db.C_Menu.Where(x => x.MenuSeq == "212" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo11 = db.C_Menu.Where(x => x.MenuSeq == "212" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController11 = db.C_Menu.Where(x => x.MenuSeq == "212").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName12 = db.C_Menu.Where(x => x.MenuSeq == "213" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus12 = db.C_Menu.Where(x => x.MenuSeq == "213" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor12 = db.C_Menu.Where(x => x.MenuSeq == "213" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo12 = db.C_Menu.Where(x => x.MenuSeq == "213" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController12 = db.C_Menu.Where(x => x.MenuSeq == "213").Select(x => x.MenuController).FirstOrDefault();


            ViewBag.VMenuName13 = db.C_Menu.Where(x => x.MenuSeq == "214" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus13 = db.C_Menu.Where(x => x.MenuSeq == "214" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor13 = db.C_Menu.Where(x => x.MenuSeq == "214" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo13 = db.C_Menu.Where(x => x.MenuSeq == "214" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController13 = db.C_Menu.Where(x => x.MenuSeq == "214").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName14 = db.C_Menu.Where(x => x.MenuSeq == "215" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus14 = db.C_Menu.Where(x => x.MenuSeq == "215" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor14 = db.C_Menu.Where(x => x.MenuSeq == "215" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo14 = db.C_Menu.Where(x => x.MenuSeq == "215" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController14 = db.C_Menu.Where(x => x.MenuSeq == "215").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName15 = db.C_Menu.Where(x => x.MenuSeq == "216" && x.MenuGroup == "BackEnd").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus15 = db.C_Menu.Where(x => x.MenuSeq == "216" && x.MenuGroup == "BackEnd").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor15 = db.C_Menu.Where(x => x.MenuSeq == "216" && x.MenuGroup == "BackEnd").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo15 = db.C_Menu.Where(x => x.MenuSeq == "216" && x.MenuGroup == "BackEnd").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController15 = db.C_Menu.Where(x => x.MenuSeq == "216").Select(x => x.MenuController).FirstOrDefault();
            return View();

        }


        public ActionResult Inventory()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "300").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "300").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "300").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "301" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "301" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "301" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "301" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "301").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "302" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "302" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "302" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "302" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "302").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "303" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "303" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "303" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "303" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "303").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "304" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "304" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "304" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "304" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "304").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "305" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "305" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "305" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "305" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "305").Select(x => x.MenuController).FirstOrDefault();
            
            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "306" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "306" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "306" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "306" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "306").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName7 = db.C_Menu.Where(x => x.MenuSeq == "307" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus7 = db.C_Menu.Where(x => x.MenuSeq == "307" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor7 = db.C_Menu.Where(x => x.MenuSeq == "307" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo7 = db.C_Menu.Where(x => x.MenuSeq == "307" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController7 = db.C_Menu.Where(x => x.MenuSeq == "307").Select(x => x.MenuController).FirstOrDefault();
           

            ViewBag.VMenuName8 = db.C_Menu.Where(x => x.MenuSeq == "308" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus8 = db.C_Menu.Where(x => x.MenuSeq == "308" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor8 = db.C_Menu.Where(x => x.MenuSeq == "308" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo8 = db.C_Menu.Where(x => x.MenuSeq == "308" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController8 = db.C_Menu.Where(x => x.MenuSeq == "308").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName9 = db.C_Menu.Where(x => x.MenuSeq == "309" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus9 = db.C_Menu.Where(x => x.MenuSeq == "309" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor9 = db.C_Menu.Where(x => x.MenuSeq == "309" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo9 = db.C_Menu.Where(x => x.MenuSeq == "309" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController9 = db.C_Menu.Where(x => x.MenuSeq == "309").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName10 = db.C_Menu.Where(x => x.MenuSeq == "310" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus10 = db.C_Menu.Where(x => x.MenuSeq == "310" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor10 = db.C_Menu.Where(x => x.MenuSeq == "310" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo10 = db.C_Menu.Where(x => x.MenuSeq == "310" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController10 = db.C_Menu.Where(x => x.MenuSeq == "310").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName11 = db.C_Menu.Where(x => x.MenuSeq == "311" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus11 = db.C_Menu.Where(x => x.MenuSeq == "311" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor11 = db.C_Menu.Where(x => x.MenuSeq == "311" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo11 = db.C_Menu.Where(x => x.MenuSeq == "311" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController11 = db.C_Menu.Where(x => x.MenuSeq == "311").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName12 = db.C_Menu.Where(x => x.MenuSeq == "312" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus12 = db.C_Menu.Where(x => x.MenuSeq == "312" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor12 = db.C_Menu.Where(x => x.MenuSeq == "312" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo12 = db.C_Menu.Where(x => x.MenuSeq == "312" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController12 = db.C_Menu.Where(x => x.MenuSeq == "312").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName13 = db.C_Menu.Where(x => x.MenuSeq == "313" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus13 = db.C_Menu.Where(x => x.MenuSeq == "313" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor13 = db.C_Menu.Where(x => x.MenuSeq == "313" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo13 = db.C_Menu.Where(x => x.MenuSeq == "313" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController13 = db.C_Menu.Where(x => x.MenuSeq == "313").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName14 = db.C_Menu.Where(x => x.MenuSeq == "314" && x.MenuGroup == "Inventory").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus14 = db.C_Menu.Where(x => x.MenuSeq == "314" && x.MenuGroup == "Inventory").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor14 = db.C_Menu.Where(x => x.MenuSeq == "314" && x.MenuGroup == "Inventory").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo14 = db.C_Menu.Where(x => x.MenuSeq == "314" && x.MenuGroup == "Inventory").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController14 = db.C_Menu.Where(x => x.MenuSeq == "314").Select(x => x.MenuController).FirstOrDefault();
            return View();
        }      


        public ActionResult QAShipping()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "400").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "400").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "400").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "401" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "401" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "401" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "401" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "401").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "402" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "402" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "402" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "402" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "402").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "403" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "403" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "403" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "403" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "403").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "404" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "404" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "404" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "404" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "404").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "405" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "405" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "405" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "405" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "405").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "406" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "406" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "406" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "406" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "406").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName7 = db.C_Menu.Where(x => x.MenuSeq == "407" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus7 = db.C_Menu.Where(x => x.MenuSeq == "407" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor7 = db.C_Menu.Where(x => x.MenuSeq == "407" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo7 = db.C_Menu.Where(x => x.MenuSeq == "407" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController7 = db.C_Menu.Where(x => x.MenuSeq == "407").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName8 = db.C_Menu.Where(x => x.MenuSeq == "408" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus8 = db.C_Menu.Where(x => x.MenuSeq == "408" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor8 = db.C_Menu.Where(x => x.MenuSeq == "408" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo8 = db.C_Menu.Where(x => x.MenuSeq == "408" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController8 = db.C_Menu.Where(x => x.MenuSeq == "408").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName9 = db.C_Menu.Where(x => x.MenuSeq == "409" && x.MenuGroup == "QAShipping").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus9 = db.C_Menu.Where(x => x.MenuSeq == "409" && x.MenuGroup == "QAShipping").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor9 = db.C_Menu.Where(x => x.MenuSeq == "409" && x.MenuGroup == "QAShipping").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo9 = db.C_Menu.Where(x => x.MenuSeq == "409" && x.MenuGroup == "QAShipping").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController9 = db.C_Menu.Where(x => x.MenuSeq == "409").Select(x => x.MenuController).FirstOrDefault();

            return View();
        }


        public ActionResult Maintenance()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "500").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "500").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "500").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "501" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "501" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "501" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "501" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "501").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "502" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "502" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "502" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "502" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "502").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "503" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "503" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "503" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "503" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "503").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "504" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "504" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "504" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "504" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "504").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "505" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "505" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "505" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "505" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "505").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "506" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "506" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "506" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "506" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "506").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName7 = db.C_Menu.Where(x => x.MenuSeq == "507" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus7 = db.C_Menu.Where(x => x.MenuSeq == "507" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor7 = db.C_Menu.Where(x => x.MenuSeq == "507" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo7 = db.C_Menu.Where(x => x.MenuSeq == "507" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController7 = db.C_Menu.Where(x => x.MenuSeq == "507").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName8 = db.C_Menu.Where(x => x.MenuSeq == "508" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus8 = db.C_Menu.Where(x => x.MenuSeq == "508" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor8 = db.C_Menu.Where(x => x.MenuSeq == "508" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo8 = db.C_Menu.Where(x => x.MenuSeq == "508" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController8 = db.C_Menu.Where(x => x.MenuSeq == "508").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName9 = db.C_Menu.Where(x => x.MenuSeq == "509" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus9 = db.C_Menu.Where(x => x.MenuSeq == "509" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor9 = db.C_Menu.Where(x => x.MenuSeq == "509" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo9 = db.C_Menu.Where(x => x.MenuSeq == "509" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController9 = db.C_Menu.Where(x => x.MenuSeq == "509").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName10 = db.C_Menu.Where(x => x.MenuSeq == "510" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus10 = db.C_Menu.Where(x => x.MenuSeq == "510" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor10 = db.C_Menu.Where(x => x.MenuSeq == "510" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo10 = db.C_Menu.Where(x => x.MenuSeq == "510" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController10 = db.C_Menu.Where(x => x.MenuSeq == "510").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName11 = db.C_Menu.Where(x => x.MenuSeq == "511" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus11 = db.C_Menu.Where(x => x.MenuSeq == "511" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor11 = db.C_Menu.Where(x => x.MenuSeq == "511" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo11 = db.C_Menu.Where(x => x.MenuSeq == "511" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController11 = db.C_Menu.Where(x => x.MenuSeq == "511").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName12 = db.C_Menu.Where(x => x.MenuSeq == "512" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus12 = db.C_Menu.Where(x => x.MenuSeq == "512" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor12 = db.C_Menu.Where(x => x.MenuSeq == "512" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo12 = db.C_Menu.Where(x => x.MenuSeq == "512" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController12 = db.C_Menu.Where(x => x.MenuSeq == "512").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName13 = db.C_Menu.Where(x => x.MenuSeq == "513" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus13 = db.C_Menu.Where(x => x.MenuSeq == "513" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor13 = db.C_Menu.Where(x => x.MenuSeq == "513" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo13 = db.C_Menu.Where(x => x.MenuSeq == "513" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController13 = db.C_Menu.Where(x => x.MenuSeq == "513").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName14 = db.C_Menu.Where(x => x.MenuSeq == "514" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus14 = db.C_Menu.Where(x => x.MenuSeq == "514" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor14 = db.C_Menu.Where(x => x.MenuSeq == "514" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo14 = db.C_Menu.Where(x => x.MenuSeq == "514" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController14 = db.C_Menu.Where(x => x.MenuSeq == "514").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName15 = db.C_Menu.Where(x => x.MenuSeq == "515" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus15 = db.C_Menu.Where(x => x.MenuSeq == "515" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor15 = db.C_Menu.Where(x => x.MenuSeq == "515" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo15 = db.C_Menu.Where(x => x.MenuSeq == "515" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController15 = db.C_Menu.Where(x => x.MenuSeq == "515").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName16 = db.C_Menu.Where(x => x.MenuSeq == "516" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus16 = db.C_Menu.Where(x => x.MenuSeq == "516" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor16 = db.C_Menu.Where(x => x.MenuSeq == "516" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo16 = db.C_Menu.Where(x => x.MenuSeq == "516" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController16 = db.C_Menu.Where(x => x.MenuSeq == "516").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName17 = db.C_Menu.Where(x => x.MenuSeq == "517" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus17 = db.C_Menu.Where(x => x.MenuSeq == "517" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor17 = db.C_Menu.Where(x => x.MenuSeq == "517" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo17 = db.C_Menu.Where(x => x.MenuSeq == "517" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController17 = db.C_Menu.Where(x => x.MenuSeq == "517").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName18 = db.C_Menu.Where(x => x.MenuSeq == "518" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus18 = db.C_Menu.Where(x => x.MenuSeq == "518" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor18 = db.C_Menu.Where(x => x.MenuSeq == "518" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo18 = db.C_Menu.Where(x => x.MenuSeq == "518" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController18 = db.C_Menu.Where(x => x.MenuSeq == "518").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName19 = db.C_Menu.Where(x => x.MenuSeq == "519" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus19 = db.C_Menu.Where(x => x.MenuSeq == "519" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor19 = db.C_Menu.Where(x => x.MenuSeq == "519" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo19 = db.C_Menu.Where(x => x.MenuSeq == "519" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController19 = db.C_Menu.Where(x => x.MenuSeq == "519").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName20 = db.C_Menu.Where(x => x.MenuSeq == "520" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus20 = db.C_Menu.Where(x => x.MenuSeq == "520" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor20 = db.C_Menu.Where(x => x.MenuSeq == "520" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo20 = db.C_Menu.Where(x => x.MenuSeq == "520" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController20 = db.C_Menu.Where(x => x.MenuSeq == "520").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName21 = db.C_Menu.Where(x => x.MenuSeq == "521" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus21 = db.C_Menu.Where(x => x.MenuSeq == "521" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor21 = db.C_Menu.Where(x => x.MenuSeq == "521" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo21 = db.C_Menu.Where(x => x.MenuSeq == "521" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController21 = db.C_Menu.Where(x => x.MenuSeq == "521").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName22 = db.C_Menu.Where(x => x.MenuSeq == "522" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus22 = db.C_Menu.Where(x => x.MenuSeq == "522" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor22 = db.C_Menu.Where(x => x.MenuSeq == "522" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo22 = db.C_Menu.Where(x => x.MenuSeq == "522" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController22 = db.C_Menu.Where(x => x.MenuSeq == "522").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName23 = db.C_Menu.Where(x => x.MenuSeq == "555" && x.MenuGroup == "Maintenance").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus23 = db.C_Menu.Where(x => x.MenuSeq == "555" && x.MenuGroup == "Maintenance").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor23 = db.C_Menu.Where(x => x.MenuSeq == "555" && x.MenuGroup == "Maintenance").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo23 = db.C_Menu.Where(x => x.MenuSeq == "555" && x.MenuGroup == "Maintenance").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController23 = db.C_Menu.Where(x => x.MenuSeq == "555").Select(x => x.MenuController).FirstOrDefault();

            return View();
        }

        public ActionResult Administrative()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "600").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "600").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "600").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "601" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "601" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "601" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "601" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "601").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "602" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "602" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "602" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "602" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "602").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "603" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "603" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "603" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "603" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "603").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "604" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "604" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "604" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "604" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "604").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "605" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "605" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "605" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "605" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "605").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "606" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "606" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "606" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "606" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "606").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName7 = db.C_Menu.Where(x => x.MenuSeq == "607" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus7 = db.C_Menu.Where(x => x.MenuSeq == "607" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor7 = db.C_Menu.Where(x => x.MenuSeq == "607" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo7 = db.C_Menu.Where(x => x.MenuSeq == "607" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController7 = db.C_Menu.Where(x => x.MenuSeq == "607").Select(x => x.MenuController).FirstOrDefault();
            ViewBag.UserGroup7 = Session["userGroup"];

            ViewBag.VMenuName8 = db.C_Menu.Where(x => x.MenuSeq == "608" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus8 = db.C_Menu.Where(x => x.MenuSeq == "608" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor8 = db.C_Menu.Where(x => x.MenuSeq == "608" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo8 = db.C_Menu.Where(x => x.MenuSeq == "608" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController8 = db.C_Menu.Where(x => x.MenuSeq == "608").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName9 = db.C_Menu.Where(x => x.MenuSeq == "609" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus9 = db.C_Menu.Where(x => x.MenuSeq == "609" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor9 = db.C_Menu.Where(x => x.MenuSeq == "609" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo9 = db.C_Menu.Where(x => x.MenuSeq == "609" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController9 = db.C_Menu.Where(x => x.MenuSeq == "609").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName10 = db.C_Menu.Where(x => x.MenuSeq == "610" && x.MenuGroup == "Administrative").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus10 = db.C_Menu.Where(x => x.MenuSeq == "610" && x.MenuGroup == "Administrative").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor10 = db.C_Menu.Where(x => x.MenuSeq == "610" && x.MenuGroup == "Administrative").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo10 = db.C_Menu.Where(x => x.MenuSeq == "610" && x.MenuGroup == "Administrative").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController10 = db.C_Menu.Where(x => x.MenuSeq == "610").Select(x => x.MenuController).FirstOrDefault();
            return View();
        }


        public ActionResult Dashboard()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "700").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "700").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "700").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "701" && x.MenuGroup == "Dashboard").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "701" && x.MenuGroup == "Dashboard").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "701" && x.MenuGroup == "Dashboard").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "701" && x.MenuGroup == "Dashboard").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "701").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "702" && x.MenuGroup == "Dashboard").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "702" && x.MenuGroup == "Dashboard").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "702" && x.MenuGroup == "Dashboard").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "702" && x.MenuGroup == "Dashboard").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "702").Select(x => x.MenuController).FirstOrDefault();

            return View();
        }

        public ActionResult Inquiry()
        {
            ViewBag.VMainMenu = db.C_Menu.Where(x => x.MenuSeq == "800").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VMainMenuPic = db.C_Menu.Where(x => x.MenuSeq == "800").Select(x => x.MenuPic).FirstOrDefault();
            ViewBag.VStatus = db.C_Menu.Where(x => x.MenuSeq == "800").Select(x => x.Status).FirstOrDefault();

            ViewBag.VMenuName1 = db.C_Menu.Where(x => x.MenuSeq == "801" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus1 = db.C_Menu.Where(x => x.MenuSeq == "801" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor1 = db.C_Menu.Where(x => x.MenuSeq == "801" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo1 = db.C_Menu.Where(x => x.MenuSeq == "801" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController1 = db.C_Menu.Where(x => x.MenuSeq == "801").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName2 = db.C_Menu.Where(x => x.MenuSeq == "802" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus2 = db.C_Menu.Where(x => x.MenuSeq == "802" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor2 = db.C_Menu.Where(x => x.MenuSeq == "802" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo2 = db.C_Menu.Where(x => x.MenuSeq == "802" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController2 = db.C_Menu.Where(x => x.MenuSeq == "802").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName3 = db.C_Menu.Where(x => x.MenuSeq == "803" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus3 = db.C_Menu.Where(x => x.MenuSeq == "803" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor3 = db.C_Menu.Where(x => x.MenuSeq == "803" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo3 = db.C_Menu.Where(x => x.MenuSeq == "803" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController3 = db.C_Menu.Where(x => x.MenuSeq == "803").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName4 = db.C_Menu.Where(x => x.MenuSeq == "804" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus4 = db.C_Menu.Where(x => x.MenuSeq == "804" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor4 = db.C_Menu.Where(x => x.MenuSeq == "804" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo4 = db.C_Menu.Where(x => x.MenuSeq == "804" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController4 = db.C_Menu.Where(x => x.MenuSeq == "804").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName5 = db.C_Menu.Where(x => x.MenuSeq == "805" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus5 = db.C_Menu.Where(x => x.MenuSeq == "805" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor5 = db.C_Menu.Where(x => x.MenuSeq == "805" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo5 = db.C_Menu.Where(x => x.MenuSeq == "805" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController5 = db.C_Menu.Where(x => x.MenuSeq == "805").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName6 = db.C_Menu.Where(x => x.MenuSeq == "806" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus6 = db.C_Menu.Where(x => x.MenuSeq == "806" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor6 = db.C_Menu.Where(x => x.MenuSeq == "806" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo6 = db.C_Menu.Where(x => x.MenuSeq == "806" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController6 = db.C_Menu.Where(x => x.MenuSeq == "806").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName7 = db.C_Menu.Where(x => x.MenuSeq == "807" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus7 = db.C_Menu.Where(x => x.MenuSeq == "807" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor7 = db.C_Menu.Where(x => x.MenuSeq == "807" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo7 = db.C_Menu.Where(x => x.MenuSeq == "807" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController7 = db.C_Menu.Where(x => x.MenuSeq == "807").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName8 = db.C_Menu.Where(x => x.MenuSeq == "808" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus8 = db.C_Menu.Where(x => x.MenuSeq == "808" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor8 = db.C_Menu.Where(x => x.MenuSeq == "808" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo8 = db.C_Menu.Where(x => x.MenuSeq == "808" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController8 = db.C_Menu.Where(x => x.MenuSeq == "808").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName9 = db.C_Menu.Where(x => x.MenuSeq == "809" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus9 = db.C_Menu.Where(x => x.MenuSeq == "809" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor9 = db.C_Menu.Where(x => x.MenuSeq == "809" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo9 = db.C_Menu.Where(x => x.MenuSeq == "809" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController9 = db.C_Menu.Where(x => x.MenuSeq == "809").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName10 = db.C_Menu.Where(x => x.MenuSeq == "810" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus10 = db.C_Menu.Where(x => x.MenuSeq == "810" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor10 = db.C_Menu.Where(x => x.MenuSeq == "810" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo10 = db.C_Menu.Where(x => x.MenuSeq == "810" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController10 = db.C_Menu.Where(x => x.MenuSeq == "810").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName11 = db.C_Menu.Where(x => x.MenuSeq == "811" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus11 = db.C_Menu.Where(x => x.MenuSeq == "811" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor11 = db.C_Menu.Where(x => x.MenuSeq == "811" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo11 = db.C_Menu.Where(x => x.MenuSeq == "811" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController11 = db.C_Menu.Where(x => x.MenuSeq == "811").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName12 = db.C_Menu.Where(x => x.MenuSeq == "812" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus12 = db.C_Menu.Where(x => x.MenuSeq == "812" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor12 = db.C_Menu.Where(x => x.MenuSeq == "812" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo12 = db.C_Menu.Where(x => x.MenuSeq == "812" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController12 = db.C_Menu.Where(x => x.MenuSeq == "812").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName13 = db.C_Menu.Where(x => x.MenuSeq == "813" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus13 = db.C_Menu.Where(x => x.MenuSeq == "813" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor13 = db.C_Menu.Where(x => x.MenuSeq == "813" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo13 = db.C_Menu.Where(x => x.MenuSeq == "813" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController13 = db.C_Menu.Where(x => x.MenuSeq == "813").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName14 = db.C_Menu.Where(x => x.MenuSeq == "814" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus14 = db.C_Menu.Where(x => x.MenuSeq == "814" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor14 = db.C_Menu.Where(x => x.MenuSeq == "814" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo14 = db.C_Menu.Where(x => x.MenuSeq == "814" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController14 = db.C_Menu.Where(x => x.MenuSeq == "814").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName15 = db.C_Menu.Where(x => x.MenuSeq == "815" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus15 = db.C_Menu.Where(x => x.MenuSeq == "815" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor15 = db.C_Menu.Where(x => x.MenuSeq == "815" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo15 = db.C_Menu.Where(x => x.MenuSeq == "815" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController15 = db.C_Menu.Where(x => x.MenuSeq == "815").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName16 = db.C_Menu.Where(x => x.MenuSeq == "816" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus16 = db.C_Menu.Where(x => x.MenuSeq == "816" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor16 = db.C_Menu.Where(x => x.MenuSeq == "816" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo16 = db.C_Menu.Where(x => x.MenuSeq == "816" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController16 = db.C_Menu.Where(x => x.MenuSeq == "816").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName17 = db.C_Menu.Where(x => x.MenuSeq == "817" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus17 = db.C_Menu.Where(x => x.MenuSeq == "817" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor17 = db.C_Menu.Where(x => x.MenuSeq == "817" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo17 = db.C_Menu.Where(x => x.MenuSeq == "817" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController17 = db.C_Menu.Where(x => x.MenuSeq == "817").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName18 = db.C_Menu.Where(x => x.MenuSeq == "818" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus18 = db.C_Menu.Where(x => x.MenuSeq == "818" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor18 = db.C_Menu.Where(x => x.MenuSeq == "818" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo18 = db.C_Menu.Where(x => x.MenuSeq == "818" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController18 = db.C_Menu.Where(x => x.MenuSeq == "818").Select(x => x.MenuController).FirstOrDefault();

            ViewBag.VMenuName19 = db.C_Menu.Where(x => x.MenuSeq == "819" && x.MenuGroup == "Inquiry").Select(x => x.MenuName).FirstOrDefault();
            ViewBag.VStatus19 = db.C_Menu.Where(x => x.MenuSeq == "819" && x.MenuGroup == "Inquiry").Select(x => x.Status).FirstOrDefault();
            ViewBag.VColor19 = db.C_Menu.Where(x => x.MenuSeq == "819" && x.MenuGroup == "Inquiry").Select(x => x.IconBckgrdColor).FirstOrDefault();
            ViewBag.VLogo19 = db.C_Menu.Where(x => x.MenuSeq == "819" && x.MenuGroup == "Inquiry").Select(x => x.IconLogo).FirstOrDefault();
            ViewBag.VMenuController19 = db.C_Menu.Where(x => x.MenuSeq == "819").Select(x => x.MenuController).FirstOrDefault();

            return View();
        }

        public ActionResult About()
        {
            var item = db.M_SystemControl.Where(x => x.ControlType == "About").FirstOrDefault();
            ViewBag.Message = "Company Address - CEO office Suites";
            ViewBag.AboutValue = item.ControlValue;

            ViewBag.VLogo = db.M_SystemControl.Where(x => x.ControlType == "Logo").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VApplication = db.M_SystemControl.Where(x => x.ControlType == "Application").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCopyRight = db.M_SystemControl.Where(x => x.ControlType == "CopyRight").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCompanyDesc = db.M_SystemControl.Where(x => x.ControlType == "CompanyDesc").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VSponsor = db.M_SystemControl.Where(x => x.ControlType == "SponsoredComp").Select(x => x.ControlValue).FirstOrDefault();

            return View();
        }

        public ActionResult Contact()
        {
            var item = db.M_SystemControl.Where(x => x.ControlType == "Contact").FirstOrDefault();
            ViewBag.Message = "Contact Information";
            ViewBag.AboutContact = item.ControlValue;

            ViewBag.VLogo = db.M_SystemControl.Where(x => x.ControlType == "Logo").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VApplication = db.M_SystemControl.Where(x => x.ControlType == "Application").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCopyRight = db.M_SystemControl.Where(x => x.ControlType == "CopyRight").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VCompanyDesc = db.M_SystemControl.Where(x => x.ControlType == "CompanyDesc").Select(x => x.ControlValue).FirstOrDefault();
            ViewBag.VSponsor = db.M_SystemControl.Where(x => x.ControlType == "SponsoredComp").Select(x => x.ControlValue).FirstOrDefault();

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


        public string GetMenuPgm()
        {            
            string result = "";

            var MenuMain = db.C_Menu.Where(x => x.MenuGroup == "Main" && x.MenuSeq != "000" && x.Status == "Active");

            foreach (var main in MenuMain)
            {
                var MenuChild1 = db.C_Menu.Where(x => x.MenuGroup == main.MenuName && x.MenuSeq != "100" && x.MenuSeq != "200" && x.MenuSeq != "300" && x.MenuSeq != "400" && x.MenuSeq != "500" && x.MenuSeq != "600" && x.Status == "Active");

                result += "<li class=\"dropdown\">";
                result += "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + main.MenuName + "<span class=\"caret\"></span></a>";
                result += "<ul class=\"dropdown-menu\" role=\"menu\">";                
              
                foreach (var item in MenuChild1)
                {
                    result += "<li><a href=\"" + item.MenuController + "\">" + item.MenuName + "</a></li>";
                }

                result += "</ul>";
                result += "</li>";
                 
            }

            return result;
            
        }
        
    }
}