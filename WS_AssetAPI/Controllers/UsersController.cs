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
    public class UsersController : ControllerBase
    {
        [Route("Users")]
        [HttpGet]
        public List<Users> Users()
        {
            Users us = new Users();
            List<Users> lus = new List<Users>();

            var query = "SELECT * FROM tb_users";
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reder = cmd.ExecuteReader();
            while (reder.Read())
            {
                us = new Users();
                if (reder["User_ID"] != DBNull.Value)
                {
                    us.User_ID = int.Parse(reder["User_ID"].ToString());
                }
                if (reder["User_Fristname"] != DBNull.Value)
                {
                    us.User_Fristname = reder["User_Fristname"].ToString();
                }
                if (reder["User_Lastname"] != DBNull.Value)
                {
                    us.User_Lastname = reder["User_Lastname"].ToString();
                }
                if (reder["User_Department"] != DBNull.Value)
                {
                    us.User_Department = reder["User_Department"].ToString();
                }
                if (reder["User_Level"] != DBNull.Value)
                {
                    us.User_Level = int.Parse(reder["User_Level"].ToString());
                }
                if (reder["User_Status"] != DBNull.Value)
                {
                    us.User_Status = int.Parse(reder["User_Status"].ToString());
                }
                if (reder["CreateDate"] != DBNull.Value)
                {
                    us.CreateDate = reder["CreateDate"].ToString();
                }
                if (reder["DateModify"] != DBNull.Value)
                {
                    us.DateModify = reder["DateModify"].ToString();
                }
                if (reder["User_Username"] != DBNull.Value)
                {
                    us.User_Username = reder["User_Username"].ToString();
                }
                if (reder["User_Password"] != DBNull.Value)
                {
                    us.User_Password = reder["User_Password"].ToString();
                }
                lus.Add(us);
            }
            return lus;
        }

        [Route("UserGetById")]
        [HttpGet]
        public List<Users> UserGetById(int id)
        {
            Users us = new Users();
            List<Users> lus = new List<Users>();
            SqlParameter pt = new SqlParameter();
            List<SqlParameter> lpt = new List<SqlParameter>();

            pt = new SqlParameter();
            pt.ParameterName = "@id";
            pt.Value = id;
            lpt.Add(pt);

            var query = "SELECT * FROM tb_users WHERE User_ID = @id";
            SqlConnection con = new SqlConnection(Startup.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            foreach(var item in lpt)
            {
                cmd.Parameters.Add(item);
            }
            con.Open();
            SqlDataReader reder = cmd.ExecuteReader();
            while (reder.Read())
            {
                us = new Users();
                if (reder["User_ID"] != DBNull.Value)
                {
                    us.User_ID = int.Parse(reder["User_ID"].ToString());
                }
                if (reder["User_Fristname"] != DBNull.Value)
                {
                    us.User_Fristname = reder["User_Fristname"].ToString();
                }
                if (reder["User_Lastname"] != DBNull.Value)
                {
                    us.User_Lastname = reder["User_Lastname"].ToString();
                }
                if (reder["User_Department"] != DBNull.Value)
                {
                    us.User_Department = reder["User_Department"].ToString();
                }
                if (reder["User_Level"] != DBNull.Value)
                {
                    us.User_Level = int.Parse(reder["User_Level"].ToString());
                }
                if (reder["User_Status"] != DBNull.Value)
                {
                    us.User_Status = int.Parse(reder["User_Status"].ToString());
                }
                if (reder["CreateDate"] != DBNull.Value)
                {
                    us.CreateDate = reder["CreateDate"].ToString();
                }
                if (reder["DateModify"] != DBNull.Value)
                {
                    us.DateModify = reder["DateModify"].ToString();
                }
                if (reder["User_Username"] != DBNull.Value)
                {
                    us.User_Username = reder["User_Username"].ToString();
                }
                if (reder["User_Password"] != DBNull.Value)
                {
                    us.User_Password = reder["User_Password"].ToString();
                }
                lus.Add(us);
            }
            return lus;

        }

        [Route("AddUser")]
        [HttpPost]
        public bool AddUser([FromBody] AddUser A)
        {
            try
            {
                AddUser au = new AddUser();
                List<AddUser> lau = new List<AddUser>();
                SqlParameter pt = new SqlParameter();
                List<SqlParameter> lpt = new List<SqlParameter>();
                //var query = "INSERT INTO tb_users (User_Fristname,User_Lastname,User_Department,User_Level,User_Status,User_Username,User_Password,CreateDate,DateModify) " +
                //            "VALUES (@User_Fristname,@User_Fristname,@User_Lastname,@User_Department,@User_Level,@User_Status,@User_Username,@User_Password,@CreateDate,@DateModify)";
                //var query = "INSERT INTO tb_users (User_Fristname,User_Lastname,User_Department,User_Level,User_Status,User_Username,User_Password,CreateDate,DateModify) " +
                //    "values (@User_Fristname,@User_Lastname,@User_Department,@User_Level,@User_Status,@User_Username,@User_Password,@CreateDate,@DateModify);";

                var query = "INSERT INTO tb_users (User_Fristname,User_Lastname,User_Department,User_Level,User_Status,CreateDate,DateModify,User_Username,User_Password) " +
                    "VALUES (@User_Fristname,@User_Lastname,@User_Department,@User_Level,@User_Status,@CreateDate,@DateModify,@User_Username,@User_Password)";


                pt = new SqlParameter();
                pt.ParameterName = "@User_Fristname";
                pt.Value = A.User_Fristname;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Lastname";
                pt.Value = A.User_Lastname;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Department";
                pt.Value = A.User_Department;                    
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Level";
                pt.Value = A.User_Level;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Status";
                pt.Value = A.User_Status;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@CreateDate";
                pt.Value = A.CreateDate;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@DateModify";
                pt.Value = A.DateModify;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Username";
                pt.Value = A.User_Username;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Password";
                pt.Value = A.User_Password;
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
            catch(Exception ex)
            {
                return false;
            }
        }

        [Route("UpdateUser")]
        [HttpPut]
        public bool UpdateUser([FromBody] Users A)
        {
            try
            {
                Users us = new Users();
                List<Users> lus = new List<Users>();
                SqlParameter pt = new SqlParameter();
                List<SqlParameter> lpt = new List<SqlParameter>();
                var query = "UPDATE tb_users SET User_Fristname = @User_Fristname,User_Lastname = @User_Lastname,User_Department = @User_Department,User_Level = @User_Level,User_Status = @User_Status," +
                    "CreateDate = @CreateDate,DateMOdify = @DateModify,User_Username = @User_Username,User_Password = @User_Password WHERE User_ID = @User_ID";

                pt = new SqlParameter();
                pt.ParameterName = "@User_ID";
                pt.Value = A.User_ID;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Fristname";
                pt.Value = A.User_Fristname;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Lastname";
                pt.Value = A.User_Lastname;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Department";
                pt.Value = A.User_Department;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Level";
                pt.Value = A.User_Level;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Status";
                pt.Value = A.User_Status;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@CreateDate";
                pt.Value = A.CreateDate;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@DateModify";
                pt.Value = A.DateModify;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Username";
                pt.Value = A.User_Username;
                lpt.Add(pt);

                pt = new SqlParameter();
                pt.ParameterName = "@User_Password";
                pt.Value = A.User_Password;
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

        [Route("DeleteUser")]
        [HttpDelete]
        public bool DelectUser(int id)
        {
            try
            {
                SqlParameter pt = new SqlParameter();
                List<SqlParameter> lpt = new List<SqlParameter>();
                var query = "DELETE FROM tb_users WHERE User_ID = @User_ID";

                pt = new SqlParameter();
                pt.ParameterName = "@User_ID";
                pt.Value = id;
                lpt.Add(pt);

                SqlConnection con = new SqlConnection(Startup.ConnectionString);
                SqlCommand cmd = new SqlCommand(query, con);
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
    }
}
