using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPatternWorkshop
{
    public static class A
    {
        public static CompanyBuilder Company => new CompanyBuilder();
    }

    public static class An
    {
        public static EmployeeBuilder Employee => new EmployeeBuilder();
    }

}
