using DesignPatternsAssignment.Singleton;
using DesignPatternsAssignment.Factory;
using DesignPatternsAssignment.Observer;

Console.WriteLine("DESIGN PATTERNS ASSIGNMENT\n");

// ---------- Singleton ----------
var logger1 = Logger.Instance;
var logger2 = Logger.Instance;

logger1.Log("Singleton Logger Initialized");
Console.WriteLine($"Same instance: {ReferenceEquals(logger1, logger2)}\n");

// ---------- Factory ----------
IDocument pdf = DocumentFactory.CreateDocument("PDF");
pdf.Open();

IDocument word = DocumentFactory.CreateDocument("WORD");
word.Open();

Console.WriteLine();

// ---------- Observer ----------
WeatherStation station = new WeatherStation();
WeatherDisplay display = new WeatherDisplay();

station.Register(display);
station.SetTemperature(32.5f);
