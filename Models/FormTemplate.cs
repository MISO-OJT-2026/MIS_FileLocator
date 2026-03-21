namespace MIS_FileLocator.Models
{
    public class FormTemplate
    {
        public int Id { get; set; }
        public string FormName { get; set; } = "";
        public string FormNumber { get; set; } = ""; // e.g., TSU-OAR-SF-22
        public string Category { get; set; } = "";   // e.g., Registrar, Accounting
        public string PdfUrl { get; set; } = "";     // The link to the PDF
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string AddedBy { get; set; } = "";
        public bool IsArchived { get; set; } = false;
    }
}
