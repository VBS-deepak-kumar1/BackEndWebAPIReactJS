using BackEndWebAPIReactJS.Data;
using BackEndWebAPIReactJS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndWebAPIReactJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteAddressController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SiteAddressController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from  deep_SiteAddress";




            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myconn = new SqlConnection(sqlDataSource))
            {
                myconn.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();

                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult PostData([FromBody] DeepSiteAddress tbldata)

        {

            string query = @"insert into deep_SiteAddress values(@Street,@ZipCode,@State,@Country,@Cust_Id)";
            //Street,ZipCode,State,City,Country,Cust_Id
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myconn = new SqlConnection(sqlDataSource))
            {
                myconn.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {

                    mycommand.Parameters.AddWithValue("@Street", tbldata.Street);
                    mycommand.Parameters.AddWithValue("@ZipCode", tbldata.ZipCode);
                    //mycommand.Parameters.AddWithValue("@City", tbldata.City);
                    mycommand.Parameters.AddWithValue("@State", tbldata.State);
                    mycommand.Parameters.AddWithValue("@Country", tbldata.Country);
                    mycommand.Parameters.AddWithValue("@Cust_Id", tbldata.CustId);

                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();

                }
            }
            return new JsonResult("add successfully..");
        }
        [HttpPut]
        public JsonResult PutData([FromBody] DeepSiteAddress tbldata)
        {

            string query = @"update dee_SiteAddress set
                                       Street=@Street,
                                       //City=@City,
                                       State=@State,
                                       Country=@Country,
                                       Cust_Id=@Cust_Id
                                       where ZipCode=@ZipCode";
            //Street,ZipCode,State,City,Country,Cust_Id
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myconn = new SqlConnection(sqlDataSource))
            {
                myconn.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    mycommand.Parameters.AddWithValue("@Street", tbldata.Street);
                    mycommand.Parameters.AddWithValue("@ZipCode", tbldata.ZipCode);
                    //mycommand.Parameters.AddWithValue("@City", tbldata.City);
                    mycommand.Parameters.AddWithValue("@State", tbldata.State);
                    mycommand.Parameters.AddWithValue("@Country", tbldata.Country);
                    mycommand.Parameters.AddWithValue("@Cust_Id", tbldata.CustId);
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();

                }
            }
            return new JsonResult("Updated  Succesfully..");
        }
        [HttpDelete("{Id}")]
        public JsonResult DeleteData(int Id)

        {
            string query = @"delete from deep_SiteAddress where ZipCode=" + Id + @" ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myconn = new SqlConnection(sqlDataSource))
            {
                myconn.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();

                }
            }
            return new JsonResult("Deleted  Succesfully..");
        }


    }
}
