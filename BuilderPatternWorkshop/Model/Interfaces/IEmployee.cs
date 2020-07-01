using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPatternWorkshop.Model.Interfaces
{
    public interface IEmployee
    {
        string Name { get; }
        int Salary { get; }
        int Age { get; }
    }
}
