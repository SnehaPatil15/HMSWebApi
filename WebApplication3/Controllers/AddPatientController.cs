using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddPatientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AddPatientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from AddPatient"; //where pid=1 or where pid=@pid
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("AddPatientAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }


        [HttpPost]
        public JsonResult Post(AddPatient AP)
        {
            string query = @"insert into AddPatient values(@Name,@Full_Address,@Contact,@Age,@Gender ,@Blood_Group,@Major_Disease)"; //where pid=1
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("AddPatientAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Name", AP.Name);
                    myCommand.Parameters.AddWithValue("@Full_Address", AP.Full_Address);
                    myCommand.Parameters.AddWithValue("@Contact", AP.Contact);
                    myCommand.Parameters.AddWithValue("@Age", AP.Age);
                    myCommand.Parameters.AddWithValue("@Gender", AP.Gender);
                    myCommand.Parameters.AddWithValue("@Blood_Group", AP.Blood_Group);
                    myCommand.Parameters.AddWithValue("@Major_Disease", AP.Major_Disease);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }


        [HttpPut]
        public JsonResult Put(AddPatient AP)
        {
            string query = @"update AddPatient set Name=@Name,Full_Address=@Full_Address,Contact=@Contact,Age=@Age,Gender=@Gender ,
                           Blood_Group=@Blood_Group,Major_Disease=@Major_Disease where pid=@pid"; //where pid=1
            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("AddPatientAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@pid", AP.pid);
                    myCommand.Parameters.AddWithValue("@Name", AP.Name);
                    myCommand.Parameters.AddWithValue("@Full_Address", AP.Full_Address);
                    myCommand.Parameters.AddWithValue("@Contact", AP.Contact);
                    myCommand.Parameters.AddWithValue("@Age", AP.Age);
                    myCommand.Parameters.AddWithValue("@Gender", AP.Gender);
                    myCommand.Parameters.AddWithValue("@Blood_Group", AP.Blood_Group);
                    myCommand.Parameters.AddWithValue("@Major_Disease", AP.Major_Disease);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }
        //[HttpDelete]
        //public JsonResult Delete(int pid)
        //{
        //    string query = @"delete from AddPatient where where pid=@pid"; //where pid=1
        //    DataTable table = new DataTable();
        //    string sqlDataSourse = _configuration.GetConnectionString("AddPatientAppCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@pid",pid);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult(table);

        //}
    }
}
