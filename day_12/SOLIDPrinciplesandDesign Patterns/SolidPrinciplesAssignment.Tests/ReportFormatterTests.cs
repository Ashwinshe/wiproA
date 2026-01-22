using Solid_Principles_and_Design_Patterns.Models;
using Solid_Principles_and_Design_Patterns.Services;
using Xunit;

namespace SolidPrinciplesAssignment.Tests
{
    public class ReportFormatterTests
    {
        [Fact]
        public void PdfFormatter_ShouldFormatReport()
        {
            var formatter = new PdfReportFormatter();
            var report = new Report { Title = "T", Content = "C" };

            var result = formatter.Format(report);

            Assert.Contains("PDF", result);
        }
    }
}
