using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Models
{
    class Company
    {
        private List<Employee> employees;
        private int nextEmployeeId = 1;
        public Company()
        {
            employees = new List<Employee>();
        }

        public int GetNextEmployeeId()
        {
            return nextEmployeeId++;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(int employeeId)
        {
            Employee employee = employees.Find(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine($"Employee with ID {employeeId} has been removed.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
            }
        }

        public void ModifyEmployee(int employeeId, string name, string position, decimal hourlyRate)
        {
            Employee employee = employees.Find(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                employee.Name = name;
                employee.Position = position;
                employee.HourlyRate = hourlyRate;
                Console.WriteLine($"Employee with ID {employeeId} has been modified.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
            }
        }

        public decimal CalculateSalary(int employeeId, int hoursWorked)
        {
            Employee employee = employees.Find(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                decimal salary = employee.HourlyRate * hoursWorked;
                if (employee is Manager manager)
                {
                    salary += manager.Bonus;
                }
                return salary;
            }
            else
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
                return 0;
            }
        }
    }
}
