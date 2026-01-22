using Solid_Principles_and_Design_Patterns.Interfaces;
using Solid_Principles_and_Design_Patterns.Models;

namespace Solid_Principles_and_Design_Patterns.Services
{
    public class ExcelReportFormatter : IReportFormatter
    {
        public string Format(Report report)
        {
            return $"[EXCEL]\t{report.Title}\t{report.Content}";
        }
    }
}
