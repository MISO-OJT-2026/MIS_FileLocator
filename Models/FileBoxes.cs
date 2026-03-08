namespace FileLocator.Models
{
    public class FileBoxes
    {
        public int Id { get; set; }
        public string Name { get; set; } = " ";

        public string? Description { get; set; }

        //  The Soft Delete/Archive flag
        public bool IsArchived { get; set; } = false;

        public DateTime? ArchivedAt { get; set; }

        public string? ArchivedBy { get; set; }

        //foreign key:must belong to a filling cab.
        public int FillingCabinetId { get; set; }

        public FillingCabinet? FillingCabinet { get; set; } // object to access filling cabinet columns
       
        public List<Folder> Folders { get; set; } = new();

    }
}