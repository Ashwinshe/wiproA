namespace DesignPatternsAssignment.Factory
{
    public class DocumentFactory
    {
        public static IDocument CreateDocument(string type)
        {
            return type.ToUpper() switch
            {
                "PDF" => new PdfDocument(),
                "WORD" => new WordDocument(),
                _ => throw new ArgumentException("Invalid document type")
            };
        }
    }
}
