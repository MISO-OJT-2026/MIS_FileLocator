namespace FileLocator.Models
{
    public class Documents
    {
        public int Id { get; set; }

        public string Title { get; set; } = " "; 

        public string? Description { get; set; } 

        public int? Year { get; set; }

        public DateTime FiledAt { get; set; } = DateTime.UtcNow; //when docs physically filed sa cabinet

        public string CreatedBy { get; set; } = " "; //when docs created in system

        public string? UpdatedBy { get; set; } 


        public bool IsDisposal { get; set; } 

        public DateTime? DateOfDisposal { get; set; }

        public string? FiledBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; }
         
        public string? DeletedByUserId{ get; set; }

        public bool IsBorrowed { get; set; } = false;
        public string? CurrentBorrower { get; set; }
        public DateTime? BorrowedAt { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public string? BorrowRemarks { get; set; }
        // confidentiality level table foreign key
        public int ConfidentialityLevelId { get; set; }
        public ConfidentialityLevel? ConfidentialityLevel { get; set; }

        // folder table foreign key 
        public int FolderId { get; set; }
        public Folder? Folder { get; set; }

        

    }
}
