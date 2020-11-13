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
    
    public partial class JobsDetail
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public Nullable<int> RegionalHeadID { get; set; }
        public Nullable<int> SalesOficerID { get; set; }
        public Nullable<int> DealerID { get; set; }
        public Nullable<int> RetailerID { get; set; }
        public Nullable<int> PainterID { get; set; }
        public string JobType { get; set; }
        public string BFactoryArea { get; set; }
        public Nullable<bool> SAvailable { get; set; }
        public Nullable<int> SQuantity1KG { get; set; }
        public Nullable<int> SQuantity5KG { get; set; }
        public Nullable<bool> SNewOrder { get; set; }
        public Nullable<int> SNewQuantity1KG { get; set; }
        public Nullable<bool> PUseWC { get; set; }
        public Nullable<int> SNewQuantity5KG { get; set; }
        public Nullable<int> SPreviousOrder1KG { get; set; }
        public Nullable<bool> SPOSMaterialAvailable { get; set; }
        public string SNote { get; set; }
        public Nullable<int> SPreviousOrder5KG { get; set; }
        public string SImage { get; set; }
        public Nullable<int> PUseWC1KG { get; set; }
        public Nullable<int> PUseWC5KG { get; set; }
        public Nullable<bool> PNewOrder { get; set; }
        public Nullable<int> PNewOrder5KG { get; set; }
        public Nullable<int> PNewOrder1KG { get; set; }
        public Nullable<bool> PNewLead { get; set; }
        public string PNewLeadMobNo { get; set; }
        public string PRemarks { get; set; }
        public Nullable<int> BAreaID { get; set; }
        public string BShop { get; set; }
        public string BOldHouse { get; set; }
        public string BNewHouse { get; set; }
        public string BParking { get; set; }
        public string BPlazaBasement { get; set; }
        public string BMosque { get; set; }
        public string BOthers { get; set; }
        public Nullable<bool> BLead { get; set; }
        public string BRemarks { get; set; }
        public string BLocation { get; set; }
        public string BLocationName { get; set; }
        public Nullable<bool> BSampleApplied { get; set; }
        public Nullable<System.DateTime> DateComplete { get; set; }
        public Nullable<System.DateTime> JobDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> SUblAcctOpened { get; set; }
        public Nullable<bool> SBrochureAvailable { get; set; }
        public Nullable<bool> SSmsCardAvailable { get; set; }
        public Nullable<bool> SShadeCardAvailable { get; set; }
        public Nullable<bool> SDisplay { get; set; }
        public Nullable<bool> SWhite40KgAvailable { get; set; }
        public string SMarketInfoNote { get; set; }
        public Nullable<int> VisitPlanType { get; set; }
        public Nullable<bool> SPreviousOrderDelievered { get; set; }
        public string VisitPurpose { get; set; }
        public string ActivityDetails { get; set; }
        public string NextVisitDate { get; set; }
        public string Priority { get; set; }
        public string TentativeCloseDate { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
        public string ActivityType { get; set; }
        public Nullable<int> FollowupReason { get; set; }
        public Nullable<int> DiscountPercentage { get; set; }
        public Nullable<int> OrderTotal { get; set; }
        public Nullable<int> DiscountedTotal { get; set; }
        public Nullable<int> ProgressStatusID { get; set; }
        public string Picture4 { get; set; }
        public string Picture5 { get; set; }
        public string Video { get; set; }
        public string Video2 { get; set; }
        public byte[] FaultTypeDetailRemarks { get; set; }
        public string ProgressStatusRemarks { get; set; }
        public Nullable<int> AssignedToSaleOfficer { get; set; }
        public Nullable<int> WorkDoneID { get; set; }
        public Nullable<int> IsPublished { get; set; }
        public Nullable<int> ChildFaultTypeID { get; set; }
        public Nullable<int> ChildFaultTypeDetailID { get; set; }
        public Nullable<int> ChildStatusID { get; set; }
        public Nullable<int> ChildAssignedSaleOfficerID { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual Job Job { get; set; }
        public virtual RegionalHead RegionalHead { get; set; }
        public virtual Retailer Retailer { get; set; }
    }
}
