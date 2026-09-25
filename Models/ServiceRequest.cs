namespace ServiceDesk.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        public string RequestTitle { get; set; } = "";

        public string Category { get; set; } = "";

        public string Priority { get; set; } = "";

        public string SubmittedBy { get; set; } = "";

        public string Description { get; set; } = "";

        public string Status { get; set; } = "Open";
        public string AssignedTo { get; set; } = "";

        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}