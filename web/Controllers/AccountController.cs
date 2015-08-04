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
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //BfUserInfo userInfo = NewErpCommonAgent.Instance.LogOn(model.UserName, model.Password);
                    NewCommon nec = new NewCommon();
                    VenderUser userInfo = nec.LogOn(model.UserName, model.Password);
                    if (userInfo.ErrorMsg != null && userInfo.ErrorMsg.Length > 0)
                    {
                        ModelState.AddModelError("错误", userInfo.ErrorMsg);
                        return View(model);
                    }
                    else
                    {
                        Session.Add("UserInfo", userInfo);
                        Session.Timeout = 720;
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    MB.Util.TraceEx.Write(ex.Message);

                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
            
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            if (Session["UserInfo"] != null) Session.Remove("UserInfo");
            return Json("success");
        }

        public ActionResult AddUser()
        {
            try
            {
                if (Session["UserInfo"] == null)
                {
                    return RedirectToAction("LogOn", "Account");
                }
                else
                {
                    VenderUser model = (VenderUser)Session["UserInfo"];
                    return View(model);
                }
            }
            catch 
            {                
                return View();
            }
        }

        //public JsonResult Query(string VenderCode)
        //{
        //    //int page = int.Parse(Request["page"].ToString());
        //    //int rows = int.Parse(Request["rows"].ToString());

        //    OrderGoodsCheck ogc = new OrderGoodsCheck();
        //    var result = ogc.Query(VenderCode);

        //    Dictionary<string, object> json = new Dictionary<string, object>();
        //    //json.Add("total", total);
        //    json.Add("rows", result);
        //    return Json(json, JsonRequestBehavior.AllowGet);
        //}

    }
}
