using Solid_Principles_and_Design_Patterns.Interfaces;
using Solid_Principles_and_Design_Patterns.Services;
using Solid_Principles_and_Design_Patterns.Models;
using Xunit;

namespace SolidPrinciplesAssignment.Tests
{
    public class ReportServiceTests
    {
        private class FakeSaver : IReportSaver
        {
            public bool Saved { get; private set; }

            public void Save(Report report, string path)
            {
                Saved = true;
            }
        }

        [Fact]
        public void ReportService_ShouldCallSaver()
        {
            var generator = new ReportGenerator();
            var saver = new FakeSaver();

            var service = new ReportService(generator, saver);
            service.CreateAndSave("T", "C", "file.txt");

            Assert.True(saver.Saved);
        }
    }
}
