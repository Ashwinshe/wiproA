using Solid_Principles_and_Design_Patterns.Models;

namespace Solid_Principles_and_Design_Patterns.Interfaces
{
    public interface IReportSaver
    {
        void Save(Report report, string filePath);
    }
}
