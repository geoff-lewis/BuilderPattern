using BuilderPatternWorkshop.Model;
using BuilderPatternWorkshop.Model.Interfaces;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace BuilderPatternWorkshop
{
    public class BuilderPatternTests
    {
        [Test]
        public void ConstructCompany_WhenGivenNullPayroll_ThrowsArgumentNullException()
        {
            Assert.That(() => new Company(null, Enumerable.Empty<IEmployee>(), 0), Throws.ArgumentNullException);
        }

        [Test]
        public void GetEmployeesBelowAge_GivenAgeMatchingAnEmployee_ReturnsAllEmployeesYoungerThanValue()
        {
            //arrange your test here
            Company company = null;

            //Check your results
            // Assert.That(company.GetEmployeesBelowAge(40), Is.EquivalentTo(new List<IEmployee>() { employee1, employee2 }));
        }

        [Test]
        public void GetEmployeesUpToAge_GivenAgeMatchingOldestEmployee_ReturnsAllEmployees()
        {
            //arrange your test here
            Company company = null;

            //Check your results
            //Assert.That(company.GetEmployeesUpToAge(40), Is.EquivalentTo(new List<IEmployee>() { employee1, employee2, employee3 }));
        }

        [Test]
        public void GetHighEarners_GivenSalaryEquivalentToHighestEarner_ReturnsHighestEarnerOnly()
        {
            //arrange your test here
            Company company = null;

            //Check your results
            //Assert.That(company.GetHighEarners(), Is.EquivalentTo(...));
        }

        [Test]
        public void ProcessPayroll_WhenCalled_PassesAllEmployeesToProcess()
        {
            //arrange your test here
            Company company = null;


            //company.ProcessPayroll();

            //Check your results
            //payroll.Verify(p => p.ProcessPayroll(company.Employees), Times.Once);

        }


        [Test]
        public void ProcessPayroll_WhenCalled_ReturnsTheResultFromProcessPayroll()
        {
            //arrange your test here
            Company company = null;

            //company.ProcessPayroll();

            //Check your result
            //Assert.That(totalAmountProcessed, Is.EqualTo(72000));

        }

    }
}