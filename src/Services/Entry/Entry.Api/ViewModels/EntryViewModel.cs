namespace MicroservicePoc.Service.Entry.Api.ViewModels
{
    public class EntryViewModel
    {
        public int EntryId { get; set; }
        public int CentreId { get; set; }
        public string CentreName { get; set; }
        public string CentreAddress { get; set; }
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectTypeName { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
    }
}