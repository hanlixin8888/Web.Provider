using Business;
using MB.Orm.DB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppWeb.Controllers
{
    public class BaseDataController : Controller
    {
        //
        // GET: /BaseData/

        public ActionResult Index()
        {
            return View();
        }

         /// <summary>
        /// 仓库列表
        /// </summary>
        /// <returns></returns>
        public JsonResult VenderList()
        {
            var retData = new object();
            NewCommon nec = new NewCommon();
           retData = nec.GetVenderList().ToList();
           return Json(retData);
        }
    }
}
