namespace FileLocator.Models
{
    public class Folder
    {
        public int Id { get; set; }

        public string Name { get; set; } = ""; // to avoid null anteh

        public int FileBoxId { get; set; } 
        public FileBoxes? FileBox { get; set; } 

        public List<Documents> Documents { get; set; } = new();

    }
}
