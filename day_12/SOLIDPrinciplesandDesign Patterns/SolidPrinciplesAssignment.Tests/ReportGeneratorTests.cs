using Solid_Principles_and_Design_Patterns.Services;
using Xunit;

namespace SolidPrinciplesAssignment.Tests
{
    public class ReportGeneratorTests
    {
        [Fact]
        public void Generate_ShouldReturnReport()
        {
            var generator = new ReportGenerator();

            var report = generator.Generate("Title", "Content");

            Assert.Equal("Title", report.Title);
            Assert.Equal("Content", report.Content);
        }
    }
}
