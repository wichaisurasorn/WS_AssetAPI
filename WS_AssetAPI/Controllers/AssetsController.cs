using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS_AssetAPI.Models;

namespace WS_AssetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        [Route("Assets")]
        [HttpGet]
        public List<Assets> Assets()
        {
            Assets at = new Assets();
            List<Assets> lat = new List<Assets>();
            //var query = "SELECT * FROM tb_asset";
            var query = "SELECT * FROM tb_asset";
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reder = cmd.ExecuteReader();
            while (reder.Read())
            {
                at = new Assets();
                if (reder["Asset_ID"] != DBNull.Value)
                {
                    at.Asset_ID = int.Parse(reder["Asset_ID"].ToString());
                }
                if (reder["Asset_Name"] != DBNull.Value)
                {
                    at.Asset_Name = reder["Asset_Name"].ToString();
                }
                if (reder["Asset_Serial"] != DBNull.Value)
                {
                    at.Asset_Serial = reder["Asset_Serial"].ToString();
                }
                if (reder["Type_ID"] != DBNull.Value)
                {
                    at.Type_ID = int.Parse(reder["Type_ID"].ToString());
                }
                if (reder["Asset_Datebuy"] != DBNull.Value)
                {
                    at.Asset_Datebuy = reder["Asset_Datebuy"].ToString();
                }
                if (reder["Asset_Waranty"] != DBNull.Value)
                {
                    at.Asset_Waranty = reder["Asset_Waranty"].ToString();
                }
                if (reder["Asset_Price"] != DBNull.Value)
                {
                    at.Asset_Price = reder["Asset_Price"].ToString();
                }
                if (reder["Asset_Supply"] != DBNull.Value)
                {
                    at.Asset_Supply = reder["Asset_Supply"].ToString();
                }
                if (reder["User_ID"] != DBNull.Value)
                {
                    at.User_ID = int.Parse(reder["User_ID"].ToString());
                }
                if (reder["Admin_ID"] != DBNull.Value)
                {
                    at.Admin_ID = int.Parse(reder["Admin_ID"].ToString());
                }
                if (reder["Asset_Number"] != DBNull.Value)
                {
                    at.Asset_Number = reder["Asset_Number"].ToString();
                }
                at.Asset_Modify = reder["Asset_Modify"].ToString();
                lat.Add(at);
            }
            return lat;
        }
        [Route("AssetGetById")]
        [HttpGet]
        public List<Assets> AssetGetById(int id)
        {
            Assets at = new Assets();
            List<Assets> lat = new List<Assets>();
            SqlParameter mt = new SqlParameter();
            List<SqlParameter> lmt = new List<SqlParameter>();

            mt = new SqlParameter();
            mt.ParameterName = "@id";
            mt.Value = id;
            lmt.Add(mt);

            var query = "SELECT * FROM tb_asset WHERE Asset_ID = @id";
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query,con);
            foreach(var item in lmt)
            {
                cmd.Parameters.Add(item);
            }
            con.Open();
            SqlDataReader reder = cmd.ExecuteReader();
            while (reder.Read())
            {
                at = new Assets();
                if (reder["Asset_ID"] != DBNull.Value)
                {
                    at.Asset_ID = int.Parse(reder["Asset_ID"].ToString());
                }
                if (reder["Asset_Name"] != DBNull.Value)
                {
                    at.Asset_Name = reder["Asset_Name"].ToString();
                }
                if (reder["Asset_Serial"] != DBNull.Value)
                {
                    at.Asset_Serial = reder["Asset_Serial"].ToString();
                }
                if (reder["Type_ID"] != DBNull.Value)
                {
                    at.Type_ID = int.Parse(reder["Type_ID"].ToString());
                }
                if (reder["Asset_Datebuy"] != DBNull.Value)
                {
                    at.Asset_Datebuy = reder["Asset_Datebuy"].ToString();
                }
                if (reder["Asset_Waranty"] != DBNull.Value)
                {
                    at.Asset_Waranty = reder["Asset_Waranty"].ToString();
                }
                if (reder["Asset_Price"] != DBNull.Value)
                {
                    at.Asset_Price = reder["Asset_Price"].ToString();
                }
                if (reder["Asset_Supply"] != DBNull.Value)
                {
                    at.Asset_Supply = reder["Asset_Supply"].ToString();
                }
                if (reder["User_ID"] != DBNull.Value)
                {
                    at.User_ID = int.Parse(reder["User_ID"].ToString());
                }
                if (reder["Admin_ID"] != DBNull.Value)
                {
                    at.Admin_ID = int.Parse(reder["Admin_ID"].ToString());
                }
                if (reder["Asset_Number"] != DBNull.Value)
                {
                    at.Asset_Number = reder["Asset_Number"].ToString();
                }
                at.Asset_Modify = reder["Asset_Modify"].ToString();
                lat.Add(at);
            }
            return lat;
        }
        [Route("AddAsset")]
        [HttpPost]
        public bool AddAsset([FromBody] Addasset A)
        {
            try
            {
                Addasset ast = new Addasset();
                List<Addasset> last = new List<Addasset>();
                SqlParameter pt = new SqlParameter();
                List<SqlParameter> lpt = new List<SqlParameter>();
                var query = "INSERT INTO tb_asset (Asset_Name,Asset_Serial,Type_ID,Asset_Datebuy,Asset_Waranty,Asset_Price,Asset_Supply,User_ID,Admin_ID,Asset_Number,Asset_Modify) " +
                            "VALUES (@Asset_Name,@Asset_Serial,@Type_ID,@Asset_Datebuy,@Asset_Waranty,@Asset_Price,@Asset_Supply,@User_ID,@Admin_ID,@Asset_Number,@Asset_Modify)";
                SqlConnection con = new SqlConnection(Startup.ConnectionString);
                SqlCommand cmd = new SqlCommand(query, con);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Name";
                pt.Value = A.Asset_Name;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Serial";
                pt.Value = A.Asset_Serial;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Type_ID";
                pt.Value = A.Type_ID;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Datebuy";
                pt.Value = A.Asset_Datebuy;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Waranty";
                pt.Value = A.Asset_Waranty;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Price";
                pt.Value = A.Asset_Price;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Supply";
                pt.Value = A.Asset_Supply;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_ID";
                pt.Value = A.User_ID;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Admin_ID";
                pt.Value = A.Admin_ID;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Number";
                pt.Value = A.Asset_Number;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Modify";
                pt.Value = A.Asset_Modify;
                lpt.Add(pt);

                foreach (var item in lpt)
                {
                    cmd.Parameters.Add(item);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [Route("UpdateAsset")]
        [HttpPut]
        public bool UpdateAsset([FromBody] Assets A)
        {
            try
            {
                Assets at = new Assets();
                List<Assets> lat = new List<Assets>();
                SqlParameter pt = new SqlParameter();
                List<SqlParameter> lpt = new List<SqlParameter>();
                var query = "UPDATE tb_asset SET Asset_Name = @Asset_Name,Asset_Serial = Asset_Serial,Type_ID = @Type_ID,Asset_Datebuy = Asset_Datebuy,Asset_Waranty = @Asset_Waranty,Asset_Price = @Asset_Price," +
                            "Asset_Supply = @Asset_Supply,User_ID = @User_ID,Admin_ID = @Admin_ID,Asset_Number = @Asset_Number,Asset_Modify = @Asset_Modify WHERE Asset_ID = @Asset_ID";

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_ID";
                pt.Value = A.Asset_ID;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Name";
                pt.Value = A.Asset_Name;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Serial";
                pt.Value = A.Asset_Serial;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Type_ID";
                pt.Value = A.Type_ID;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Datebuy";
                pt.Value = A.Asset_Datebuy;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Waranty";
                pt.Value = A.Asset_Waranty;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Price";
                pt.Value = A.Asset_Price;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Supply";
                pt.Value = A.Asset_Supply;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_ID";
                pt.Value = A.User_ID;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Admin_ID";
                pt.Value = A.Admin_ID;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Number";
                pt.Value = A.Asset_Number;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_Modify";
                pt.Value = A.Asset_Modify;
                lpt.Add(pt);

                SqlConnection con = new SqlConnection(Startup.ConnectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                foreach (var item in lpt)
                {
                    cmd.Parameters.Add(item);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        [Route("DeleteAsset")]
        [HttpDelete]
        public bool DeleteAsset(int id)
        {
            try
            {
                SqlParameter pt = new SqlParameter();
                List<SqlParameter> lpt = new List<SqlParameter>();
                var query = "DELETE FROM tb_asset WHERE Asset_ID = @Asset_ID";

                pt = new SqlParameter();
                pt.ParameterName = "@Asset_ID";
                pt.Value = id;
                lpt.Add(pt);

                SqlConnection con = new SqlConnection(Startup.ConnectionString);
                SqlCommand cmd = new SqlCommand(query,con);
                foreach(var item in lpt)
                {
                    cmd.Parameters.Add(item);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [Route("AssetDetail")]
        [HttpGet]
        public List<AssetDetail> AssetDetail(int id)
        {
            AssetDetail ad = new AssetDetail();
            List<AssetDetail> lad = new List<AssetDetail>();
            SqlParameter pt = new SqlParameter();
            List<SqlParameter> lpt = new List<SqlParameter>();

            //var query = "SELECT ats.Asset_ID,ats.Asset_Name,ats.Asset_Serial,ap.Type_Name,ap.Type_Detail,ats.Asset_Datebuy,ats.Asset_Waranty,ats.Asset_Price,ats.Asset_Supply," +
            //            "us.User_Fristname + ' ' + us.User_Lastname AS USERS, ad.User_Fristname + ' ' + ad.User_Lastname AS ADMINS, ats.Asset_Number,ats.Asset_Modify FROM tb_asset AS ats " +
            //            "INNER JOIN tb_users AS us ON ats.User_ID = us.User_ID " +
            //            "INNER JOIN tb_users AS ad ON ats.Admin_ID = ad.User_ID " +
            //            "INNER JOIN tb_as_type AS ap ON ats.Type_ID = ap.Type_ID" +
            //            "WHERE ats.Asset_ID = @Asset_ID";

            var query = "SELECT Asset_ID,Asset_Name,Asset_Serial,Type_Name,Type_Detail,Asset_Datebuy,Asset_Waranty,Asset_Price,Asset_Supply," +
                        "us.User_Fristname + ' ' + us.User_Lastname AS USERS, ad.User_Fristname + ' ' + ad.User_Lastname AS ADMINS, Asset_Number, Asset_Modify FROM tb_asset AS ats " +
                        "INNER JOIN tb_users AS us ON ats.User_ID = us.User_ID " +
                        "INNER JOIN tb_users AS ad ON ats.Admin_ID = ad.User_ID " +
                        "INNER JOIN tb_as_type AS ap ON ats.Type_ID = ap.Type_ID ";

            pt = new SqlParameter();
            pt.ParameterName = "@Asset_ID";
            pt.Value = id;
            lpt.Add(pt);

            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            foreach(var item in lpt)
            {
                cmd.Parameters.Add(item);
            }
            con.Open();
            SqlDataReader reder = cmd.ExecuteReader();
            //while (reder.Read())
            //{
            //    ad = new AssetDetail();
            //    if (reder["ats.Asset_ID"] != DBNull.Value)
            //    {
            //        ad.Asset_ID = int.Parse(reder["ats.Asset_ID"].ToString());
            //    }
            //    if (reder["ats.Asset_Name"] != DBNull.Value)
            //    {
            //        ad.Asset_Name = reder["ats.Asset_Name"].ToString();
            //    }
            //    if (reder["ats.Asset_Serial"] != DBNull.Value)
            //    {
            //        ad.Asset_Serail = reder["ats.Asset_Serial"].ToString();
            //    }
            //    if (reder["ap.Type_Name"] != DBNull.Value)
            //    {
            //        ad.Type_Name = reder["ap.Type_Name"].ToString();
            //    }
            //    if (reder["ap.Type_Detail"] != DBNull.Value)
            //    {
            //        ad.Type_Detail = reder["ap.Type_Detail"].ToString();
            //    }
            //    if (reder["ats.Asset_Datebuy"] != DBNull.Value)
            //    {
            //        ad.Asset_Detebuy = reder["ast.Asset_Datebuy"].ToString();
            //    }
            //    if (reder["ats.Asset_Waranty"] != DBNull.Value)
            //    {
            //        ad.Asset_Waranty = reder["ats.Asset_Waranty"].ToString();
            //    }
            //    if (reder["ats.Asset_Price"] != DBNull.Value)
            //    {
            //        ad.Asset_Price = reder["ats.Asset_Price"].ToString();
            //    }
            //    if (reder["ast.Asset_Supply"] != DBNull.Value)
            //    {
            //        ad.Asset_Supply = reder["ast.Asset_Supply"].ToString();
            //    }
            //    if (reder["USERS"] != DBNull.Value)
            //    {
            //        ad.USERS = reder["USERS"].ToString();
            //    }
            //    if (reder["ADMINS"] != DBNull.Value)
            //    {
            //        ad.ADMINS = reder["ADMINS"].ToString();
            //    }
            //    if (reder["ats.Asset_Number"] != DBNull.Value)
            //    {
            //        ad.Asset_Number = reder["ats.Asset_Number"].ToString();
            //    }
            //    if (reder["ats.Asset_Modify"] != DBNull.Value)
            //    {
            //        ad.Asset_Modify = reder["ats.Asset_Modify"].ToString();
            //    }
            //    lad.Add(ad);
            //}
            while (reder.Read())
            {
                ad = new AssetDetail();
                if (reder["Asset_ID"] != DBNull.Value)
                {
                    ad.Asset_ID = int.Parse(reder["Asset_ID"].ToString());
                }
                if (reder["Asset_Name"] != DBNull.Value)
                {
                    ad.Asset_Name = reder["Asset_Name"].ToString();
                }
                if (reder["Asset_Serial"] != DBNull.Value)
                {
                    ad.Asset_Serail = reder["Asset_Serial"].ToString();
                }
                if (reder["Type_Name"] != DBNull.Value)
                {
                    ad.Type_Name = reder["Type_Name"].ToString();
                }
                if (reder["Type_Detail"] != DBNull.Value)
                {
                    ad.Type_Detail = reder["Type_Detail"].ToString();
                }
                if (reder["Asset_Datebuy"] != DBNull.Value)
                {
                    ad.Asset_Detebuy = reder["Asset_Datebuy"].ToString();
                }
                if (reder["Asset_Waranty"] != DBNull.Value)
                {
                    ad.Asset_Waranty = reder["Asset_Waranty"].ToString();
                }
                if (reder["Asset_Price"] != DBNull.Value)
                {
                    ad.Asset_Price = reder["Asset_Price"].ToString();
                }
                if (reder["Asset_Supply"] != DBNull.Value)
                {
                    ad.Asset_Supply = reder["Asset_Supply"].ToString();
                }
                if (reder["USERS"] != DBNull.Value)
                {
                    ad.USERS = reder["USERS"].ToString();
                }
                if (reder["ADMINS"] != DBNull.Value)
                {
                    ad.ADMINS = reder["ADMINS"].ToString();
                }
                if (reder["Asset_Number"] != DBNull.Value)
                {
                    ad.Asset_Number = reder["Asset_Number"].ToString();
                }
                if (reder["Asset_Modify"] != DBNull.Value)
                {
                    ad.Asset_Modify = reder["Asset_Modify"].ToString();
                }
                lad.Add(ad);
            }
            return lad;
        }
        [Route("ShowAsset")]
        [HttpGet]
        public List<ShowAsset> ShowAsset()
        {
            ShowAsset sa = new ShowAsset();
            List<ShowAsset> lsa = new List<ShowAsset>();
            var query = "SELECT Asset_ID,Asset_Name,Asset_Serial,Type_Name,Asset_Number,Asset_Datebuy,us.User_Fristname + ' ' + us.User_Lastname AS USERS FROM tb_asset AS ats " +
                        "INNER JOIN tb_users AS us ON ats.User_ID = us.User_ID " +
                        "INNER JOIN tb_as_type AS ap ON ats.Type_ID = ap.Type_ID";
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reder = cmd.ExecuteReader();
            while (reder.Read())
            {
                sa = new ShowAsset();
                if(reder["Asset_ID"] != DBNull.Value)
                {
                    sa.Asset_ID = int.Parse(reder["Asset_ID"].ToString());
                }
                if(reder["Asset_Name"] != DBNull.Value)
                {
                    sa.Asset_Name = reder["Asset_Name"].ToString();
                }
                if (reder["Asset_Serial"] != DBNull.Value)
                {
                    sa.Asset_Serail = reder["Asset_Serial"].ToString();
                }
                if(reder["Type_Name"] != DBNull.Value)
                {
                    sa.Type_Name = reder["Type_Name"].ToString();
                }
                if(reder["Asset_Number"] != DBNull.Value)
                {
                    sa.Asset_Number = reder["Asset_Number"].ToString();
                }
                if(reder["Asset_Datebuy"] != DBNull.Value)
                {
                    sa.Asset_Datebuy = reder["Asset_Datebuy"].ToString();
                }
                if(reder["USERS"] != DBNull.Value)
                {
                    sa.USERS = reder["USERS"].ToString();
                }
                lsa.Add(sa);
            }
            return lsa;
        }
    }
}
