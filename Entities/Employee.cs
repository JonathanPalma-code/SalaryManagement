using SalaryManagement.Entities.Enums;
using System.Collections.Generic;

namespace SalaryManagement.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public EmployeeLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HoursContract> Contract { get; set; } = new List<HoursContract>();

        public Employee()
        {
        }

        public Employee(string name, EmployeeLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HoursContract contract)
        {
            Contract.Add(contract);
        }

        public void RemoveContract(HoursContract contract)
        {
            Contract.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach(HoursContract contract in Contract)
            {
                sum = (contract.Date.Year == year && contract.Date.Month == month) ? 
                    sum += contract.TotalValue() : sum;
            }
            return sum;
        }
    }
}
