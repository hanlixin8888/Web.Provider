using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Model;
using System.Web.Security;
using MB.Util;

namespace MvcAppWeb.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/


        public ActionResult AddUser()
        {
            if (Session["UserInfo"] == null) return RedirectToAction("LogOn", "Account");
            else
            {
                VenderUser model = (VenderUser)Session["UserInfo"];
                if (model.VUSERCODE != "system")
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View(model);
                }
            }
        }

        [HttpPost]
        public string checkUser()
        {
            string sjson = string.Empty;
            string code = Request["txtUserCode"];

            NewCommon nc = new NewCommon();
            VenderUser checkuser = nc.CheckVenderUser(code);
            if (checkuser != null)
            {
                sjson = "{success:false,msg:'该登录名已存在！'}";
            }
            else
            {
                sjson = "{success:true}";
            }
            return sjson;
        }

        [HttpPost]
        public string Saves()
        {
            string sjson = string.Empty;
            try
            {
                string name = Request["txtUserName"];
                string code = Request["txtUserCode"];
                string pwd1 = Request["txtpassword"];
                string pwd2 = Request["txtpwd"];
                int vid = int.Parse(Request["VENDERID"]);
                if (pwd1.Length < 6 || pwd2.Length < 6)
                {
                    return sjson = "{success:false,msg:'请输入6位的密码'}";
                }
                if (pwd1 != pwd2)
                {
                    return sjson = "{success:false,msg:'两次密码不一致'}";
                }
                VenderUser user = new VenderUser();
                user.VUSERCODE = code;
                user.PASSWORD = pwd1;
                user.VENDERID = vid;
                user.USERNAME = name;

                NewCommon nc = new NewCommon();
                 VenderUser checkuser= nc.CheckVenderUser(code);
                 if (checkuser != null)
                 {
                     sjson = "{success:false,msg:'该登录名已存在！'}";
                 }
                 else
                 {
                     nc.AddVenderUser(user);
                     sjson = "{success:true}";
                 }
            }
            catch (Exception ex)
            {
                sjson = "{success:false,msg:" + ex.Message + "}";
            }
            return sjson;
        }

        public JsonResult Query(string SVENDERID)
        {
            int page = int.Parse(Request["page"].ToString());
            int rows = int.Parse(Request["rows"].ToString());
            int total = 0;
            int n = 0;
            string where = " where 1=1";
            if (!string.IsNullOrEmpty(SVENDERID))
            {
                if (int.TryParse(SVENDERID, out n))
                {
                    if (Convert.ToInt32( SVENDERID) != 0)
                    {
                        where += " and vu.venderid='" + SVENDERID + "'";
                    }
                }
                else
                {
                    where += " and 1=2";
                }
            }
            NewCommon nc = new NewCommon();
            var result = nc.GetVenderUserList(page, rows, out total, where);

            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("total", total);
            json.Add("rows", result);
            return Json(json, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public string Delete(string ids)//s删除用户
        {
            string sjson = string.Empty;
            try
            {
                NewCommon nc = new NewCommon();
                foreach (var id in ids.Split(','))
                {
                    nc.DeleteVenderUser(id);
                }
                sjson = "{success:true}";
            }
            catch (Exception ex)
            {
                sjson = "{success:false,msg:" + ex.Message + "}";
            }
            return sjson;

        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassWord()
        {
            if (Session["UserInfo"] == null) return RedirectToAction("LogOn", "Account");
            else
            {
                VenderUser model = (VenderUser)Session["UserInfo"];
                return View(model);
            }
        }

        [HttpPost]
        public string ChangePwd()//更改密码
        {
            string sjson = string.Empty;
            string pwd = Request["Password"];
            string NewPassword = Request["NewPassword"];
            string NewPasswordCfm = Request["NewPasswordCfm"];
            VenderUser model = (VenderUser)Session["UserInfo"];
            if (EncryptHelper.EncryptDES(pwd) != model.PASSWORD)
            {
                sjson = "{success:false,msg:'旧密码输入不正确！'}";
                return sjson;
            }
            if (NewPassword.Length<6 || NewPasswordCfm.Length<6)
            {
                sjson = "{success:false,msg:'请输入至少6位密码！'}";
                return sjson;
            }
            if (NewPassword != NewPasswordCfm)
            {
                sjson = "{success:false,msg:'两次密码输入不一致！'}";
                return sjson;
            }
            try
            {
                NewCommon nc = new NewCommon();
                nc.ChangePwd(model.VUSERCODE, EncryptHelper.EncryptDES(NewPassword));
                sjson = "{success:true}";
            }
            catch (Exception ex)
            {
                sjson = "{success:false,msg:" + ex.Message + "}";
            }
            return sjson;

        }

    }
}
