using BackEndWebAPIReactJS.Models;
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
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select Customer_Id,Customer_Site,Customer_Region,Customer_Market
                              from deepak_Customer ";
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
        public JsonResult PostData([FromBody] DeepakCustomer Cust)
        {
            string query = @"insert into deepak_Customer values('" +
                                   Cust.Customer_Id +
                                       @"'," + @"'" +
                                Cust.Customer_Site +
                                      @"'," + @"'" +
                               Cust.Customer_Region +
                                        @"'," + @"'" +
                                Cust.Customer_Market +
                                @"')"
                                ;
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
            return new JsonResult("new Customer Added Succesfully..");
        }
        [HttpPut]
        public JsonResult PutData([FromBody] DeepakCustomer Cust)
        {
            string query = @"update deepak_Customer set " +
                                       @"Customer_Site='" + Cust.Customer_Site +
                                      @"'," + @"Customer_Region='" + Cust.Customer_Region +
                                      @"'," + @"Customer_Market='" + Cust.Customer_Market + @"'" +
                                      @" where Customer_Id=" + Cust.Customer_Id;

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
            string query = @"delete from deepak_Customer where Customer_Id=" + Id+@" ";

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
