using EmployeeSystem.Models;

class Program
{
    static void Main(string[] args)
    {
        Company company = new Company();

        Employee employee1 = new Employee(1, "John", "Developer", 30);
        Employee employee2 = new Employee(2, "Alice", "Designer", 25);
        Manager manager1 = new Manager(3, "Bob", "Manager", 35, 1000);

        company.AddEmployee(employee1);
        company.AddEmployee(employee2);
        company.AddEmployee(manager1);

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nCompany Menu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Remove Employee");
            Console.WriteLine("3. Modify Employee");
            Console.WriteLine("4. Calculate Salary");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter employee name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter employee position: ");
                    string position = Console.ReadLine();
                    Console.Write("Enter employee hourly rate: ");
                    decimal hourlyRate = decimal.Parse(Console.ReadLine());
                    Console.Write("Is this employee a manager (Y/N)? ");
                    bool isManager = Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase);
                    if (isManager)
                    {
                        Console.Write("Enter manager bonus: ");
                        decimal bonus = decimal.Parse(Console.ReadLine());
                        Manager manager = new Manager(company.GetNextEmployeeId(), name, position, hourlyRate, bonus);
                        company.AddEmployee(manager);
                    }
                    else
                    {
                        Employee employee = new Employee(company.GetNextEmployeeId(), name, position, hourlyRate);
                        company.AddEmployee(employee);
                    }
                    break;

                case "2":
                    Console.Write("Enter employee ID to remove: ");
                    int employeeIdToRemove = int.Parse(Console.ReadLine());
                    company.RemoveEmployee(employeeIdToRemove);
                    break;

                case "3":
                    Console.Write("Enter employee ID to modify: ");
                    int employeeIdToModify = int.Parse(Console.ReadLine());
                    Console.Write("Enter new name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new position: ");
                    string newPosition = Console.ReadLine();
                    Console.Write("Enter new hourly rate: ");
                    decimal newHourlyRate = decimal.Parse(Console.ReadLine());
                    company.ModifyEmployee(employeeIdToModify, newName, newPosition, newHourlyRate);
                    break;

                case "4":
                    Console.Write("Enter employee ID: ");
                    int employeeIdToCalculate = int.Parse(Console.ReadLine());
                    Console.Write("Enter hours worked: ");
                    int hoursWorked = int.Parse(Console.ReadLine());
                    decimal salary = company.CalculateSalary(employeeIdToCalculate, hoursWorked);
                    Console.WriteLine($"Calculated Salary: {salary:C}");
                    break;

                case "5":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}