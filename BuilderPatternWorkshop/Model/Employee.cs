using BuilderPatternWorkshop.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPatternWorkshop.Model
{
    public class Employee : IEmployee
    {
        public Employee(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public string Name { get;  }

        public int Salary { get;  }

        public int Age { get;  }

        
    }
}
