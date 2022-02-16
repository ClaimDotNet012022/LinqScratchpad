
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqScratchpad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoWhereDemo();
            DoWithoutWhere();

            DoSelectDemo();
            DoWithoutSelectDemo();
            DoOtherSelectDemo();

            List<Employee> employees = new List<Employee>
            {
                new Employee(1001, "Fred",    37, "Maintenance", true),
                new Employee(1002, "Velma",   42, "IT",          true),
                new Employee(1003, "Daphne",  29, "HR",          false),
                new Employee(1004, "Shaggy",  23, "Maintenance", false),
                new Employee(1005, "Scooby",  56, "IT",          true),
                new Employee(1006, "Scrappy", 19, "HR",          true),
            };
            
            double averageAge = employees.Average(e => e.Age);
            int employeeCount = employees.Count();
            int oldEmployeeCount = employees.Count(e => e.Age > averageAge);
            int maxAge = employees.Max(e => e.Age);
            int minAge = employees.Min(e => e.Age);
            int totalAge = employees.Sum(e => e.Age);

            bool areAllEmployeesAdults = employees.All(e => e.Age >= 21);
            bool areAnyEmployeesAdults = employees.Any(e => e.Age >= 21);
            bool areThereAnyEmployees = employees.Any();

            List<Employee> employeesByAge = employees.OrderBy(e => e.Age).ToList();
            List<Employee> employeesByReverseAge = employees.OrderByDescending(e => e.Age).ToList();

            List<Employee> employeesByDept = employees.OrderBy(e => e.Department).ThenByDescending(e => e.Name).ToList();

            Employee firstEmployee = employees.FirstOrDefault(e => e.Name == "NO NAME");    // Returns null
            Employee lastEmployee = employees.Last();

            Employee fred = employees.Single(e => e.Name == "Fred");
            // Employee maintenance = employees.SingleOrDefault(e => e.Department == "Maintenance");    // throws exception because there is more than one matching element

            List<string> activeEmployees = new List<string>();
            foreach (Employee employee in employees)
            {
                if (employee.IsActive)
                {
                    activeEmployees.Add(employee.Name);
                }
            }
            PrintStrings(activeEmployees);

            List<string> emp = employees
                .Where(e => e.IsActive)
                .OrderByDescending(e => e.Name)
                .Select(e => e.Name)
                .ToList();


            IEnumerable<Employee> activeEmp = employees.Where(e => e.IsActive);
            IEnumerable<Employee> orderedActiveEmp = activeEmp.OrderByDescending(e => e.Name);
            IEnumerable<string> orderedNames = orderedActiveEmp.Select(e => e.Name);
            List<string> result = orderedNames.ToList();
            PrintStrings(emp);

            IEnumerable<string> emp2 = from em in employees
                                       where em.IsActive
                                       orderby em.Name descending
                                       select em.Name;
            PrintStrings(emp2.ToList());





            IEnumerable<Employee> activeEmployees2 = employees.Where(e => e.IsActive).ToList();

            employees[3].IsActive = true;

            foreach (Employee employee2 in activeEmployees2)
            {
                Console.WriteLine(employee2.Name);
            }
        }

        private static void DoSelectDemo()
        {
            List<int> nums = new List<int> { 5, 1, 9, 6 };
            List<int> triples = nums.Select(MultiplyByThree).ToList();
        }

        private static int MultiplyByThree(int n)
        {
            return n * 3;
        }

        private static void DoWithoutSelectDemo()
        {
            List<int> nums = new List<int> { 5, 1, 9, 6 };
            List<int> triples = new List<int>();

            foreach(int n in nums)
            {
                int newValue = n * 3;
                triples.Add(newValue);
            }
        }


        private static void DoOtherSelectDemo()
        {
            List<int> nums = new List<int> { 5, 1, 9, 6 };
            List<string> stringedNums = nums.Select(n => $"This number is {n}").ToList();
        }


        private static void DoWhereDemo()
        {
            List<int> nums = new List<int> { 5, 1, 9, 6 };
            IEnumerable<int> lowNums = nums.Where(IsLessThanThree).ToList();
        }

        private static bool IsLessThanThree(int x)
        {
            return x < 3;
        }

        private static void DoWithoutWhere()
        {
            List<int> nums = new List<int> { 5, 1, 9, 6 };

            List<int> results = new List<int>();
            foreach (int x in nums)
            {
                if (x < 3)
                {
                    results.Add(x);
                }
            }
        }

        public static bool IsEmployeeActive(Employee e)
        {
            return e.IsActive;
        }

        public static void PrintStrings(List<string> strings)
        {
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }
    }
}
