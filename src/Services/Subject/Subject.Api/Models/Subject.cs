namespace MicroservicePoc.Service.Subject.Api.Models
{
    public class SubjectItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubjectType Type { get; set; }
    }
}