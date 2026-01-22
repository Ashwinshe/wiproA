using Solid_Principles_and_Design_Patterns.Interfaces;
using Solid_Principles_and_Design_Patterns.Models;

namespace Solid_Principles_and_Design_Patterns.Services
{
    public class ReportGenerator : IReportGenerator
    {
        public Report Generate(string title, string content)
        {
            return new Report
            {
                Title = title,
                Content = content
            };
        }
    }
}
