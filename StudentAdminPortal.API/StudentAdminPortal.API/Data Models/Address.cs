namespace StudentAdminPortal.API.Data_Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string? PhysicalAddress { get; set; }
        public string? PostalAddress { get; set; }

        //navigation property
        public Guid StudentId { get; set; }

    }
}
