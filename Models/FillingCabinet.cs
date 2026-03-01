namespace FileLocator.Models
{
    public class FillingCabinet
    {
       
        public int Id { get; set; }
        public string Name { get; set; } = " ";


        public List<FileBoxes> FileBox { get; set; } = new();
    }
}
