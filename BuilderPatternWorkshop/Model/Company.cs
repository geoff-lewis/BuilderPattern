using BuilderPatternWorkshop.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPatternWorkshop.Model
{
    public class Company
    {

        private readonly IPayroll m_Payroll;
        private readonly int m_HighEarnerThreshold;

        public Company(IPayroll payroll, IEnumerable<IEmployee> employees, int highEarnerThreshold)
        {
            if (payroll == null) throw new ArgumentNullException(nameof(payroll));
            if (employees == null) throw new ArgumentNullException(nameof(employees));
            m_Payroll = payroll;
            Employees = employees;
            m_HighEarnerThreshold = highEarnerThreshold;
        }

        public IEnumerable<IEmployee> Employees { get; }

        public IEnumerable<IEmployee> GetEmployeesBelowAge(int age)
        {
            return Employees.Where(employee => employee.Age < age);
        }

        public IEnumerable<IEmployee> GetEmployeesUpToAge(int age)
        {
            return Employees.Where(employee => employee.Age <= age);
        }

        public IEnumerable<IEmployee> GetHighEarners()
        {
            return Employees.Where(employee => employee.Salary >= m_HighEarnerThreshold);
        }

        public int ProcessPayroll()
        {
            return m_Payroll.ProcessPayroll(Employees);
        }
    }
}
