using FOS.DataLayer;
using FOS.Setup;
using Shared.Diagnostics.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace FOS.Web.UI.Controllers.API
{
    public class MyOrderListSummerySOWiseController : ApiController
    {
        FOSDataModel db = new FOSDataModel();

        public IHttpActionResult Get(int ConsumerID)
        {
            FOSDataModel dbContext = new FOSDataModel();
            try
            {
                DateTime dtFromTodayUtc = DateTime.UtcNow.AddHours(5);

                DateTime dtFromToday = dtFromTodayUtc.Date;
                DateTime dtToToday = dtFromToday.AddDays(1);

                if (ConsumerID > 0)
                {
                    object[] param = { ConsumerID };
                    
                    
                        var result = db.JobsDetails.Where(x => x.ConsumerID == ConsumerID).OrderByDescending(x => x.ID).Select(x=>new
                        {
                            ID=x.ID,
                            PreviousReading=x.PreviousReading,
                            PreviosUnits= (x.MeterReading-x.PreviousReading)

                        }
                        ).FirstOrDefault();

                    if (result != null )
                    {
                        return Ok(new
                        {
                            PreviousReading = result
                            
                        });
                    }
                 
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "VisitDetailController GET API Failed");
            }
            object[] paramm = {};
            return Ok(new
            {
                PreviousReading = paramm
            });

        }


    }
}