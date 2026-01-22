using Solid_Principles_and_Design_Patterns.Models;

namespace Solid_Principles_and_Design_Patterns.Interfaces
{
    public interface IReportGenerator
    {
        Report Generate(string title, string content);
    }
}
