using Solid_Principles_and_Design_Patterns.Interfaces;

namespace Solid_Principles_and_Design_Patterns.Services
{
    public class ReportService
    {
        private readonly IReportGenerator _generator;
        private readonly IReportSaver _saver;

        public ReportService(IReportGenerator generator, IReportSaver saver)
        {
            _generator = generator;
            _saver = saver;
        }

        public void CreateAndSave(string title, string content, string path)
        {
            var report = _generator.Generate(title, content);
            _saver.Save(report, path);
        }
    }
}
