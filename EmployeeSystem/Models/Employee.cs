using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Models
{
    class Employee
    {
        public int EmployeeId { get; private set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal HourlyRate { get; set; }

        public Employee(int employeeId, string name, string position, decimal hourlyRate)
        {
            EmployeeId = employeeId;
            Name = name;
            Position = position;
            HourlyRate = hourlyRate;
        }
    }
}
