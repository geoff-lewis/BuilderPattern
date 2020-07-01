using BuilderPatternWorkshop.Model;
using BuilderPatternWorkshop.Model.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPatternWorkshop
{
    public class ExampleSolutionTests
    {
        [Test]
        public void ConstructCompany_WhenGivenNullPayroll_ThrowsArgumentNullException()
        {
            Assert.That(() => new Company(null, Enumerable.Empty<IEmployee>(), 0), Throws.ArgumentNullException);
        }

        [Test]
        public void GetEmployeesBelowAge_GivenAgeMatchingAnEmployee_ReturnsAllEmployeesYoungerThanValue()
        {
            Employee employee1 = An.Employee.WithAge(23);
            Employee employee2 = An.Employee.WithAge(32);
            Employee employee3 = An.Employee.WithAge(40);

            Company company = A.Company.WithEmployees(employee1, employee2, employee3);

            Assert.That(company.GetEmployeesBelowAge(40), Is.EquivalentTo(new List<IEmployee>() { employee1, employee2 }));
        }

        [Test]
        public void GetEmployeesUpToAge_GivenAgeMatchingOldestEmployee_ReturnsAllEmployees()
        {
            Employee employee1 = An.Employee.WithAge(23);
            Employee employee2 = An.Employee.WithAge(32);
            Employee employee3 = An.Employee.WithAge(40);

            Company company = A.Company.WithEmployees(employee1, employee2, employee3);

            Assert.That(company.GetEmployeesUpToAge(40), Is.EquivalentTo(new List<IEmployee>() { employee1, employee2, employee3 }));
        }

        [Test]
        public void GetHighEarners_GivenSalaryEquivalentToHighestEarner_ReturnsHighestEarnerOnly()
        {
            Employee employee1 = An.Employee.WithSalary(22000);
            Employee employee2 = An.Employee.WithSalary(26000);
            Employee employee3 = An.Employee.WithSalary(24000);

            Company company = A.Company.WithEmployees(employee1, employee2, employee3).WithHighEarnerThreshold(26000);

            Assert.That(company.GetHighEarners(), Is.EquivalentTo(new List<IEmployee>() { employee2 }));
        }

        [Test]
        public void ProcessPayroll_WhenCalled_PassesAllEmployeesToProcess()
        {
            Employee employee1 = An.Employee;
            Employee employee2 = An.Employee;
            Employee employee3 = An.Employee;

            var payroll = new Mock<IPayroll>();
            Company company = A.Company.WithEmployees(employee1, employee2, employee3).WithPayroll(payroll.Object);

            company.ProcessPayroll();

            payroll.Verify(p => p.ProcessPayroll(company.Employees), Times.Once);

        }


        [Test]
        public void ProcessPayroll_WhenCalled_ReturnsTheResultFromProcessPayroll()
        {
            Employee employee1 = An.Employee.WithSalary(22000);
            Employee employee2 = An.Employee.WithSalary(26000);
            Employee employee3 = An.Employee.WithSalary(24000);

            var payroll = new Mock<IPayroll>();
            payroll.Setup(p => p.ProcessPayroll(It.IsAny<IEnumerable<IEmployee>>())).Returns((IEnumerable<IEmployee> employees) => employees.Sum(employee => employee.Salary));

            Company company = A.Company.WithEmployees(employee1, employee2, employee3).WithPayroll(payroll.Object);

            var totalAmountProcessed = company.ProcessPayroll();
            Assert.That(totalAmountProcessed, Is.EqualTo(72000));

        }

    }

}