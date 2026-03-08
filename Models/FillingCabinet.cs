
namespace FileLocator.Models
{
    public class FillingCabinet
    {
       
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public string? Description { get; set; }

       
        public bool IsArchived { get; set; } = false;

        public DateTime? ArchivedAt { get; set; }
        public string? ArchivedBy { get; set; }
        public List<FileBoxes> FileBox { get; set; } = new();
    }
}
