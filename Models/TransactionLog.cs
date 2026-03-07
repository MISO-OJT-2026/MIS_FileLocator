namespace MIS_FileLocator.Models
{
    public class TransactionLog
    {
        public long Id { get; set; }

        public string? FullName { get; set; }

        // The short name of the action (e.g., "User Registered", "File Relocated")
        public string EventName { get; set; } = " ";

        // The detailed, human-readable story (e.g., "Moved File Box #4 to Cabinet A.")
        public string Description { get; set; } = " ";

        // Can be used for "Success", "Failed", or "Warning"
        public string Status { get; set; } = "Success";

        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
    }
}
