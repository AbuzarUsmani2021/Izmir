//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOS.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_IZConsumers
    {
        public int ID { get; set; }
        public string RefNo { get; set; }
        public string PlotNo { get; set; }
        public string MeterType { get; set; }
        public string MeterNo { get; set; }
        public string Phase { get; set; }
        public string Teriff { get; set; }
        public string ConnectionType { get; set; }
        public Nullable<System.DateTime> ConnectionDate { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public Nullable<int> PhoneNo { get; set; }
        public Nullable<bool> Status { get; set; }
        public string PTV { get; set; }
        public Nullable<bool> Filer { get; set; }
        public string NTN { get; set; }
        public string CoOwnerName { get; set; }
        public string CoOwnerCNIC { get; set; }
        public Nullable<int> CoOwnerContact { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public string Location { get; set; }
        public Nullable<int> BlockID { get; set; }
        public string ConsumerID { get; set; }
    }
}