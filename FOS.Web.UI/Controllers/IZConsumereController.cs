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
    public class IZConsumereController : Controller
    {
        // GET: IZConsumere
        [HttpGet]
        public ActionResult AddConsumer()
        {
            IZConsumerData con = new IZConsumerData();
            using (FOSDataModel db = new FOSDataModel())
            {
                con.Blocks = db.Tbl_IZBlocks.Where(x => x.Status == true).ToList();
            }
            return View(con);
        }

        [HttpPost]
        public ActionResult AddConsumer(IZConsumerData data)
        {
            Tbl_IZConsumers con = new Tbl_IZConsumers();
            using (FOSDataModel db = new FOSDataModel())
            {
                if (data.ID == 0)
                {
                    con.RefNo = data.RefNO;
                    con.PlotNo = data.PlotNo;
                    con.BlockID = Convert.ToInt32(data.BlocksID);
                    con.Address = data.Address;
                    con.MemberNO = data.MemberShip;
                    con.AccNO = data.AccNO;
                    con.SubAcco = data.SubAccNo;
                    con.SubHead = data.SubHead;
                    con.Teriff = data.teriff;
                    con.ConnectionType = data.Connectiontype;
                    con.ConnectionDate = data.ConnectionDate;
                    con.OwnerName = data.OwnerName;
                    con.CNIC = data.CNIC;
                    con.PhoneNo = Convert.ToInt32(data.PhoneNO);
                    con.Filer = data.Filer;
                    con.NTN = data.NTN;
                    con.CoOwnerName = data.CoOwnerName;
                    con.CoOwnerCNIC = data.CoOwnerCNIC;
                    con.CoOwnerContact = data.CoOwnerContact;
                    con.PTV = data.PTV;
                    con.Status = true;
                    con.CellNo = data.CellNO;
                    db.Tbl_IZConsumers.Add(con);
                    db.SaveChanges();
                    return Content("1");
                }
                else
                {

                }
            }

            return Content("0");
        }

        public JsonResult ConsumerDataHandler(DTParameters param)
        {
            try
            {
                var dtsource = new List<IZConsumerData>();
                dtsource = ManageCity.GetConsumerForGrid();
                List<String> columnSearch = new List<string>();
                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }
                List<IZConsumerData> data = ManageCity.GetResultConsumer(param.Search.Value, param.SortOrder, param.Start, param.Length, dtsource, columnSearch);
                int count = ManageCity.CountConsumer(param.Search.Value, dtsource, columnSearch);
                DTResult<IZConsumerData> result = new DTResult<IZConsumerData>
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