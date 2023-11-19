using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public class EmployeeManager
    {
        private List<IEmployee> employees = new List<IEmployee>();

        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }

        public void AllEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        public void EmployeesByPosition(string position)
        {
            var selectedEmployees = employees.Where(e => e.Position == position);
            foreach (var employee in selectedEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        public void ManagersAboveAvgClerkSalary()
        {
            decimal avgClerkSalary = employees
                .Where(e => e.Position == "Айрис")
                .Average(e => e.Salary);

            var selectedManagers = employees
                .Where(e => e.Position == "Программист" && e.Salary > avgClerkSalary)
                .OrderBy(e => e.LName);

            foreach (var manager in selectedManagers)
            {
                Console.WriteLine(manager.ToString());
            }
        }

        public void EmployeesHiredAfterDate(DateTime hireDate)
        {
            var selectedEmployees = employees
                .Where(e => e.HireDate > hireDate)
                .OrderBy(e => e.LName);

            foreach (var employee in selectedEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        public void EmployeesByGender(char gender)
        {
            var selectedEmployees = employees
                .Where(e => gender == 'A' || e.Gender == gender)
                .OrderBy(e => e.LName);

            foreach (var employee in selectedEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}