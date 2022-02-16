using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqScratchpad
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }

        public Employee()
        {

        }

        public Employee(int employeeId, string name, int age, string department, bool isActive)
        {
            EmployeeId = employeeId;
            Name = name;
            Age = age;
            Department = department;
            IsActive = isActive;
        }
    }
}
