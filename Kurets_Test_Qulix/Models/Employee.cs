using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurets_Test_Qulix.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Position Position { get; set; }
        public Company Company { get; set; }
    }
}
