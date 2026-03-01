namespace FileLocator.Models
{
    public class AuditTrails
    {
        public long Id { get; set; }
        public string? Username { get; set; }

        public string Action { get; set; } = " ";

        public string TableName { get; set; } = " ";

        public string RecordId { get; set; } = " ";

        public string? OldValues { get; set; }

        public string? NewValues { get; set; }

        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
    }
}
