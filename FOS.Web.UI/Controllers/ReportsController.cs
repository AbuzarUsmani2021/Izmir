﻿using FOS.Setup;
using FOS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOS.DataLayer;
using FluentValidation.Results;
using FOS.Web.UI.Models;
using FOS.Web.UI.Common.CustomAttributes;


using FOS.Web.UI.DataSets;
using CrystalDecisions.CrystalReports.Engine;
using Shared.Diagnostics.Logging;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Reporting.WebForms;
using FOS.Web.UI.Controllers.API;

namespace FOS.Web.UI.Controllers
{
    public class ReportsController : Controller
    { FOSDataModel db = new FOSDataModel();

        #region FOS Wise Date/Month Wise Intake Delivered Report-1A
        [HttpGet]
        public ActionResult FosDateWiseReport()
        {
            ReportsInputData obj = new ReportsInputData();
            ManagePainter objPainter = new ManagePainter();
            obj.Territories = objPainter.GetTerritoryNamesList();
            obj.FosNames = objPainter.getFosLov(0).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
            var customer = objPainter.GetCityList(1);
            obj.PainterCityNames = customer;
            return View(obj);
        }
        #endregion

        #region FOS Wise Date/Month Wise Intake Report
        [HttpGet]
        public ActionResult FosDateMonthWiseIntakeReport()
        {
            ReportsInputData obj = new ReportsInputData();
            ManagePainter objPainter = new ManagePainter();
            obj.Territories = objPainter.GetTerritoryNamesList();
            obj.FosNames = objPainter.getFosLov(0).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
            var customer = objPainter.GetCityList(1);
            obj.PainterCityNames = customer;
            return View(obj);
        }
        #endregion

        #region City Wise Date Wise Intake Delivered Report
        [HttpGet]
        public ActionResult CityDateWiseRetailerReport()
        {
            ReportsInputData obj = new ReportsInputData();
            ManagePainter objPainter = new ManagePainter();
            obj.Territories = objPainter.GetTerritoryNamesList();
            obj.FosNames = objPainter.getFosLov(0).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
            var customer = objPainter.GetCityList(1);
            obj.PainterCityNames = customer;
            return View(obj);
        }
        #endregion

        #region City Wise Month Wise Intake Delivered Report
        [HttpGet]
        public ActionResult CityDateMonthWiseIntakeReport()
        {
            ReportsInputData obj = new ReportsInputData();
            ManagePainter objPainter = new ManagePainter();
            obj.Territories = objPainter.GetTerritoryNamesList();
            obj.FosNames = objPainter.getFosLov(0).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
            var customer = objPainter.GetCityList(1);
            obj.PainterCityNames = customer;
            return View(obj);
        }
        #endregion

        #region Retail Shop Wise Date Wise Intake Delivered Report
        [HttpGet]
        public ActionResult RetailerShopDateWiseReport()
        {
            ReportsInputData obj = new ReportsInputData();
            ManagePainter objPainter = new ManagePainter();
            obj.Territories = objPainter.GetTerritoryNamesList();
            obj.FosNames = objPainter.getFosLov(0).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
            var customer = objPainter.GetAllCitiesList();
            obj.PainterCityNames = customer;
            return View(obj);
        }
        #endregion

        #region Retail Shop Wise Month Wise Intake Delivered Report
        [HttpGet]
        public ActionResult RetailerShopDateMonthWiseIntakeReport()
        {
            ReportsInputData obj = new ReportsInputData();
            ManagePainter objPainter = new ManagePainter();
            obj.Territories = objPainter.GetTerritoryNamesList();
            obj.FosNames = objPainter.getFosLov(0).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
            var customer = objPainter.GetAllCitiesList();
            obj.PainterCityNames = customer;
            return View(obj);
        }
        #endregion



        #region City Fos Wise Report
        [HttpGet]
        public ActionResult CityWiseFosReport()
        {
            ReportsInputData obj = new ReportsInputData();
            ManagePainter objPainter = new ManagePainter();
            obj.Territories = objPainter.GetTerritoryNamesList();
            obj.FosNames = objPainter.getFosLov(0).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
            var customer = objPainter.GetAllCitiesList();
            obj.PainterCityNames = customer;
            return View(obj);
        }
        #endregion

        #region City Market Retailer Wise Report
        public ActionResult CityMktRtlrWiseReport()
        {
            ReportsInputData obj = new ReportsInputData();
            ManagePainter objPainter = new ManagePainter();
            obj.Territories = objPainter.GetTerritoryNamesList();
            obj.FosNames = objPainter.getFosLov(0).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
            var customer = objPainter.GetAllCitiesList();
            obj.PainterCityNames = customer;
            return View(obj);
        }
        #endregion

        #region Helping Methods
        public JsonResult getData(string cities)
        {
            string[] mul = cities.Split(',');
            return null;
        }
        public ActionResult getCities(string TID)
        {
            int tid = 0;
            if (!string.IsNullOrEmpty(TID))
            {
                tid = Convert.ToInt32(TID);
            }
            ManagePainter objPainter = new ManagePainter();
            string Reponse = "";
            using (FOSDataModel dbContext = new FOSDataModel())
            {
                var customer = objPainter.GetCityList(tid).OrderBy(x => x.CityName);
                foreach (var p in customer)
                {
                    Reponse += @"<div class='span3 scroll' style='margin:0px;margin-left: 0px;'><input " + ((p.Selected == false) ? "" : "checked") + " id='painter" + p.ID + "' data-id='" + p.ID + "' class='pCheckBox' name='painter[]' onchange='painterSelected(this)' type='checkbox' style='margin: -1px 0 0;'><span class='lbl' style='font-size: 11px;margin-left: 5px;color: #000000;'>" + p.CityName + "</span><p style='font-size:9px;' id='cityName'>" + p.CityName + "</p></div>";
                }

            }

            return Json(new { Response = Reponse });
        }

        public ActionResult getShops(string CID)
        {
            int tid = 0;
            if (!string.IsNullOrEmpty(CID))
            {
                tid = Convert.ToInt32(CID);
            }
            ManagePainter objPainter = new ManagePainter();
            string Reponse = "";
            using (FOSDataModel dbContext = new FOSDataModel())
            {
                var customer = objPainter.GetShopsList(tid).OrderBy(x => x.CityName);
                foreach (var p in customer)
                {
                    Reponse += @"<div class='span3 scroll' style='margin:0px;margin-left: 0px;'><input " + ((p.Selected == false) ? "" : "checked") + " id='painter" + p.ID + "' data-id='" + p.ID + "' class='pCheckBox' name='painter[]' onchange='painterSelected(this)' type='checkbox' style='margin: -1px 0 0;'><span class='lbl' style='font-size: 11px;margin-left: 5px;color: #000000;'>" + p.CityName + "</span><p style='font-size:9px;' id='cityName'>" + p.CityName + "</p></div>";
                }

            }

            return Json(new { Response = Reponse });
        }

        public ActionResult getAreas(string CID)
        {
            int tid = 0;
            if (!string.IsNullOrEmpty(CID))
            {
                tid = Convert.ToInt32(CID);
            }
            ManagePainter objPainter = new ManagePainter();
            string Reponse = "";
            using (FOSDataModel dbContext = new FOSDataModel())
            {
                var customer = objPainter.GetAreaList(tid).OrderBy(x => x.CityName);
                foreach (var p in customer)
                {
                    Reponse += @"<div class='span3 scroll' style='margin:0px;margin-left: 0px;'><input " + ((p.Selected == false) ? "" : "checked") + " id='painter" + p.ID + "' data-id='" + p.ID + "' class='pCheckBox' name='painter[]' onchange='painterSelected(this)' type='checkbox' style='margin: -1px 0 0;'><span class='lbl' style='font-size: 11px;margin-left: 5px;color: #000000;'>" + p.CityName + "</span><p style='font-size:9px;' id='cityName'>" + p.CityName + "</p></div>";
                }

            }

            return Json(new { Response = Reponse });
        }

        public ActionResult getMarkets(string CID)
        {
            int tid = 0;
            if (!string.IsNullOrEmpty(CID))
            {
                tid = Convert.ToInt32(CID);
            }
            ManagePainter objPainter = new ManagePainter();
            string Reponse = "";
            using (FOSDataModel dbContext = new FOSDataModel())
            {
                var customer = objPainter.GetMarketList(tid).OrderBy(x => x.CityName);
                foreach (var p in customer)
                {
                    Reponse += @"<div class='span3 scroll' style='margin:0px;margin-left: 0px;'><input " + ((p.Selected == false) ? "" : "checked") + " id='painter" + p.ID + "' data-id='" + p.ID + "' class='pCheckBox' name='painter[]' onchange='painterSelected(this)' type='checkbox' style='margin: -1px 0 0;'><span class='lbl' style='font-size: 11px;margin-left: 5px;color: #000000;'>" + p.CityName + "</span><p style='font-size:9px;' id='cityName'>" + p.CityName + "</p></div>";
                }

            }

            return Json(new { Response = Reponse });
        }

        public ActionResult getFosNames(string TID)
        {
            int tid = 0;
            if (!string.IsNullOrEmpty(TID))
            {
                tid = Convert.ToInt32(TID);
            }
            ManagePainter objPainter = new ManagePainter();
            var customers = objPainter.getFosLov(tid).OrderBy(x => x.Name);
            var customer = objPainter.getFosLov(tid).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID
            });
            return Json(customer);
        }

        public ActionResult getCitiess(string TID)
        {
            int tid = 0;
            if (!string.IsNullOrEmpty(TID))
            {
                tid = Convert.ToInt32(TID);
            }
            ManagePainter objPainter = new ManagePainter();
            var customer = objPainter.GetCityList(tid).OrderBy(x => x.CityName);


            return Json(customer);
        }
        #endregion


        public ActionResult ComplaintsReport()
        {
            var Complaintdata = new KSBComplaintData();

            Complaintdata.Projects = FOS.Setup.ManageCity.GetProjectsListForReport();
            Complaintdata.Cities = FOS.Setup.ManageCity.GetCityListForReport();
            Complaintdata.Areas = FOS.Setup.ManageCity.GetAreaListForReport();
            Complaintdata.SubDivisions = FOS.Setup.ManageCity.GetSubdivisionsListForReport();
            Complaintdata.Sites = FOS.Setup.ManageCity.GetSitesListForReport();
            Complaintdata.faultTypes = FOS.Setup.ManageCity.GetFaultTypesListForReport();
            Complaintdata.complaintStatuses = FOS.Setup.ManageCity.GetComplaintStatusListForReport();
            Complaintdata.WorkDone = FOS.Setup.ManageCity.GetWorkDoneListForReport();
            Complaintdata.LaunchedBy = FOS.Setup.ManageCity.GetLaunchedByListforReport();
            Complaintdata.FieldOfficers = FOS.Setup.ManageCity.GetFieldOfficerListForReport();

            return View(Complaintdata);
        }

     
        public JsonResult GetTownFromZone(string ClientID)
        {
            var result = "ht";  /*FOS.Setup.ManageCity.GetProgressDetailListForReport(ClientID, "--Select Progress Status--")*/
            return Json(result);
        }


        public void ComplaintSummaryrpt(int ProjectID, int CityID, int FaulttypeID, int StatusID, int WorkDoneID, int SaleOfficerID,int FieldOfficerID, string sdate, string edate)
        {


            try
            {
                List<MyComplaintList> list = new List<MyComplaintList>();
                MyComplaintList comlist;
                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(sdate) ? DateTime.Now.ToString() : sdate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(edate) ? DateTime.Now.ToString() : edate);
                DateTime final = end.AddDays(1);
                ManageRetailer objRetailers = new ManageRetailer();
                var result = db.Sp_GetComplaintSummary(start, final, ProjectID, CityID, FaulttypeID, StatusID, SaleOfficerID, FieldOfficerID).ToList();
                foreach (var items in result)
                {
                    comlist = new MyComplaintList();


                    
                    comlist.SiteCode = items.SiteCode;
                    comlist.LaunchDate = (DateTime) items.ComplaintlaunchedAt;
                    comlist.SaleOfficerName = items.AssignedSaleofficerName;
                    comlist.SiteCode = items.SiteCode;
                    comlist.SiteName = items.SiteName;
                    comlist.TicketNo = items.ticketno;
                    comlist.LaunchedByName = items.LaunchedByName;
                    comlist.ComplaintStatus = items.ComplaintStatusName;
                    comlist.FaultType = items.FaultTypeName;
                    comlist.FaultTypeDetail = items.FaultTypeDetailName;
                    comlist.FaultTypeDetailOther = items.faultTypeDetailRemarks;
                    comlist.ComplaintType = items.ComplaintTypeName;
                    comlist.Zone = items.Zone;
                    comlist.Project = items.Project;
                    comlist.WorkDoneStatus = items.WorkDoneStatus;
                    comlist.ProgressStatusName = items.ProgressStatusName;
                    comlist.ProgressStatusOtherName = items.ProgressStatusOtherRemarks;
                    comlist.ProgressRemarks = items.PRemarks;
                    comlist.LastDate = (DateTime)items.UpdatedAT;

                    var format = (DateTime) items.UpdatedAT - (DateTime)items.ComplaintlaunchedAt;
                    var totalhours = string.Format("{0:#,##0}:{1:mm}", Math.Truncate(format.TotalHours), format);
                    //var totalElapsedHours = format.TotalHours();
                    comlist.TimeElapse = totalhours;

                    list.Add(comlist);
                }



                // Example data
            

                // sw.WriteLine("\"SR No\",\"ComplaintDate\",\"Complaint No\",\"SiteID\",\"SiteName\",\"Project\",\"Zone\",\"FaultType\",\"Fault Type Detail\",\"Fault Type Detail Other Remarks\",\"Complaint Type\",\"Launched By\",\"Launch At\",\"Updated At\",\"Elapse Time\",\"Complaint Status\",\"Progress Status\",\"Updated Remarks\",\"Work Done\"");

                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"SR No\",\"ComplaintDate\",\"Complaint No\",\"SiteID\",\"SiteName\",\"Project\",\"Zone\",\"FaultType\",\"Fault Type Detail\",\"Fault Type Detail Other Remarks\",\"Complaint Type\",\"Launched By\",\"Launch At\",\"Updated At\",\"Elapse Time\",\"Complaint Status\",\"Progress Status\",\"Updated Remarks\",\"Work Done\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=ComplaintSummary" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();

                int srNo = 1;
                foreach (var retailer in list)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\"",
                    srNo,
                    retailer.LaunchDate,
                    // retailer.Name,
                    retailer.TicketNo,
                    retailer.SiteCode,
                    retailer.SiteName,
                    retailer.Project,
                    retailer.Zone,
                    retailer.FaultType,
                    retailer.FaultTypeDetail,
                    retailer.FaultTypeDetailOther,
                    retailer.ComplaintType,
                     retailer.LaunchedByName,
                      retailer.LaunchDate,
                       retailer.LastDate,
                        retailer.ElapseTime,
                         retailer.ComplaintStatus,
                          retailer.ProgressStatusName,
                           retailer.ProgressRemarks,
                           retailer.WorkDoneStatus,
                    srNo++


                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");

            }

        }


        public ActionResult ComplaintDetailReport()
        {
            var Complaintdata = new KSBComplaintData();

            Complaintdata.Projects = FOS.Setup.ManageCity.GetProjectsListForReport();
            Complaintdata.Cities = FOS.Setup.ManageCity.GetCityListForReport();
            Complaintdata.faultTypes = FOS.Setup.ManageCity.GetFaultTypesListForReport();
            Complaintdata.complaintStatuses = FOS.Setup.ManageCity.GetComplaintStatusListForReport();
            Complaintdata.WorkDone = FOS.Setup.ManageCity.GetWorkDoneListForReport();
            //Complaintdata.SaleOfficers = FOS.Setup.ManageCity.GetSOListForReport();
            Complaintdata.FieldOfficers = FOS.Setup.ManageCity.GetFieldOfficerListForReport();

            return View(Complaintdata);
        }


        public void ComplaintDetailrpt(int ProjectID, int CityID, int FaulttypeID, int StatusID, int WorkDoneID, int SaleOfficerID, int FieldOfficerID, string sdate, string edate)
        {


            try
            {
           
                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(sdate) ? DateTime.Now.ToString() : sdate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(edate) ? DateTime.Now.ToString() : edate);
                DateTime final = end.AddDays(1);
                ManageRetailer objRetailers = new ManageRetailer();
                var result = db.Sp_GetComplaintDetail(start, final, ProjectID, CityID, FaulttypeID, StatusID, SaleOfficerID, FieldOfficerID).ToList();
              



                // Example data


                // sw.WriteLine("\"SR No\",\"ComplaintDate\",\"Complaint No\",\"SiteID\",\"SiteName\",\"Project\",\"Zone\",\"FaultType\",\"Fault Type Detail\",\"Fault Type Detail Other Remarks\",\"Complaint Type\",\"Launched By\",\"Launch At\",\"Updated At\",\"Elapse Time\",\"Complaint Status\",\"Progress Status\",\"Updated Remarks\",\"Work Done\"");

                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"SR No\",\"ComplaintDate\",\"Complaint No\",\"SiteID\",\"SiteName\",\"Project\",\"Zone\",\"FaultType\",\"Fault Type Detail\",\"Fault Type Detail Other Remarks\",\"Complaint Type\",\"Launched By\",\"Launch At\",\"Updated At\",\"Complaint Status\",\"Progress Status\",\"Updated Remarks\",\"Work Done\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=ComplaintDetail" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();

                int srNo = 1;
                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\"",
                    srNo,
                    retailer.ComplaintlaunchedAt,
                    // retailer.Name,
                    retailer.ticketno,
                    retailer.SiteCode,
                    retailer.SiteName,
                    retailer.Project,
                    retailer.Zone,
                    retailer.FaultTypeName,
                    retailer.FaultTypeDetailName,
                    retailer.faultTypeDetailRemarks,
                    retailer.ComplaintTypeName,
                     retailer.LaunchedByName,
                      retailer.ComplaintlaunchedAt,
                       retailer.UpdatedAT,
                         retailer.ComplaintStatusName,
                          retailer.ProgressStatusName,
                           retailer.PRemarks,
                           retailer.WorkDoneStatus,
                    srNo++


                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");

            }

        }

        public ActionResult FOSPlanning()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);


            return View(objJob);
        }

        public ActionResult FOSPlanningReport(string StartingDate, string EndingDate, int TID, int fosid)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp_FosPlanning_Result> result = objRetailers.FOSPlanningReport(start, end, TID, fosid);
                rptDataSet obj = new rptDataSet();
                DataRow dtrow;
                DataTable dtNewTable;
                dtNewTable = new DataTable();
                DataColumn dcol51 = new DataColumn("Teritory Head", typeof(System.String));
                dtNewTable.Columns.Add(dcol51);
                DataColumn dcol5 = new DataColumn("SaleOfficerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol5);
                DataColumn dcol2 = new DataColumn("DealerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol2);
                DataColumn dcol4 = new DataColumn("CityName", typeof(System.String));
                dtNewTable.Columns.Add(dcol4);
                DataColumn dcol7 = new DataColumn("ShopName", typeof(System.String));
                dtNewTable.Columns.Add(dcol7);
                DataColumn dcol6 = new DataColumn("JobDate", typeof(System.String));
                dtNewTable.Columns.Add(dcol6);

                foreach (var item in result)
                {

                    dtrow = dtNewTable.NewRow();
                    dtrow[0] = item.Name;
                    dtrow[1] = item.SaleOfficerName;
                    dtrow[2] = item.DealerName;
                    dtrow[3] = item.CityName;
                    dtrow[4] = item.ShopName;
                    dtrow[5] = item.JobDate;

                    dtNewTable.Rows.Add(dtrow);

                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/FOSPlanning.rpt")));
                rd.SetDataSource(dtNewTable);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                string type = "xls";
                if (type == "pdf")
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "FOSPlanning.pdf");
                }
                else
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/ms-excel", string.Format("FOSPlanning{0}.xls", DateTime.Now.ToShortDateString()));
                }

                return View();
            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                return null;
            }

        }

        public ActionResult RetailerInfo()
        {
            List<RegionData> regionalHeadData = new List<RegionData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetRegionalList();
            int regId = 0;
            if (FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser() == 0)
            {
                regId = regionalHeadData.Select(r => r.ID).FirstOrDefault();
            }
            else
            {
                regId = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            }

            List<SaleOfficerData> SaleOfficerObj = ManageSaleOffice.GetSaleOfficerListByRegionalHeadID(regId);
            var objSaleOff = SaleOfficerObj.FirstOrDefault();

            List<DealerData> DealerObj = ManageDealer.GetAllDealersListRelatedToRegionalHead(regId);

            var objRetailer = new RetailerData();
            objRetailer.Client = regionalHeadData;
            objRetailer.SaleOfficers = SaleOfficerObj;
            objRetailer.Dealers = DealerObj;
            objRetailer.Cities = FOS.Setup.ManageCity.GetCityList();
            objRetailer.Areas = FOS.Setup.ManageArea.GetAreaList();



            return View(objRetailer);
        }

        public void RetailerInformation(int TID, int fosid, int cityid, int areaid ,DateTime sdate, DateTime edate)
        {


            try
            {

                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp_SiteInformationSummary_Result> result = objRetailers.RetailerInfo(TID, fosid, cityid,areaid,sdate,edate);

                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"Site Name\",\"Site Code\",\"Site Address\",\"Capacity\",\"Client\",\"Project\",\"Zone\",\"Town\",\"Sub Division\",\"Contact Number\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=Sites" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();

                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\"",

                    retailer.SiteName,
                    // retailer.Name,
                    retailer.SiteCode,
                    retailer.SiteAddress,
                    retailer.Capacity,
                    retailer.Client,
                    retailer.Project,
                    retailer.Zone,
                    retailer.Town,
                    retailer.SubDivision,
                    retailer.Phone



                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");

            }

        }

        public ActionResult ShopVisitSummery()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);

            return View(objJob);
        }

        public ActionResult ShopVisitSummeryy(string StartingDate, string EndingDate, int TID, int fosid, int dealerid, int cityid)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp__TotalShopVisitSummeryReport_Result> result = objRetailers.ShopVisitSummery(start, end, TID, fosid, dealerid, cityid);
                rptDataSet obj = new rptDataSet();
                DataRow dtrow;
                DataTable dtNewTable;
                dtNewTable = new DataTable();
                DataColumn dcol51 = new DataColumn("Teritory Head", typeof(System.String));
                dtNewTable.Columns.Add(dcol51);
                DataColumn dcol5 = new DataColumn("SaleOfficerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol5);
                DataColumn dcol3 = new DataColumn("DealerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol3);
                DataColumn dcol0 = new DataColumn("CItyName", typeof(System.String));
                dtNewTable.Columns.Add(dcol0);
                DataColumn dcol01 = new DataColumn("Zone", typeof(System.String));
                dtNewTable.Columns.Add(dcol01);
                DataColumn dcol2 = new DataColumn("TotalJobs", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol2);
                DataColumn dcol4 = new DataColumn("ShopVisited", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol4);
                DataColumn dcol7 = new DataColumn("ShopMissed", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol7);
                DataColumn dcol6 = new DataColumn("Order1kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol6);
                DataColumn dcol65 = new DataColumn("Order5kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol65);
                DataColumn dcol66 = new DataColumn("TotalOrders", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol66);
                DataColumn dcol67 = new DataColumn("Delievered1kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol67);
                DataColumn dcol68 = new DataColumn("Delievered5kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol68);
                DataColumn dcol69 = new DataColumn("TotalDelievered", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol69);


                foreach (var item in result)
                {

                    dtrow = dtNewTable.NewRow();
                    dtrow[0] = item.Name;
                    dtrow[1] = item.SaleOfficerName;
                    dtrow[2] = item.DealerName;
                    dtrow[3] = (item.CityName);
                    dtrow[4] = (item.Zone);
                    dtrow[5] = item.TotalJobs;
                    dtrow[6] = item.Done;
                    dtrow[7] = item.Pending;
                    dtrow[8] = item.Order1KG;
                    dtrow[9] = item.Order5kg;
                    dtrow[10] = item.TotalOrder;
                    dtrow[11] = item.Delevired1Kg;
                    dtrow[12] = item.Delievered5kg;
                    dtrow[13] = item.TotalDelievered;
                    dtNewTable.Rows.Add(dtrow);

                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/ShopVisit_Summary.rpt")));
                rd.SetDataSource(dtNewTable);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                string type = "xls";
                if (type == "pdf")
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "VisitSummary.pdf");
                }
                else
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/ms-excel", string.Format("VisitSummary{0}.xls", DateTime.Now.ToShortDateString()));
                }

                return View();
            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                return null;
            }

        }


        public ActionResult DealerInfo()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);


            return View(objJob);
        }

        public void DealerInformation(int TID, int fosid, int cityid)
        {


            try
            {

                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp_DealerInformationSummery1_1_Result> result = objRetailers.DealerInfo(TID, fosid, cityid);

                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"Region Name\",\"Shop Name\",\"Customer Name\",\"City Name\",\"Address\",\"Phone1\",\"Phone2\",\"CNIC\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=Distributors" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();

                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"",

                    retailer.Name,
                    // retailer.Name,
                    retailer.ShopSchoolName,

                    retailer.PrincipleName,
                    retailer.City,
                    retailer.Address,
                    retailer.Contact1,
                    retailer.Contact2,
                    retailer.CNIC
                    // retailer.CustomerType



                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");

            }

        }








        public ActionResult ShopVisitSummeryOneLine()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);

            return View(objJob);
        }

        public void ShopVisitSummeryOneLiner(string StartingDate, string EndingDate, int TID, int fosid)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                DateTime final = end.AddDays(1);
                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp_DealersOrderDetail_Result> result = objRetailers.ShopVisitSummeryOneLine(start, final, TID, fosid);
                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"OrderID\",\"Zone\",\"RegionalHead Name\",\"Sales Officer Name\",\"Distributor Name\",\"Item Name\",\"Item Quantity(CTN)\",\"Item Price\",\"City Name\",\"Visited Date\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=DistributorOrders" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();

                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\"",
                    retailer.OrderID,
                    retailer.Zone,
                    // retailer.Name,
                    retailer.RegionalHeadName,
                    retailer.SaleOfficerName,
                    retailer.DistributorName,
                    retailer.ItemName,
                    retailer.Quantity,
                    retailer.Price,
                    retailer.CityName,
                    retailer.VisitDate

                    // retailer.CustomerType



                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                // return null;
            }

        }





        public ActionResult RetailerOrdersDetail()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);

            return View(objJob);
        }
  
       

        public void RetailerOrders(string StartingDate, string EndingDate, int TID, int fosid)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                DateTime final = end.AddDays(1);
                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp_RetailersOrderDetailFinal1_2_Result> result = objRetailers.RetailerVisitSummeryOneLine(start, final, TID, fosid);
                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"OrderID\",\"Zone\",\"RegionalHead Name\",\"Sales Officer Name\",\"Retailer Name\",\"Item Name\",\"Quantity (IN PCS)\",\"Item Price\",\"City Name\",\"Visited Date\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=RetailerOrder" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();

                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\"",

                    retailer.OrderID,
                    retailer.Zone,
                    // retailer.Name,
                    retailer.RegionalHeadName,
                    retailer.SaleOfficerName,
                    retailer.RetailerName,
                    retailer.ItemName,
                    retailer.QuantityPcs,
                    retailer.Price,
                    retailer.CityName,
                    retailer.VisitDate

                    // retailer.CustomerType



                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                // return null;
            }

        }

       
        public ActionResult VisitInformationRpt()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);

            return View(objJob);
        }
        public void FollowUpReason(int fosid, string StartingDate, string EndingDate)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                DateTime final = end.AddDays(1);
                ManageRetailer objRetailers = new ManageRetailer();
                List<sp_getFollowUpReason_Result> result = objRetailers.GetFollowUpVisits(fosid, start, final);
                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"OrderID\",\"Zone\",\"RegionalHead Name\",\"Sales Officer Name\",\"Retailer Name\",\"Item Name\",\"Quantity (IN PCS)\",\"Item Price\",\"City Name\",\"Visited Date\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=RetailerOrder" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();

                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\"",

                    retailer.SalesOfficer,
                    retailer.RegionalHead,
                        // retailer.Name,
                    retailer.ShopName,
                    retailer.FollowUpReason,
                    retailer.Remarks,
                    retailer.CreatedOn

                    // retailer.CustomerType



                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                // return null;
            }

        }


        public ActionResult StockTakingDetail()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);

            return View(objJob);
        }

        public void Stocktakingorderdetails(string StartingDate, string EndingDate, int TID, int fosid)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                //  DateTime Startfinal = start.AddDays(-1);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                DateTime final = end.AddDays(1);
                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp_StockTakingDetailReport_Result> result = objRetailers.Stocktaking(start, final, TID, fosid);
                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"StockID\",\"RegionalHead Name\",\"Sales Officer Name\",\"Distributor Name\",\"Item Name\",\"Quantity (IN CTN)\",\"City Name\",\"Stock Taking Date\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=StockTaking" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();

                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"",

                    retailer.StockID,

                    retailer.RegionalHeadName,
                    retailer.SaleOfficerName,
                    retailer.DistributorName,
                    retailer.ItemName,
                    retailer.Quantity,
                    retailer.CityName,
                    retailer.StockTakingTime



                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                // return null;
            }

        }










        public ActionResult ShopVisitDetail()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);

            return View(objJob);
        }

        public ActionResult ShopVisitDetaill(string StartingDate, string EndingDate, int TID, int fosid, int dealerid, int cityid)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp__TotalShopVisitDetail_Result> Result = objRetailers.ShopVisitDetail(start, end, TID, fosid, dealerid, cityid);

                rptDataSet obj = new rptDataSet();
                DataRow dtrow;
                DataTable dtNewTable;
                dtNewTable = new DataTable();
                DataColumn dcol5 = new DataColumn("SaleOfficerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol5);
                DataColumn dcol3 = new DataColumn("DealerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol3);
                DataColumn dcol0 = new DataColumn("CItyName", typeof(System.String));
                dtNewTable.Columns.Add(dcol0);
                DataColumn dcol2 = new DataColumn("ShopName", typeof(System.String));
                dtNewTable.Columns.Add(dcol2);
                DataColumn dcol4 = new DataColumn("JobDate", typeof(System.String));
                dtNewTable.Columns.Add(dcol4);
                DataColumn dcol7 = new DataColumn("Order1kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol7);
                DataColumn dcol6 = new DataColumn("Order5kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol6);
                DataColumn dcol65 = new DataColumn("Delievered1kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol65);
                DataColumn dcol66 = new DataColumn("Delievered5kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol66);



                foreach (var item in Result)
                {

                    dtrow = dtNewTable.NewRow();
                    dtrow[0] = item.SaleOfficerName;
                    dtrow[1] = item.DealerName;
                    dtrow[2] = (item.CityName);
                    dtrow[3] = item.ShopName;
                    dtrow[4] = item.JobDate;
                    dtrow[5] = item.Order1kg;
                    dtrow[6] = item.Order5kg;
                    dtrow[7] = item.Delevired1Kg;
                    dtrow[8] = item.Delievered5kg;

                    dtNewTable.Rows.Add(dtrow);

                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/ShopVisit_Detail.rpt")));
                rd.SetDataSource(dtNewTable);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                string type = "xls";
                if (type == "pdf")
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "ShopVisit_Detail.pdf");
                }
                else
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/ms-excel", string.Format("ShopVisit_Detail{0}.xls", DateTime.Now.ToShortDateString()));
                }

                return View();
            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                return null;
            }

        }




        public ActionResult MarketInfo()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);

            return View(objJob);
        }

        public ActionResult PresentSOReport()
        {
            //  var objRetailer = new RetailerData();
            //objRetailer.Regions = FOS.Setup.ManageCity.GetRegionList();

            List<RegionData> objRegion = new List<RegionData>();
            objRegion = FOS.Setup.ManageRegion.GetRegionList();
            objRegion.Insert(0, new RegionData
            {
                ID = 0,
                Name = "All"
            });
            var objRetailer = new RetailerData();
            objRetailer.Regions = objRegion;

            return View(objRetailer);
        }


        public void TodayPresentSO(string StartingDate, string EndingDate, int TID)
        {
            try
            {
                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                DateTime final = end.AddDays(1);
                ManageRetailer objRetailers = new ManageRetailer();
                List<spGetSalesOfficerWithLoginDate_Result> result = objRetailers.TodayPresentSalesOfficer(TID, start, final);
                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"SrNo.\",\"Sales Officer Name\",\"Regional Head\",\"Region\",\"Login Date\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=TodayPresentSO" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //   var retailers = ManageRetailer.GetRetailersForExportinExcel();
                int srNo = 1;
                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                    srNo,
                    retailer.SalesOfficer,
                    retailer.RegionalHead,
                    retailer.Region,
                    retailer.LoginDate,
                    srNo++


                    ));
                }
                Response.Write(sw.ToString());
                Response.End();

            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                // return null;
            }

        }

        public ActionResult MarketInformation(string StartingDate, string EndingDate, int TID, int fosid, int dealerid)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                ManageRetailer objRetailers = new ManageRetailer();
                List<sp_MarketInformation_Result> Result = objRetailers.MarketInfo(start, end, TID, fosid, dealerid);

                rptDataSet obj = new rptDataSet();
                DataRow dtrow;
                DataTable dtNewTable;
                dtNewTable = new DataTable();
                DataColumn dcol5 = new DataColumn("SaleOfficerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol5);
                DataColumn dcol3 = new DataColumn("DealerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol3);
                DataColumn dcol0 = new DataColumn("ShopName", typeof(System.String));
                dtNewTable.Columns.Add(dcol0);
                DataColumn dcol06 = new DataColumn("JobDate", typeof(System.DateTime));
                dtNewTable.Columns.Add(dcol06);
                DataColumn dcol2 = new DataColumn("Available", typeof(System.String));
                dtNewTable.Columns.Add(dcol2);
                DataColumn dcol4 = new DataColumn("Available1kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol4);
                DataColumn dcol7 = new DataColumn("Available5kg", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol7);
                DataColumn dcol6 = new DataColumn("PSO Material", typeof(System.String));
                dtNewTable.Columns.Add(dcol6);
                DataColumn dcol65 = new DataColumn("UBL Account Opened", typeof(System.String));
                dtNewTable.Columns.Add(dcol65);
                DataColumn dcol66 = new DataColumn("Broucher Avaiabe", typeof(System.String));
                dtNewTable.Columns.Add(dcol66);
                DataColumn dcol67 = new DataColumn("SMS Card Avaiable", typeof(System.String));
                dtNewTable.Columns.Add(dcol67);
                DataColumn dcol68 = new DataColumn("Shade Car Avaiable", typeof(System.String));
                dtNewTable.Columns.Add(dcol68);
                DataColumn dcol69 = new DataColumn("Display", typeof(System.String));
                dtNewTable.Columns.Add(dcol69);
                DataColumn dcol70 = new DataColumn("White 40 KG Avaiable", typeof(System.String));
                dtNewTable.Columns.Add(dcol70);
                DataColumn dcol71 = new DataColumn("Note", typeof(System.String));
                dtNewTable.Columns.Add(dcol71);
                foreach (var item in Result)
                {

                    dtrow = dtNewTable.NewRow();
                    dtrow[0] = item.SaleOfficerName;
                    dtrow[1] = item.DealerName;
                    dtrow[2] = (item.ShopName);
                    dtrow[3] = item.JobDate;
                    dtrow[4] = item.Available;
                    dtrow[5] = item.Available1kg;
                    dtrow[6] = item.Available5kg;
                    dtrow[7] = item.PSOMaterial;
                    dtrow[8] = item.UBLAccountOpened;
                    dtrow[9] = item.BroucherAvaiabe;
                    dtrow[10] = item.SmsCardAvailable;
                    dtrow[11] = item.ShadeCardAvailable;
                    dtrow[12] = item.Display;
                    dtrow[13] = item.White40KgAvailable;
                    dtrow[14] = item.Note;

                    dtNewTable.Rows.Add(dtrow);

                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/MarketInformation.rpt")));
                rd.SetDataSource(dtNewTable);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                string type = "xls";
                if (type == "pdf")
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "MarketInformation.pdf");
                }
                else
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/ms-excel", string.Format("MarketInformation{0}.xls", DateTime.Now.ToShortDateString()));
                }

                return View();
            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                return null;
            }

        }


        public ActionResult CityRetailerWiseReport()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<CityData> cities = new List<CityData>();
            cities = FOS.Setup.ManageRegionalHead.GetCities();
            cities.Insert(0, new CityData
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();
            RetailerObj.Insert(0, new RetailerData
            {
                ID = 0,
                Name = "All"
            });
            var objJob = new JobsData();
            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.Retailers = RetailerObj;
            objJob.Cities = cities;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");

            return View(objJob);
        }

        public ActionResult CityRetailerWiseReportExtract(int cityid, int retailerid)
        {
            try
            {

                DateTime start = DateTime.Now;
                //DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp_CityMarketRetailerInfo_Result> Result = objRetailers.CityMarketRetailerInfo(start, cityid, retailerid);

                rptDataSet obj = new rptDataSet();
                DataRow dtrow;
                DataTable dtNewTable;
                dtNewTable = new DataTable();
                DataColumn dcol5 = new DataColumn("City", typeof(System.String));
                dtNewTable.Columns.Add(dcol5);
                DataColumn dcol3 = new DataColumn("Area", typeof(System.String));
                dtNewTable.Columns.Add(dcol3);
                DataColumn dcol0 = new DataColumn("ShopName", typeof(System.String));
                dtNewTable.Columns.Add(dcol0);
                DataColumn dcol06 = new DataColumn("Category", typeof(System.String));
                dtNewTable.Columns.Add(dcol06);
                DataColumn dcol2 = new DataColumn("Previous ", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol2);
                DataColumn dcol4 = new DataColumn("Current", typeof(System.Int32));
                dtNewTable.Columns.Add(dcol4);
                DataColumn dcol7 = new DataColumn("Average", typeof(System.Decimal));
                dtNewTable.Columns.Add(dcol7);

                foreach (var item in Result)
                {

                    dtrow = dtNewTable.NewRow();
                    dtrow[0] = item.City;
                    dtrow[1] = item.Area;
                    dtrow[2] = (item.ShopName);
                    dtrow[3] = item.Category;
                    dtrow[4] = item.Previous;
                    dtrow[5] = item.Current;
                    dtrow[6] = item.Average;


                    dtNewTable.Rows.Add(dtrow);

                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/CityRetailerWiseInfo.rpt")));
                rd.SetDataSource(dtNewTable);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                string type = "xls";
                if (type == "pdf")
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "CityRetailerWiseInfo.pdf");
                }
                else
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/ms-excel", string.Format("CityRetailerWiseInfo{0}.xls", DateTime.Now.ToShortDateString()));
                }

                return View();
            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                return null;
            }

        }


        public ActionResult ShopBrandWiseDisplay()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<RegionalHeadData> regionalHeadData = new List<RegionalHeadData>();
            regionalHeadData = FOS.Setup.ManageRegionalHead.GetTerritorialRegionalHeadList();
            regionalHeadData.Insert(0, new RegionalHeadData
            {
                ID = 0,
                Name = "All"
            });

            //List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(0);
            List<SaleOfficer> SaleOfficerObj = FOS.Setup.ManageSaleOffice.GetAllSaleOfficerListRelatedtoregionalHeadID(regionalHeadData.FirstOrDefault().ID, true);

            SaleOfficerObj.Insert(0, new SaleOfficer
            {
                ID = 0,
                Name = "All"
            });

            List<RetailerData> RetailerObj = new List<RetailerData>();

            if (SaleOfficerObj == null)
            {
                return View();
            }

            else
            {
                RetailerObj = FOS.Setup.ManageRetailer.GetAllRetailerSaleOfficerList(SaleOfficerObj.Select(s => s.ID).FirstOrDefault());
                ViewData["RetailerObj"] = RetailerObj;
            }



            //List<VisitPlanData> visitData = new List<VisitPlanData>();
            //visitData = FOS.Setup.ManageJobs.GetAllVisitList();

            var objJob = new JobsData();

            objJob.RegionalHeadTypeData = FOS.Setup.ManageRegion.GetRegionalHeadsType();
            objJob.SaleOfficer = SaleOfficerObj;
            objJob.Retailers = RetailerObj;
            objJob.RegionalHead = regionalHeadData;
            //objJob.VisitPlan = visitData;
            objJob.PainterCityNames = FOS.Setup.ManagePainter.GetPainterCityNamesList();
            objJob.VisitPlanEach = new Shared.Common.SelectedWeekday("0000000");
            objJob.Cities = ManageCity.GetCityListBySOID(SaleOfficerObj.FirstOrDefault().ID);

            return View(objJob);
        }


        public ActionResult ShopBrandWiseDisplayReport(string StartingDate, string EndingDate, int TID, int fosid, int dealerid, int cityid, int display)
        {
            try
            {

                DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
                DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
                ManageRetailer objRetailers = new ManageRetailer();
                List<Sp__ShopBrandWiseDisplayData_Result> result = objRetailers.ShopBrandWiseDisplayReport(start, end, TID, fosid, dealerid, cityid, display);
                rptDataSet obj = new rptDataSet();
                DataRow dtrow;
                DataTable dtNewTable;
                dtNewTable = new DataTable();
                DataColumn dcol51 = new DataColumn("Terretory Head", typeof(System.String));
                dtNewTable.Columns.Add(dcol51);
                DataColumn dcol5 = new DataColumn("SaleOfficerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol5);
                DataColumn dcol3 = new DataColumn("DealerName", typeof(System.String));
                dtNewTable.Columns.Add(dcol3);
                DataColumn dcol0 = new DataColumn("ShopName", typeof(System.String));
                dtNewTable.Columns.Add(dcol0);
                DataColumn dcol01 = new DataColumn("City", typeof(System.String));
                dtNewTable.Columns.Add(dcol01);
                DataColumn dcol2 = new DataColumn("Date", typeof(System.DateTime));
                dtNewTable.Columns.Add(dcol2);
                DataColumn dcol4 = new DataColumn("Display", typeof(System.String));
                dtNewTable.Columns.Add(dcol4);
                DataColumn dcol7 = new DataColumn("Path", typeof(System.String));
                dtNewTable.Columns.Add(dcol7);





                foreach (var item in result)
                {

                    dtrow = dtNewTable.NewRow();
                    dtrow[0] = item.Name;
                    dtrow[1] = item.SaleOfficerName;
                    dtrow[2] = item.DealerName;
                    dtrow[3] = (item.ShopName);
                    dtrow[4] = (item.CityName);
                    dtrow[5] = item.DateComplete;
                    dtrow[6] = item.Display;
                    dtrow[7] = item.Path;

                    dtNewTable.Rows.Add(dtrow);

                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/ShopBrandWiseDisplay.rpt")));
                rd.SetDataSource(dtNewTable);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                string type = "xls";
                if (type == "pdf")
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "ShopBrandWiseDisplay.pdf");
                }
                else
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/ms-excel", string.Format("ShopBrandWiseDisplay{0}.xls", DateTime.Now.ToShortDateString()));
                }

                return View();
            }
            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");
                return null;
            }

        }

        public ActionResult DailyPerformanceKPI()
        {
            return View();
        }

        public void DailyPerformanceKPIDetails(string StartingDate, string EndingDate, string Type)
        {
            FOSDataModel data = new FOSDataModel();
            DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
            DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
            DateTime final = end.AddDays(1);
            //RegionWIse
            if (Type == "RegionWise")
            {
                List<sp_getRegionWiseOrdersCount_Result> result = data.sp_getRegionWiseOrdersCount(start, final).ToList();


                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"SrNo.\",\"RegionName\",\"Orders\",\"FollowUp\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=RegionWise" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //var retailers = ManageRetailer.GetRetailersForExportinExcel();
                int srNo = 1;
                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                    srNo,

                    retailer.Name,
                    retailer.orders,
                    srNo++


                    ));
                }
                Response.Write(sw.ToString());
                Response.End();
            }

            //SOWise
            if (Type == "SoWise")
            {
                List<sp_getSoWiseOrdersCount1_1_Result> result = data.sp_getSoWiseOrdersCount1_1(start, final).ToList();


                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"SrNo.\",\"RegionalHeadName\",\"SOName\",\"Orders\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=SOWise" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //var retailers = ManageRetailer.GetRetailersForExportinExcel();
                int srNo = 1;
                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                    srNo,
                    retailer.RegionalHead,
                    retailer.SoName,
                    retailer.Orders,
                    srNo++


                    ));
                }
                Response.Write(sw.ToString());
                Response.End();
            }

            //ItemWise
            if (Type == "ItemWise")
            {
                List<sp_getItemWiseOrdersCount1_1_Result> result = data.sp_getItemWiseOrdersCount1_1(start, final).ToList();


                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"SrNo.\",\"ItemName\",\"Quantity\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=ItemWise" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //var retailers = ManageRetailer.GetRetailersForExportinExcel();
                int srNo = 1;
                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"",
                    srNo,

                    retailer.ItemName,
                    retailer.Qty,
                    srNo++


                    ));
                }
                Response.Write(sw.ToString());
                Response.End();
            }
            //DistributorWise
            if (Type == "DistributorWise")
            {
                List<sp_getDistributorWiseOrdersCount1_2_Result> result = data.sp_getDistributorWiseOrdersCount1_2(start, final).ToList();


                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"SrNo.\",\"Region\",\"ShopName\",\"Quantity\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=DistributorWise" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //var retailers = ManageRetailer.GetRetailersForExportinExcel();
                int srNo = 1;
                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                    srNo,

                    retailer.Name,
                    retailer.ShopName,
                    retailer.Orders,
                    srNo++


                    ));
                }
                Response.Write(sw.ToString());
                Response.End();
            }
            //NoSOPresent
            if (Type == "NoSoPresent")
            {
                List<sp_getNoSoPresentInJobOrder1_1_Result> result = data.sp_getNoSoPresentInJobOrder1_1(start, final).ToList();


                // Example data
                StringWriter sw = new StringWriter();

                sw.WriteLine("\"SrNo.\",\"RegionalHeadName\",\"SoName\",\"Phone1\",\"Phone2\"");

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=SoAbsent" + DateTime.Now + ".csv");
                Response.ContentType = "application/octet-stream";

                //var retailers = ManageRetailer.GetRetailersForExportinExcel();
                int srNo = 1;
                foreach (var retailer in result)
                {
                    sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                    srNo,
                    retailer.RegionalHead,
                    retailer.Saleofficer,
                    retailer.Phone1,
                    retailer.Phone2,
                    srNo++


                    ));
                }
                Response.Write(sw.ToString());
                Response.End();
            }
        }

        public ActionResult OrderSummaryReport()
        {
            FOSDataModel db = new FOSDataModel();
            var objSaleOffice = new OrderSummaryReportData();
            objSaleOffice.range = ManageCategory.GetCat();
            objSaleOffice.saleofficerdata = ManageSaleOffice.GetAllSO();
            objSaleOffice.dealerdata = ManageDealer.GetDealersForExportinExcel();
            objSaleOffice.regionData = ManageRegion.GetRegionDataList();
      
            return View(objSaleOffice);

        }
        public ActionResult OrderSummaryReportForDistributor()
        {
            FOSDataModel db = new FOSDataModel();
            var objSaleOffice = new OrderSummaryReportData();
            objSaleOffice.range = ManageCategory.GetCat();
            objSaleOffice.saleofficerdata = ManageSaleOffice.GetAllSO();
           // objSaleOffice.dealerdata = ManageDealer.GetDealersForExportinExcel();
            objSaleOffice.regionData = ManageRegion.GetRegionDataList().OrderBy(x=>x.Name).ToList();
           // objSaleOffice.CityData = ManageRegion.GetCityListForDSR(objSaleOffice.regionData.FirstOrDefault().RegionID);
            return View(objSaleOffice);

        }
        public JsonResult GetSaleOfficersRetailedtoReg(int? RegID)
        {
            FOSDataModel dbContext = new FOSDataModel();
            try
            {


                if (RegID > 0)
                {





                    var result = ManageSaleOffice.GetAllSORelatedToRegionForDistributor(RegID).ToList();
                    return Json((result), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string a = "Select Region";
                    return Json((a), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult GetSaleOfficersRetailedtoRegForDistributor(int? RegID)
        {
            FOSDataModel dbContext = new FOSDataModel();
            try
            {


                if (RegID > 0)
                {





                    var result = ManageSaleOffice.GetAllSORelatedToRegionForDistributor(RegID).OrderBy(x=>x.Name).ToList();
                    return Json((result), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string a = "Select Region";
                    return Json((a), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult GetCitiesRetailedtoRegForDistributor(int? RegID)
        {
            FOSDataModel dbContext = new FOSDataModel();
            try
            {


                if (RegID > 0)
                {





                    var result = ManageSaleOffice.GetAllCitiesRelatedToRegionForDistributor(RegID).OrderBy(x => x.Name).ToList();
                    return Json((result), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string a = "Select Region";
                    return Json((a), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult GetDistributorRetailedtoSO(int? SOID)
        {
            FOSDataModel dbContext = new FOSDataModel();
            try
            {
                DateTime dtFromTodayUtc = DateTime.UtcNow.AddHours(5);


                DateTime dtFromToday = dtFromTodayUtc.Date;
                DateTime todate = dtFromToday.AddDays(1);
                DateTime fromdate = todate.AddDays(-30);

                if (SOID > 0)
                {
                    object[] param = { SOID };




                    var result = dbContext.sp_GetDistributorListInDSR(SOID, fromdate, todate).ToList();
                    return Json((result), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string a = "Select SaleOfficer";
                    return Json((a), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult GetDistributorRetailedtoSOForDistributor(int? RegID,int? Cityid)
        {
            FOSDataModel dbContext = new FOSDataModel();
            try
            {
                DateTime dtFromTodayUtc = DateTime.UtcNow.AddHours(5);


                DateTime dtFromToday = dtFromTodayUtc.Date;
                DateTime todate = dtFromToday.AddDays(1);
                DateTime fromdate = todate.AddDays(-30);

                if (RegID > 0)
                {
                    object[] param = { RegID };




                    var result = ManageSaleOffice.GetDistributorRetailedtoSOForDistributor(RegID,Cityid).ToList();
                    return Json((result), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string a = "Select SaleOfficer";
                    return Json((a), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public void OrderSummary(string StartingDate, string EndingDate, int? DisID, int TID, int fosid, string type)
        {


            FOSDataModel db = new FOSDataModel();

            DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
            DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
            DateTime final = end.AddDays(1);
            Microsoft.Reporting.WebForms.LocalReport ReportViewer1 = new Microsoft.Reporting.WebForms.LocalReport();

            if (type == "Daily")

            {
                try
                {
                    List<Sp_OrderSummeryReportNotSoldItem1_1_Result> NotItems = db.Sp_OrderSummeryReportNotSoldItem1_1(start, final, DisID, fosid, TID).ToList();

                    List<Sp_OrderSummeryReportInExcel1_9_Result> result = db.Sp_OrderSummeryReportInExcel1_9(start, final, DisID, fosid, TID).ToList();
                    string dealername = "";
                    string CityName = "";
                    List<Dealer> dealer = db.Dealers.Where(u => u.ID == DisID).ToList();
                    foreach (var deal in dealer)
                    {
                        dealername = deal.ShopName;
                        CityName = deal.City.Name;
                    }
                    string SoName = "";
                    List<SaleOfficer> SO = db.SaleOfficers.Where(u => u.ID == TID).ToList();
                    foreach (var SOS in SO)
                    {
                        SoName = SOS.Name;
                    }
                    string RangeName = "";
                    List<MainCategory> range = db.MainCategories.Where(u => u.MainCategID == fosid).ToList();
                    foreach (var SOS in range)
                    {
                        RangeName = SOS.MainCategDesc;
                    }
                    ReportParameter[] prm = new ReportParameter[7];
                    prm[0] = new ReportParameter("DistributorName", dealername);
                    prm[1] = new ReportParameter("Date", (System.DateTime.Now.ToString()));
                    prm[2] = new ReportParameter("SOName", SoName);
                    prm[3] = new ReportParameter("RangeName", RangeName);
                    prm[4] = new ReportParameter("DateTo", StartingDate);
                    prm[5] = new ReportParameter("DateFrom", EndingDate);
                    prm[6] = new ReportParameter("CityName", CityName);
                    ReportViewer1.ReportPath = Server.MapPath("~\\Views\\Reports\\TestReport.rdlc");
                    ReportViewer1.EnableExternalImages = true;
                    ReportDataSource dt1 = new ReportDataSource("DataSet1", result);
                    ReportDataSource dt2 = new ReportDataSource("DataSet2", NotItems);
                    ReportViewer1.SetParameters(prm);
                    ReportViewer1.DataSources.Clear();
                    ReportViewer1.DataSources.Add(dt1);
                    ReportViewer1.DataSources.Add(dt2);
                    ReportViewer1.Refresh();



                    Warning[] warnings;
                    string[] streamIds;
                    string contentType;
                    string encoding;
                    string extension;

                    //Export the RDLC Report to Byte Array.
                    byte[] bytes = ReportViewer1.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);

                    //Download the RDLC Report in Word, Excel, PDF and Image formats.
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = contentType;
                    Response.AddHeader("content-disposition", "attachment;filename=D" + DateTime.Now + ".Pdf");
                    Response.BinaryWrite(bytes);
                    Response.Flush();

                    Response.End();

                }

                catch (Exception exp)
                {
                    Log.Instance.Error(exp, "Report Not Working");

                }
            }

            if (type == "Weekly")
            {
                List<Sp_OrderSummeryReportInExcelRangeWise1_6_Result> result = db.Sp_OrderSummeryReportInExcelRangeWise1_6(start, final, fosid, TID).ToList();

               
                string SoName = "";
                List<SaleOfficer> SO = db.SaleOfficers.Where(u => u.ID == TID).ToList();
                foreach (var SOS in SO)
                {
                    SoName = SOS.Name;
                }
                string RangeName = "";
                List<MainCategory> Region = db.MainCategories.Where(u => u.MainCategID == fosid).ToList();
                foreach (var SOS in Region)
                {
                    RangeName = SOS.MainCategDesc;
                }

                ReportParameter[] prm = new ReportParameter[5];

                prm[0] = new ReportParameter("Date", (System.DateTime.Now.ToString()));
                prm[1] = new ReportParameter("SOName", SoName);
                prm[2] = new ReportParameter("RangeName", RangeName);
                prm[3] = new ReportParameter("DateTo", StartingDate);
                prm[4] = new ReportParameter("DateFrom", EndingDate);
                ReportViewer1.ReportPath = Server.MapPath("~/Views/Reports/WeeklyReport.rdlc");
                ReportViewer1.EnableExternalImages = true;
                ReportDataSource dt1 = new ReportDataSource("DataSet1", result);
              
                ReportViewer1.SetParameters(prm);
                ReportViewer1.DataSources.Clear();
                ReportViewer1.DataSources.Add(dt1);
             
                ReportViewer1.Refresh();
                Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                //Export the RDLC Report to Byte Array.
                byte[] bytes = ReportViewer1.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);

                //Download the RDLC Report in Word, Excel, PDF and Image formats.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=W" + DateTime.Now + ".pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();

                Response.End();
            }
            if (type == "Monthly")
            {
                List<Sp_OrderSummeryReportInExcelRangeWise1_6_Result> result = db.Sp_OrderSummeryReportInExcelRangeWise1_6(start, final, fosid, TID).ToList();
               
                string SoName = "";
                List<SaleOfficer> SO = db.SaleOfficers.Where(u => u.ID == TID).ToList();
                foreach (var SOS in SO)
                {
                    SoName = SOS.Name;
                }
                string RangeName = "";
                List<MainCategory> Region = db.MainCategories.Where(u => u.MainCategID == fosid).ToList();
                foreach (var SOS in Region)
                {
                    RangeName = SOS.MainCategDesc;
                }

                //ReportParameter[] prm = new ReportParameter[5];
                //prm[0] = new ReportParameter("RangeName", RangeName);
                //prm[1] = new ReportParameter("Date", (System.DateTime.Now.ToString()));
                //prm[2] = new ReportParameter("SOName", SoName);
                //prm[3] = new ReportParameter("DateTo", StartingDate);
                //prm[4] = new ReportParameter("DateFrom", EndingDate);
                ReportViewer1.ReportPath = Server.MapPath("~\\Views\\Reports\\MonthlyReport.rdlc");
                ReportViewer1.EnableExternalImages = true;
                ReportDataSource dt1 = new ReportDataSource("DataSet1", result);
                
                //ReportViewer1.SetParameters(prm);
                ReportViewer1.DataSources.Clear();
                ReportViewer1.DataSources.Add(dt1);
            
                ReportViewer1.Refresh();
                Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                //Export the RDLC Report to Byte Array.
                byte[] bytes = ReportViewer1.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);

                //Download the RDLC Report in Word, Excel, PDF and Image formats.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=M" + DateTime.Now + ".pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();

                Response.End();
            }
        }


        public void OrderSummaryForDistributor(string StartingDate, string EndingDate, int? DisID, int TID, int fosid)
        {


            FOSDataModel db = new FOSDataModel();

            DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
            DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);
            DateTime final = end.AddDays(1);
            Microsoft.Reporting.WebForms.LocalReport ReportViewer1 = new Microsoft.Reporting.WebForms.LocalReport();


            try
            {

                List<Sp_OrderSummeryReportInExcelRangeWiseForDistributor1_1_Result> result = db.Sp_OrderSummeryReportInExcelRangeWiseForDistributor1_1(start, final,  fosid, TID).ToList();
                
               
                string SoName = "";
                List<SaleOfficer> SO = db.SaleOfficers.Where(u => u.ID == TID).ToList();
                foreach (var SOS in SO)
                {
                    SoName = SOS.Name;
                }
                string RangeName = "";
                List<MainCategory> range = db.MainCategories.Where(u => u.MainCategID == fosid).ToList();
                foreach (var SOS in range)
                {
                    RangeName = SOS.MainCategDesc;
                }
                ReportParameter[] prm = new ReportParameter[5];
          
                prm[0] = new ReportParameter("Date", (System.DateTime.Now.ToString()));
                prm[1] = new ReportParameter("SOName", SoName);
                prm[2] = new ReportParameter("RangeName", RangeName);
                prm[3] = new ReportParameter("DateTo", StartingDate);
                prm[4] = new ReportParameter("DateFrom", EndingDate);
                ReportViewer1.ReportPath = Server.MapPath("~\\Views\\Reports\\TestDistributor.rdlc");
                ReportViewer1.EnableExternalImages = true;
                ReportDataSource dt1 = new ReportDataSource("DataSet1", result);
                ReportViewer1.SetParameters(prm);
                ReportViewer1.DataSources.Clear();
                ReportViewer1.DataSources.Add(dt1);
                ReportViewer1.Refresh();



                Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                //Export the RDLC Report to Byte Array.
                byte[] bytes = ReportViewer1.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);

                //Download the RDLC Report in Word, Excel, PDF and Image formats.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=D" + DateTime.Now + ".Pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();

                Response.End();

            }

            catch (Exception exp)
            {
                Log.Instance.Error(exp, "Report Not Working");

            }


        }

        public ActionResult ShopsNotVisitedBySORpt()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<Region> RegionObj = FOS.Setup.ManageRegion.GetRegionList(RHID);
            var objRegion = RegionObj.FirstOrDefault();
            List<RegionalHeadData> rhr = FOS.Setup.ManageCity.getRegionalHeadsByRegionID(objRegion.ID);
            var objRegionalHead = rhr.FirstOrDefault();
            List<SaleOfficerData> Sos = FOS.Setup.ManageCity.GetSaleOfficersByRegionID(objRegionalHead.ID);


            var objArea = new AreaData();
            objArea.Regions = RegionObj;
            objArea.SaleOfficersFrom = Sos;
            objArea.RegionalHeads = rhr;

            return View(objArea);
        }
        public void ShopsNotVisitedBySORptDetail(string StartingDate, string EndingDate, int intSaleOfficerIDfrom)
        {
            FOSDataModel data = new FOSDataModel();
            DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
            DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);

            List<sp_ShopsNotVisitedBySo1_2_Result> result = data.sp_ShopsNotVisitedBySo1_2(intSaleOfficerIDfrom, start, end).ToList();

            StringWriter sw = new StringWriter();

            sw.WriteLine("\"SrNo.\",\"Shops\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ShopsNotVisited" + DateTime.Now + ".csv");
            Response.ContentType = "application/octet-stream";

            //var retailers = ManageRetailer.GetRetailersForExportinExcel();
            int srNo = 1;
            foreach (var retailer in result)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\"",
                srNo,
                retailer.ShopName,
                srNo++


                ));
            }
            Response.Write(sw.ToString());
            Response.End();
        }
        public ActionResult ItemsNotSoldBySoRpt()
        {
            int RHID = FOS.Web.UI.Controllers.AdminPanelController.GetRegionalHeadIDRelatedToUser();
            List<Region> RegionObj = FOS.Setup.ManageRegion.GetRegionList(RHID);
            var objRegion = RegionObj.FirstOrDefault();
            List<RegionalHeadData> rhr = FOS.Setup.ManageCity.getRegionalHeadsByRegionID(objRegion.ID);
            var objRegionalHead = rhr.FirstOrDefault();
            List<SaleOfficerData> Sos = FOS.Setup.ManageCity.GetSaleOfficersByRegionID(objRegionalHead.ID);


            var objArea = new AreaData();
            objArea.Regions = RegionObj;
            objArea.SaleOfficersFrom = Sos;
            objArea.RegionalHeads = rhr;

            return View(objArea);
        }
        public void ItemsNotSoldBySoRptDetail(string StartingDate, string EndingDate, int intSaleOfficerIDfrom)
        {
            FOSDataModel data = new FOSDataModel();
            DateTime start = Convert.ToDateTime(string.IsNullOrEmpty(StartingDate) ? DateTime.Now.ToString() : StartingDate);
            DateTime end = Convert.ToDateTime(string.IsNullOrEmpty(EndingDate) ? DateTime.Now.ToString() : EndingDate);

            List<Sp_ItemsNotSoldBySo_Result> result = data.Sp_ItemsNotSoldBySo(intSaleOfficerIDfrom, start, end).ToList();
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"SrNo.\",\"ItemName\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ItemsNotSold" + DateTime.Now + ".csv");
            Response.ContentType = "application/octet-stream";

            //var retailers = ManageRetailer.GetRetailersForExportinExcel();
            int srNo = 1;
            foreach (var retailer in result)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\"",
                srNo,

                retailer.ItemName,
                srNo++


                ));
            }
            Response.Write(sw.ToString());
            Response.End();
        }
        public JsonResult GetSaleOfficersByRegionID(int RegionHeadID)
        {
            var result = FOS.Setup.ManageCity.GetSaleOfficersByRegionID(RegionHeadID);
            return Json(result);
        }

        public JsonResult getRegionalHeadsByRegionID(int RegionID)
        {
            var result = FOS.Setup.ManageCity.getRegionalHeadsByRegionID(RegionID);
            return Json(result);
        }
    }
}