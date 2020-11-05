using Kurets_Test_Qulix.Models;
using Kurets_Test_Qulix.Services.Interface;
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
        public string connectionString = @"Data Source=LAPTOP-S2L9C420;Initial Catalog=TestDb;Integrated Security=True";

        //Fill the dataset.
        public CompanyService()
        {
            data = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddCompany";
                    cmd.Parameters.AddWithValue("@name", company.Name);
                    cmd.Parameters.AddWithValue("@form", company.Form);

                }
            }
        }

        //Edit the company.
        public void Edit(Company company)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteCompany";
                    cmd.Parameters.AddWithValue("@name", company.Name);
                    cmd.Parameters.AddWithValue("@form", company.Form);

                }
            }
        }
    }
}
