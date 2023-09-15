using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Models
{
    class Manager : Employee
    {
        public decimal Bonus { get; private set; }

        public Manager(int employeeId, string name, string position, decimal hourlyRate, decimal bonus)
            : base(employeeId, name, position, hourlyRate)
        {
            Bonus = bonus;
        }
    }
}
