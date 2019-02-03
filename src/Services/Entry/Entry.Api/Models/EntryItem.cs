using System;

namespace MicroservicePoc.Service.Entry.Api.Models
{
    public class EntryItem
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int CentreId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}