using Solid_Principles_and_Design_Patterns.Interfaces;
using Solid_Principles_and_Design_Patterns.Services;

Console.WriteLine("SOLID Principles Assignment");

// Dependency Injection
IReportGenerator generator = new ReportGenerator();
IReportSaver saver = new FileReportSaver();
IReportFormatter formatter = new PdfReportFormatter();

var service = new ReportService(generator, saver);

service.CreateAndSave(
    "Monthly Report",
    formatter.Format(generator.Generate("Monthly Report", "Sales increased")),
    "report.txt"
);

Console.WriteLine("Report generated and saved.");
