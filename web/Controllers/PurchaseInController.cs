using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcAppWeb.Controllers
{
    public class PurchaseInController : Controller
    {

        public ActionResult PurchaseInMain()//主表
        {
            if (Session["UserInfo"] == null) return RedirectToAction("LogOn", "Account");
            else
            {
                VenderUser model = (VenderUser)Session["UserInfo"];
                return View(model);
            }
        }

        /// <summary>
        /// 查询主表
        /// </summary> 
        public JsonResult QueryMain(string OrderNoOrGoodsCode, DateTime CheckTimeS, DateTime CheckTimeE)
        {
            int page = int.Parse(Request["page"].ToString());
            int rows = int.Parse(Request["rows"].ToString());
            int total = 0;
            VenderUser model = (VenderUser)Session["UserInfo"];
            string where = "  rt.flag in(20 ,40,90,100)";// and rt.venderid=" + model.VENDERID;
            //管理员测试数据放开
            if (model.VUSERCODE != "system")
            {
                where += " and rt.venderid=" + model.VENDERID;
            }
            if (!string.IsNullOrEmpty(OrderNoOrGoodsCode))
            {
                where += " and rt.sheetid='" + OrderNoOrGoodsCode + "'";
            }
            if (CheckTimeS != null)
            {
                where += " and rt.EditDate> to_date('" + CheckTimeS + "','yyyy-mm-dd hh24:mi:ss')";
            }
            if (CheckTimeE != null)
            {
                where += " and rt.EditDate< to_date('" + CheckTimeE + "','yyyy-mm-dd hh24:mi:ss')";
            }
            BPurchaseIn ogc = new BPurchaseIn();
            var result = ogc.GetPurchaseInMain(page, rows, out total, where);

            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("total", total);
            json.Add("rows", result);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult QueryDetailData(string sheetid)
        {

            BPurchaseIn ogc = new BPurchaseIn();
            var result = ogc.GetPurchaseInDetail(sheetid);

            Dictionary<string, object> json = new Dictionary<string, object>();
            //json.Add("total", total);
            json.Add("rows", result);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 采购进货明显
        /// </summary>
        /// <returns></returns>
        public ActionResult PurchaseIn()
        {
            if (Session["UserInfo"] == null) return RedirectToAction("LogOn", "Account");
            else
            {
                VenderUser model = (VenderUser)Session["UserInfo"];
                return View(model);
            } 
        }
         
        /// <summary>
        /// 查询主从明细
        /// </summary> 
        public JsonResult Query(string OrderNoOrGoodsCode, string GoodsCode, string GoodsName, DateTime CheckTimeS, DateTime CheckTimeE)
        {
            int page = int.Parse(Request["page"].ToString());
            int rows = int.Parse(Request["rows"].ToString());
            int total = 0;
            VenderUser model = (VenderUser)Session["UserInfo"];
            string where = "  rt.flag in(20 ,40,90,100)";// and rt.venderid=" + model.VENDERID;
            //管理员测试数据放开
            if (model.VUSERCODE != "system")
            {
                where += " and rt.venderid=" + model.VENDERID;
            }
            if (!string.IsNullOrEmpty(OrderNoOrGoodsCode))
            {
                where += " and rt.sheetid='" + OrderNoOrGoodsCode + "'";
            }
            if (!string.IsNullOrEmpty(GoodsCode))
                where += " and gd.goodscode='" + GoodsCode + "'";
            if (!string.IsNullOrEmpty(GoodsName))
            {
                where += " and gd.goodsname='" + GoodsName + "'";
            }
            if (CheckTimeS != null)
            {
                where += " and rt.EditDate> to_date('" + CheckTimeS + "','yyyy-mm-dd hh24:mi:ss')";
            }
            if (CheckTimeE != null)
            {
                where += " and rt.EditDate< to_date('" + CheckTimeE + "','yyyy-mm-dd hh24:mi:ss')";
            }
            BPurchaseIn ogc = new BPurchaseIn();
            var result = ogc.GetPurchaseInList(page, rows, out total, where);

            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("total", total);
            json.Add("rows", result);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public FileResult ExportExcel(int page,int rows)//导出execl
        {
            //int page = int.Parse(Request["page"].ToString());
            //int rows = int.Parse(Request["rows"].ToString());
            int total = 0;

            string OrderNoOrGoodsCode = Request["txtOrdSubjectCode"];
            string GoodsCode = Request["GoodsCode"];
            string GoodsName = Request["txtGoodsName"];
            DateTime CheckTimeS = Convert.ToDateTime(Request["CheckTimeS"]);
            DateTime CheckTimeE = Convert.ToDateTime(Request["CheckTimeE"]);
            VenderUser model = (VenderUser)Session["UserInfo"];

            string where = " rt.flag in(20 ,40,90,100) ";//and  rt.venderid=" + model.VENDERID;
            //管理员测试数据放开
            if (model.USERNAME != "system")
            {
                where += " and rt.venderid=" + model.VENDERID;
            }
            if (!string.IsNullOrEmpty(OrderNoOrGoodsCode))
            {
                where += " and rt.sheetid='" + OrderNoOrGoodsCode + "'";
            }
            if (!string.IsNullOrEmpty(GoodsCode))
            {
                where += " and gd.goodscode='" + GoodsCode + "'";
            }
            if (!string.IsNullOrEmpty(GoodsName))
            {
                where += " and gd.goodsname='" + GoodsName + "'";
            }
            if (CheckTimeS != null)
            {
                where += " and rt.EditDate> to_date('" + CheckTimeS + "','yyyy-mm-dd hh24:mi:ss')";
            }
            if (CheckTimeE != null)
            {
                where += " and rt.EditDate< to_date('" + CheckTimeE + "','yyyy-mm-dd hh24:mi:ss')";
            }
            BPurchaseIn ogc = new BPurchaseIn();
            List<PurchaseIn> list = ogc.GetPurchaseInList(page, rows, out total, where);




            var sbHtml = new StringBuilder();
            sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            sbHtml.Append("<tr>");
            var lstTitle = new List<string> { "采购进货单号", "仓位名称","商品编码", "商品名称", "规格", "单位", "包装层次", "包装单位", "包装数量", "包装整件数", 
                        "零数","通知数量", "收货数量", "整件单价","单价", "金额", "订单状态","下单时间", "制单人", "供应商", "备注" };
            foreach (var item in lstTitle)
            {
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", item);
            }
            sbHtml.Append("</tr>");

            for (int i = 0; i < list.Count(); i++)
            {
                sbHtml.Append("<tr>");
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].SheetID);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].WarehouseName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].GoodsCode);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].GoodsName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].GoodsSpec);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].UnitName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].PkgClassName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].PkgUnitName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].PkgNumber);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].PkgQty);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].BulkQty);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].NotifyQty);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].Qty);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].PkgCost);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].Cost);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].CostValue);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", FormatFlag(list[i].Flag));
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].CheckDate);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].Editor);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].VenderName);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", list[i].Remark);
                sbHtml.Append("</tr>");
            }
            sbHtml.Append("</table>");

            //第一种:使用FileContentResult
            byte[] fileContents = Encoding.Default.GetBytes(sbHtml.ToString());
            return File(fileContents, "application/ms-excel", "fileContents.xls");

            ////第二种:使用FileStreamResult
            //var fileStream = new MemoryStream(fileContents);
            //return File(fileStream, "application/ms-excel", "fileStream.xls");

            ////第三种:使用FilePathResult
            ////服务器上首先必须要有这个Excel文件,然会通过Server.MapPath获取路径返回.
            //var fileName = Server.MapPath("~/Files/fileName.xls");
            //return File(fileName, "application/ms-excel", "fileName.xls");
        }

        private string FormatFlag(int flag)
        {
            string str = string.Empty;
            if (flag == 20)
            {
                str = "待处理";
            }
            if (flag == 40)
            {
                str = "在执行";
            }
            if (flag == 100)
            {
                str = "完结";
            }
            if (flag == 90)
            {
                str = "已审核";
            }
            return str;
        }


    }
}
