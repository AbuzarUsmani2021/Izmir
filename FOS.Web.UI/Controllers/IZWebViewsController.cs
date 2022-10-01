using FOS.DataLayer;
using FOS.Setup;
using FOS.Shared;
using FOS.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOS.Web.UI.Controllers
{
    public class IZWebViewsController : Controller
    {
        // GET: IZWebViews
        [HttpGet]
        public ActionResult Display()
        {
            FOSDataModel db = new FOSDataModel();
            IZHomeData home = new IZHomeData();
            home.Months = db.Tbl_IZBillingPeriod.ToList();
            return View(home);
        }

        [HttpPost]
        public JsonResult Display(DTParameters param, int monthID)
        {
            try
            {
                FOSDataModel db = new FOSDataModel();
                //int monthID = db.Tbl_IZBillingPeriod.Where(x => x.IsActive == true).FirstOrDefault().ID;

                //ViewBag.BlockName = db.Tbl_IZBlocks.Where(x => x.ID == blockID).FirstOrDefault().Name;

                var dtsource = new List<IZHomeData>();
                dtsource = ManageCity.GetDisplaySheetForGrid(monthID);
                List<String> columnSearch = new List<string>();
                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }
                List<IZHomeData> data = ManageCity.GetResultReadingCurrentMonth(param.Search.Value, param.SortOrder, param.Start, param.Length, dtsource, columnSearch);
                int count = ManageCity.CountCurrentMonthReading(param.Search.Value, dtsource, columnSearch);
                DTResult<IZHomeData> result = new DTResult<IZHomeData>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = count,
                    recordsTotal = count
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}