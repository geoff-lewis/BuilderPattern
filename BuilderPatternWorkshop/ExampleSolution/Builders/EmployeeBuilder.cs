using BuilderPatternWorkshop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPatternWorkshop
{
    public class EmployeeBuilder
    {
        private string m_Name = String.Empty;
        private int m_Age;
        private int m_Salary;

        public EmployeeBuilder WithName(string name)
        {
            m_Name = name;
            return this;
               
        }

        public EmployeeBuilder WithAge(int age)
        {
            m_Age = age;
            return this;
        }

        public EmployeeBuilder WithSalary(int salary)
        {
            m_Salary = salary;
            return this;
        }

        public Employee Build()
        {
            return new Employee(m_Name, m_Age, m_Salary);
        }

        public static implicit operator Employee(EmployeeBuilder builder)
        {
            return builder.Build();
        }
    }
}
