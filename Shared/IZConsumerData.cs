using FOS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.Shared
{
    public class IZConsumerData
    {
        public int ID { get; set; }
        public string RefNO { get; set; }
        public string PlotNo { get; set; }
        public string MeterType { get; set; }
        public string MemberShip { get; set; }
        public string AccNO { get; set; }
        public string SubAccNo { get; set; }
        public string SubHead { get; set; }
        public string Phase { get; set; }
        public string teriff { get; set; }
        public string Connectiontype { get; set; }
        public DateTime ConnectionDate { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public bool Status { get; set; }
        public string PTV { get; set; }
        public bool Filer { get; set; }
        public string NTN { get; set; }
        public string PhoneNO { get; set; }
        public string CellNO { get; set; }
        public string CoOwnerName { get; set; }
        public string CoOwnerCNIC { get; set; }
        public int CoOwnerContact { get; set; }
        public int BlocksID { get; set; }
        public List<Tbl_IZBlocks> Blocks { get; set; }

        public string blockName { get; set; }
    }
}
