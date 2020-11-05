using Kurets_Test_Qulix.Models;
using Kurets_Test_Qulix.Services.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kurets_Test_Qulix.Services.EmployeeService
{
    public class EmployeeService : IService<Employee>
    {
        private readonly DataSet data;
        private readonly IConfiguration _configuration;
        public string connectionString = @"Data Source=LAPTOP-S2L9C420;Initial Catalog=TestDb;Integrated Security=True";
        
        //Fill the dataset.
        public EmployeeService(IConfiguration configuration)
        {
            data = new DataSet();
            _configuration = configuration;
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                connection.Open();
                var dataAdapter = new SqlDataAdapter("SELECT * FROM Employees", connection);
                dataAdapter.Fill(data);
            }
        }
        //Add the employee.
        public void Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddEmployee";
                    cmd.Parameters.AddWithValue("@name", employee.Name);
                    cmd.Parameters.AddWithValue("@surname", employee.SurName);
                    cmd.Parameters.AddWithValue("@patronymic", employee.Patronymic);
                    cmd.Parameters.AddWithValue("@employmentDate", employee.EmploymentDate);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        //Delete the employee.
        public void Delete(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteEmployee";
                    cmd.Parameters.AddWithValue("@name", employee.Name);
                    cmd.Parameters.AddWithValue("@surname", employee.SurName);
                    cmd.Parameters.AddWithValue("@patronymic", employee.Patronymic);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Edit the employee.
        public void Edit(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EditEmployee";
                    cmd.Parameters.AddWithValue("@name", employee.Name);
                    cmd.Parameters.AddWithValue("@surname", employee.SurName);
                    cmd.Parameters.AddWithValue("@patronymic", employee.Patronymic);
                    cmd.Parameters.AddWithValue("@position", employee.Position);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Get all employees from the table.
        public List<Employee> GetAll()
        {
            var Employees = new List<Employee>();
            foreach (var person in data.Tables[0].AsEnumerable())
            {
                Employees.Add(new Employee
                {
                    ID = person.Field<int>("ID"),
                    Name = person.Field<string>("Name"),
                    SurName = person.Field<string>("Surname"),
                    Patronymic = person.Field<string>("Patronymic"),
                    EmploymentDate = person.Field<DateTime>("EmploymentDate"),
                    Position = person.Field<Position>("Position")
                }); 
            }
            return Employees;
        }
    }
}
