using BuilderPatternWorkshop.Model.Interfaces;
using System.Collections.Generic;

namespace BuilderPatternWorkshop.Model
{
    public interface IPayroll
    {
        int ProcessPayroll(IEnumerable<IEmployee> employees);
    }
}