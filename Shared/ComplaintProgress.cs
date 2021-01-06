﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.Shared
{
    public class ComplaintProgress
    {

        public int ProgressID { get; set; }
        public int ComplaintID { get; set; }
        public string DateTime { get; set; }
        public int? PriorityID { get; set; }
        public int? ComplaintTypeID { get; set; }
        public Nullable<int> FaultTypeID { get; set; }
        public string FaultTypeName { get; set; }
        public Nullable<int> FaultTypeDetailID { get; set; }
        public string FaultTypeDetailName { get; set; }

        public string FaultTypeFinalName
        {
            get
            {

                return FaultTypeName + "/" + FaultTypeDetailName;
            }
        }
        public string ComplaintStatus { get; set; }
        public string AssignedFS { get; set; }
        public int? ProgressStatusID { get; set; }
        public string ProgressStatusName { get; set; }
        public string ProgressRemarks { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }



    }
}
