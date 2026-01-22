using Solid_Principles_and_Design_Patterns.Interfaces;
using Solid_Principles_and_Design_Patterns.Models;

namespace Solid_Principles_and_Design_Patterns.Services
{
    public class FileReportSaver : IReportSaver
    {
        public void Save(Report report, string filePath)
        {
            File.WriteAllText(filePath, report.Content);
        }
    }
}
