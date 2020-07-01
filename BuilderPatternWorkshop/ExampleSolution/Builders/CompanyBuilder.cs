using BuilderPatternWorkshop.Model;
using BuilderPatternWorkshop.Model.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPatternWorkshop
{
    public class CompanyBuilder
    {
        
        private IPayroll m_Payroll = new Mock<IPayroll>().Object;
        private IEnumerable<IEmployee> m_Employees = Enumerable.Empty<IEmployee>();
        private int m_HighEarnerThreshold = 50000;

        public CompanyBuilder WithPayroll(IPayroll payroll)
        {
            m_Payroll = payroll;
            return this;
        }

        public CompanyBuilder WithEmployees(IEnumerable<IEmployee> employees)
        {
            m_Employees = employees;
            return this;
        }

        public CompanyBuilder WithEmployees(params IEmployee[] employees)
        {
            m_Employees = employees;
            return this;
        }

        public CompanyBuilder WithHighEarnerThreshold(int highEarnerThreshold)
        {
            m_HighEarnerThreshold = highEarnerThreshold;
            return this;
        }

        public Company Build()
        {
            return new Company(m_Payroll,m_Employees,m_HighEarnerThreshold);
        }

        public static implicit operator Company(CompanyBuilder builder)
        {
            return builder.Build();
        }
    }
}
