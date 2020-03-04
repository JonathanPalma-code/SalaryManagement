using System;
using SalaryManagement.Entities;
using SalaryManagement.Entities.Enums;

namespace SalaryManagement
{
    class Print
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the department's name: ");
            string departmentName = Console.ReadLine();
            Console.Write("Enter the employee details:\nName: ");
            string employeeName = Console.ReadLine();
            Console.Write("Level (EntryLevel/Junior/Senior): ");
            EmployeeLevel employeeLevel = Enum.Parse<EmployeeLevel>(Console.ReadLine());
            Console.Write("Base Salary: £");
            double employeeSalary = double.Parse(Console.ReadLine());

            Department department = new Department(departmentName);
            Employee employee = new Employee(employeeName, employeeLevel, employeeSalary, department);
            
            Console.Write("\nHow many contracts has the employee? ");
            int numberContracts = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberContracts; i++)
            {
                Console.WriteLine($"Please enter the contract number {i}'s details.");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HoursContract contract = new HoursContract(date, valuePerHour, hours);
                employee.AddContract(contract);
            }

            Console.Write("\nEnter the month and year to calculate the income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine($"\nEmployee's Report:\nName: {employee.Name}" +
                $"\nDepartment: {employee.Department.Name}" +
                $"\nIncome for {monthAndYear} is £{employee.Income(year, month).ToString("F2")}");
        }
    }
}
