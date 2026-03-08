namespace FileLocator.Models
{
    public class Folder
    {
        public int Id { get; set; }

        public string Name { get; set; } = ""; 

        public string? Description { get; set; }

       
        public bool IsArchived { get; set; } = false;
        public DateTime? ArchivedAt { get; set; }
        public string? ArchivedBy { get; set; }

        public int FileBoxId { get; set; } 
        public FileBoxes? FileBox { get; set; } 

        public List<Documents> Documents { get; set; } = new();

    }
}
