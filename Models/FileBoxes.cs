namespace FileLocator.Models
{
    public class FileBoxes
    {
        public int Id { get; set; }
        public string Name { get; set; } = " ";

        //foreign key:must belong to a filling cab.
        public int FillingCabinetId { get; set; }

        public FillingCabinet? FillingCabinet { get; set; } // object to access filling cabinet columns
       
        public List<Folder> Folders { get; set; } = new();

    }
}