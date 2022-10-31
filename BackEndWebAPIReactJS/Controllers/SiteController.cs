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
    public class SiteController : ControllerBase
    {
        private readonly IConfiguration _configuration;        
        public SiteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from  deepak_Site";
            



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
        public JsonResult PostData([FromBody] DeepakSite tbldata)
        
        {

            string query = @"insert into deepak_Site values(@Site_Id,@Site_Name,@Start_date,@End_date,@Project_Manager,@RealEstate_Specialist,
                            @Field_Coordinator,@SiteAcq_Vendor,@Civil_vendor,@Construction_Vendor,@AE_Firm,@Cust_Id)";
            //Site_Id Site_Name Start_date End_date Project_Manager RealEstate_Specialist Field_Coordinator
            ////SiteAcq_Vendor Civil_vendor Construction_Vendor AE_Firm Cust_Id
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myconn = new SqlConnection(sqlDataSource))
            {
                myconn.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    mycommand.Parameters.AddWithValue("@Site_Id", tbldata.Site_Id);
                    mycommand.Parameters.AddWithValue("@Site_Name", tbldata.Site_Name);
                    mycommand.Parameters.AddWithValue("@Start_date", tbldata.Start_Date);
                    mycommand.Parameters.AddWithValue("@End_date", tbldata.End_Date);
                    mycommand.Parameters.AddWithValue("@Project_Manager", tbldata.Project_Manager);
                    mycommand.Parameters.AddWithValue("@RealEstate_Specialist", tbldata.RealEstate_Specialist);
                    mycommand.Parameters.AddWithValue("@Field_Coordinator", tbldata.Field_Coordinator);
                    mycommand.Parameters.AddWithValue("@SiteAcq_Vendor", tbldata.SiteAcq_Vendor);
                    mycommand.Parameters.AddWithValue("@Civil_vendor", tbldata.Civil_Vendor);
                    mycommand.Parameters.AddWithValue("@Construction_Vendor", tbldata.Construction_Vendor);
                    mycommand.Parameters.AddWithValue("@AE_Firm", tbldata.Ae_Firm);
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
        public JsonResult PutData([FromBody] DeepakSite tbldata)
        {
            //string query = @"update deepak_Site set " +
            //                           @"Site_Name='" + tbldata.Site_Name +
            //                          @"'," + @"Start_date='" + tbldata.Start_Date +
            //                          @"'," + @"End_date='" + tbldata.End_Date +
            //                          @"'," + @"Project_Manager='" + tbldata.Project_Manager +
            //                          @"'," + @"RealEstate_Specialist='" + tbldata.RealEstate_Specialist +
            //                          @"'," + @"Field_Coordinator='" + tbldata.Field_Coordinator +
            //                          @"'," + @"SiteAcq_Vendor='" + tbldata.SiteAcq_Vendor +
            //                          @"'," + @"Civil_vendor='" + tbldata.Civil_Vendor +
            //                          @"'," + @"Construction_Vendor='" + tbldata.Construction_Vendor +
            //                          @"'," + @"AE_Firm='" + tbldata.Ae_Firm +
            //                          @"'," + @"Cust_Id='" + tbldata.Cust_Id + @"'" +
            //                          @" where Site_Id=" + tbldata.Site_Id;

            string query = @"update deepak_Site set  
                                      Site_Name=@Site_Name , 
                                      Start_Date = @Start_Date,    
                                      End_Date = @End_Date ,
                                      Project_Manager=@Project_Manager,
                                      RealEstate_Specialist=@RealEstate_Specialist,
                                      Field_Coordinator=@Field_Coordinator,
                                      SiteAcq_Vendor=@SiteAcq_Vendor,
                                      Civil_vendor=@Civil_Vendor,
                                      Construction_Vendor=@Construction_Vendor,
                                      AE_Firm=@Ae_Firm,
                                      Cust_Id=@Cust_Id
                                      where Site_Id=@Site_Id";
            //Site_Id Site_Name Start_date End_date Project_Manager RealEstate_Specialist Field_Coordinator
            ////SiteAcq_Vendor Civil_vendor Construction_Vendor AE_Firm Cust_Id
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myconn = new SqlConnection(sqlDataSource))
            {
                myconn.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    mycommand.Parameters.AddWithValue("@Site_Id", tbldata.Site_Id);
                    mycommand.Parameters.AddWithValue("@Site_Name", tbldata.Site_Name);
                    mycommand.Parameters.AddWithValue("@Start_date", tbldata.Start_Date);
                    mycommand.Parameters.AddWithValue("@End_date", tbldata.End_Date);
                    mycommand.Parameters.AddWithValue("@Project_Manager", tbldata.Project_Manager);
                    mycommand.Parameters.AddWithValue("@RealEstate_Specialist", tbldata.RealEstate_Specialist);
                    mycommand.Parameters.AddWithValue("@Field_Coordinator", tbldata.Field_Coordinator);
                    mycommand.Parameters.AddWithValue("@SiteAcq_Vendor", tbldata.SiteAcq_Vendor);
                    mycommand.Parameters.AddWithValue("@Civil_vendor", tbldata.Civil_Vendor);
                    mycommand.Parameters.AddWithValue("@Construction_Vendor", tbldata.Construction_Vendor);
                    mycommand.Parameters.AddWithValue("@AE_Firm", tbldata.Ae_Firm);
                    mycommand.Parameters.AddWithValue("@Cust_Id", tbldata.Cust_Id);
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
            string query = @"delete from deepak_Site where Site_Id=" + Id + @" ";

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
