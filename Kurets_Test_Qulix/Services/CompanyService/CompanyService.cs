using Kurets_Test_Qulix.Models;
using Kurets_Test_Qulix.Services.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kurets_Test_Qulix.Services.CompanyService
{
    public class CompanyService : IService<Company>
    {
        private readonly DataSet data;
        private readonly IConfiguration _configuration;
        
        //Fill the dataset.
        public CompanyService(IConfiguration configuration)
        {
            data = new DataSet();
            _configuration = configuration;
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyConnection"))) 
            {
                connection.Open();
                var dataAdapter = new SqlDataAdapter("SELECT * FROM Companies", connection);
                dataAdapter.Fill(data);
            }
        }
        //Get all companies from the table.
        public List<Company> GetAll()
        {
            var Companies = new List<Company>();
            foreach (var company in data.Tables[0].AsEnumerable())
            {
                Companies.Add(new Company
                {
                    ID = company.Field<int>("ID"),
                    Name = company.Field<string>("Name"),
                    Form = company.Field<string>("Form"),

                });
            }
            return Companies;
        }
        //Add the company.
        public void Add(Company company)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddCompany";
                    cmd.Parameters.AddWithValue("@name", company.Name);
                    cmd.Parameters.AddWithValue("@form", company.Form);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        //Edit the company.
        public void Edit(Company company)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EditCompany";
                    cmd.Parameters.AddWithValue("@name", company.Name);
                    cmd.Parameters.AddWithValue("@form", company.Form);

                }
            }

        }

        //Delete the company.
        public void Delete(Company company)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteCompany";
                    cmd.Parameters.AddWithValue("@name", company.Name);
                    cmd.Parameters.AddWithValue("@form", company.Form);

                }
            }
        }
    }
}
