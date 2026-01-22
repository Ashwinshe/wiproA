using Solid_Principles_and_Design_Patterns.Interfaces;
using Solid_Principles_and_Design_Patterns.Models;

namespace Solid_Principles_and_Design_Patterns.Services
{
    public class PdfReportFormatter : IReportFormatter
    {
        public string Format(Report report)
        {
            return $"[PDF]\n{report.Title}\n{report.Content}";
        }
    }
}
