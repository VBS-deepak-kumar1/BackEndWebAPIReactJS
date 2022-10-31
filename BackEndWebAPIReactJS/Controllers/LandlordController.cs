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
    public class LandlordController : ControllerBase
    {
        private readonly IConfiguration _configuration;
      //  private readonly AdventureWorks2017Context _context;
        public LandlordController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public LandlordController(AdventureWorks2017Context context)
        //{
        //    _context = context;
        //}
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from  deepak_landlord";
            //Landlord_Id,Landlord_Name,Landlord_Type,Landlord_ContactInfo,Latitude,Longitude,Jurisdiction deepak_landlord



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
        public JsonResult PostData([FromBody] DeepakLandlord tbldata)
        {
           
            string query = @"insert into deepak_landlord values(@Landlord_Id,@Landlord_Name,@Landlord_Type,
                             @Landlord_ContactInfo,@Latitude,@Longitude,@Jurisdiction,@Cust_Id )";
           // Landlord_Id,Landlord_Name,Landlord_Type,Landlord_ContactInfo,Latitude,Longitude,Jurisdiction deepak_landlord

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myconn = new SqlConnection(sqlDataSource))
            {
                myconn.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    mycommand.Parameters.AddWithValue("@Landlord_Id", tbldata.Landlord_Id);
                    mycommand.Parameters.AddWithValue("@Landlord_Name", tbldata.Landlord_Name);
                    mycommand.Parameters.AddWithValue("@Landlord_Type", tbldata.Landlord_Type);
                    mycommand.Parameters.AddWithValue("@Landlord_ContactInfo", tbldata.Landlord_ContactInfo);
                    mycommand.Parameters.AddWithValue("@Latitude", tbldata.Latitude);
                    mycommand.Parameters.AddWithValue("@Longitude", tbldata.Longitude);
                    mycommand.Parameters.AddWithValue("@Jurisdiction", tbldata.Jurisdiction);
                    mycommand.Parameters.AddWithValue("@Cust_Id", tbldata.Cust_Id);

                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();

                }
            }
            return new JsonResult("add successfully..");
        }
        [HttpPut]
        public JsonResult PutData([FromBody] DeepakLandlord tbldata)
        {
            string query = @"update deepak_landlord set " +
                                       @"landLord_Name='" + tbldata.Landlord_Name +
                                      @"'," + @"Landlord_Type='" + tbldata.Landlord_Type +
                                      @"'," + @"Landlord_ContactInfo='" + tbldata.Landlord_ContactInfo +
                                      @"'," + @"Latitude='" + tbldata.Latitude +
                                      @"'," + @"Longitude='" + tbldata.Longitude +
                                      @"'," + @"Jurisdiction='" + tbldata.Jurisdiction +
                                      @"'," + @"Cust_Id='" + tbldata.Cust_Id + @"'" +
                                      @" where Landlord_Id=" + tbldata.Landlord_Id;
            // Landlord_Id,Landlord_Name,Landlord_Type,Landlord_ContactInfo,Latitude,Longitude,Jurisdiction
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
            return new JsonResult("Updated  Succesfully..");
        }
        [HttpDelete("{Id}")]
        public JsonResult DeleteData(int Id)

        {
            string query = @"delete from deepak_Landlord where Landlord_Id=" + Id + @" ";

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
