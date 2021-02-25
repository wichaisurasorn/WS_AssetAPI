using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetAPI.Models
{
    public class Assets
    {
        public int Asset_ID { get; set; }
        public string Asset_Name { get; set; }
        public string Asset_Serial { get; set; }
        public int Type_ID { get; set; }
        public string Asset_Datebuy { get; set; }
        public string Asset_Waranty { get; set; }
        public string Asset_Price { get; set; }
        public string Asset_Supply { get; set; }
        public int User_ID { get; set; }
        public int Admin_ID { get; set; }
        public string Asset_Number { get; set; }
        public string Asset_Modify { get; set; }

    }
    public class Addasset
    {
        public string Asset_Name { get; set; }
        public string Asset_Serial { get; set; }
        public int Type_ID { get; set; }
        public string Asset_Datebuy { get; set; }
        public string Asset_Waranty { get; set; }
        public string Asset_Price { get; set; }
        public string Asset_Supply { get; set; }
        public int User_ID { get; set; }
        public int Admin_ID { get; set; }
        public string Asset_Number { get; set; }
        public string Asset_Modify { get; set; }
    }
    public class AssetDetail
    {
        public int Asset_ID { get; set; }
        public string Asset_Name { get; set; }
        public string Asset_Serail { get; set; }
        public string Type_Name { get; set; }
        public string Type_Detail { get; set; }
        public string Asset_Detebuy { get; set; }
        public string Asset_Waranty { get; set; }
        public string Asset_Price { get; set; }
        public string Asset_Supply { get; set; }
        public string USERS { get; set; }
        public string ADMINS { get; set; }
        public string Asset_Number { get; set; }
        public string Asset_Modify { get; set; }
    }
    public class ShowAsset
    {
        public int Asset_ID { get; set; }
        public string Asset_Name { get; set; }
        public string Asset_Serail { get; set; }
        public string Type_Name { get; set; }
        public string Asset_Number { get; set; }
        public string Asset_Datebuy { get; set; }
        public string USERS { get; set; }
        
    }


}
