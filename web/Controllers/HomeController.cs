using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MvcAppWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["UserInfo"] == null) return RedirectToAction("LogOn", "Account");
            else
            {
                VenderUser model = (VenderUser)Session["UserInfo"];
                if (model.VUSERCODE == "system")
                {
                    ViewData["NInSCI"] = "nodisp";
                }
                else
                {
                    ViewData["NInSCI"] = "disp";
                }
                return View(model);
            }
        }

    }
}
