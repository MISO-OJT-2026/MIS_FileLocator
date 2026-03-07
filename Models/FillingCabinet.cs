namespace FileLocator.Models
{
    public class FillingCabinet
    {
       
        public int Id { get; set; }
        public string Name { get; set; } = " ";

        public string? Description { get; set; }

        //  The Soft Delete/Archive flag
        public bool IsArchived { get; set; } = false;

        public List<FileBoxes> FileBox { get; set; } = new();
    }
}
