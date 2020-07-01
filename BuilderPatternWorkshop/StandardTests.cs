using BuilderPatternWorkshop.Model;
using BuilderPatternWorkshop.Model.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPatternWorkshop
{
    public class StandardTests
    {
        [Test]
        public void ConstructCompany_WhenGivenNullPayroll_ThrowsArgumentNullException()
        {
            Assert.That(() => new Company(null, Enumerable.Empty<IEmployee>(), 0), Throws.ArgumentNullException);
        }

        [Test]
        public void GetEmployeesBelowAge_GivenAgeMatchingAnEmployee_ReturnsAllEmployeesYoungerThanValue()
        {
            var employee1 = new Employee("Bob", 23, 22000);
            var employee2 = new Employee("Betty", 32, 26000);
            var employee3 = new Employee("Bertha", 40, 24000);

            var company = CreateSut(new List<IEmployee>() { employee1, employee2, employee3 });

            Assert.That(company.GetEmployeesBelowAge(40), Is.EquivalentTo(new List<IEmployee>() { employee1, employee2 }));
        }

        [Test]
        public void GetEmployeesUpToAge_GivenAgeMatchingOldestEmployee_ReturnsAllEmployees()
        {
            var employee1 = new Employee("Bob", 23, 22000);
            var employee2 = new Employee("Betty", 32, 26000);
            var employee3 = new Employee("Bertha", 40, 24000);

            var company = CreateSut(new List<IEmployee>() { employee1, employee2, employee3 });

            Assert.That(company.GetEmployeesUpToAge(40), Is.EquivalentTo(new List<IEmployee>() { employee1, employee2, employee3 }));
        }

        [Test]
        public void GetHighEarners_GivenSalaryEquivalentToHighestEarner_ReturnsHighestEarnerOnly()
        {
            var employee1 = new Employee("Bob", 23, 22000);
            var employee2 = new Employee("Betty", 32, 26000);
            var employee3 = new Employee("Bertha", 40, 24000);

            var company = CreateSut(new List<IEmployee>() { employee1, employee2, employee3 }, 26000);

            Assert.That(company.GetHighEarners(), Is.EquivalentTo(new List<IEmployee>() { employee2 }));
        }

        [Test]
        public void ProcessPayroll_WhenCalled_PassesAllEmployeesToProcess()
        {
            var employee1 = new Employee("Bob", 23, 22000);
            var employee2 = new Employee("Betty", 32, 26000);
            var employee3 = new Employee("Bertha", 40, 24000);

            var payroll = new Mock<IPayroll>();
            var company = CreateSut(payroll.Object, new List<IEmployee>() { employee1, employee2, employee3 }, 100000);

            company.ProcessPayroll();

            payroll.Verify(p => p.ProcessPayroll(company.Employees), Times.Once);

        }

        [Test]
        public void ProcessPayroll_WhenCalled_ReturnsTheResultFromProcessPayroll()
        {
            var employee1 = new Employee("Bob", 23, 22000);
            var employee2 = new Employee("Betty", 32, 26000);
            var employee3 = new Employee("Bertha", 40, 24000);

            var payroll = new Mock<IPayroll>();
            payroll.Setup(p => p.ProcessPayroll(It.IsAny<IEnumerable<IEmployee>>())).Returns((IEnumerable<IEmployee> employees) => employees.Sum(employee => employee.Salary));

            var company = CreateSut(payroll.Object, new List<IEmployee>() { employee1, employee2, employee3 }, 100000);

            var totalAmountProcessed = company.ProcessPayroll();
            Assert.That(totalAmountProcessed, Is.EqualTo(72000));

        }

        private Company CreateSut(IEnumerable<IEmployee> employees)
        {
            return CreateSut(new Mock<IPayroll>().Object, employees, 50000);
        }

        private Company CreateSut(IEnumerable<IEmployee> employees, int highEarnerThreshold)
        {
            return CreateSut(new Mock<IPayroll>().Object, employees, highEarnerThreshold);
        }

        private Company CreateSut(IPayroll payroll, IEnumerable<IEmployee> employees, int highEarnerThreshold)
        {
            return new Company(payroll, employees, highEarnerThreshold);
        }


    }

}