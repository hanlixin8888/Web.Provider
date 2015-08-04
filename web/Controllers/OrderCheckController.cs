using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Business;
using System.Collections;


namespace MvcAppWeb.Controllers
{
    public class OrderCheckController : Controller
    {
        //
        // GET: /OrderCheck/

        public ActionResult OrderCheck()
        {
            if (Session["UserInfo"] == null) return RedirectToAction("LogOn", "Account");
            else
            {
                VenderUser model = (VenderUser)Session["UserInfo"];
                if (model.VUSERCODE != "system")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }
        }


        public JsonResult Query(string OrderNoOrGoodsCode)
        {
            //int page = int.Parse(Request["page"].ToString());
            //int rows = int.Parse(Request["rows"].ToString());

            OrderGoodsCheck ogc = new OrderGoodsCheck();
             var result = ogc.Query(OrderNoOrGoodsCode);
            
             Dictionary<string, object> json = new Dictionary<string, object>();
             //json.Add("total", total);
             json.Add("rows", result);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public String Updates(string orderlist)
        {
            string[] strorder = orderlist.Split(',');
            OrderGoodsCheck ogc = new OrderGoodsCheck();
            string sjson = string.Empty;
            List<CheckOrderGoods> list=new List<CheckOrderGoods>() ;
            CheckOrderGoods cheeckordergoods;
            for (int i = 0; i < strorder.Length; i++)
            {
                cheeckordergoods = new CheckOrderGoods();
                cheeckordergoods.SHEETID = strorder[i].Split('|')[0];
                cheeckordergoods.GOODSCODE= strorder[i].Split('_')[1] ;
                cheeckordergoods.CHECKNO  =int.Parse(strorder[i].Split('|')[1].Split('_')[0]);
                list.Add(cheeckordergoods);

            }
            //System.Data.Common.DbTransaction dbtrans = new System.Data.Common.DbTransaction();
            try{
               string msg=  ogc.CheckOrderGoods(list);
            if(msg=="保存成功")
             {
                 
                    sjson = "{success:true}";
                }
                else
                {
                    sjson = "{success:false,msg:'保存失败'}";
                }
            }
            catch (Exception ex)
            {
                sjson = "{success:false,msg:" + ex.Message + "}";
            }
            return sjson;

        }

    }
}
