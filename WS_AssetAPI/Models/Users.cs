using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AssetAPI.Models
{
    public class Users
    {
        public int User_ID { get; set; }
        public string User_Fristname { get; set; }
        public string User_Lastname { get; set; }
        public string User_Department { get; set; }
        public int User_Level { get; set; }
        public int User_Status { get; set; }
        public string CreateDate { get; set; }
        public string DateModify { get; set; }
        public string User_Username { get; set; }
        public string User_Password { get; set; }
    }
    public class AddUser
    {
        public string User_Fristname { get; set; }
        public string User_Lastname { get; set; }
        public string User_Department { get; set; }
        public int User_Level { get; set; }
        public int User_Status { get; set; }
        public string CreateDate { get; set; }
        public string DateModify { get; set; }
        public string User_Username { get; set; }
        public string User_Password { get; set; }
    }
}
