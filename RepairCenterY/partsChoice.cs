using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairCenterY
{
    public class partsChoice
    {
        public static List<partsCost> partsChoiceList = new List<partsCost>() { };
    }
    public class partsCost
    {
        public string PartID {get;set;}
        public string PartUseNumber { get; set; }
        public string Partmoney { get; set; }
        public string PartName { get; set; }
        public string PartPicture { get; set; }
        public string PartPrice { get; set; }
        public string PartPutNumber { get; set; }
        public string PartPutRecordID { get;set;}

    }
}