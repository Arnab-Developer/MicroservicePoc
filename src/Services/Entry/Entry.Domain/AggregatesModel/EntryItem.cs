using System;

namespace MicroservicePoc.Service.Entry.Domain
{
    public class EntryItem
    {
        public int Id { get; set; }        
        public DateTime CreateDate { get; set; }
        public CentreItem Centre { get; private set; }
        public SessionItem Session { get; private set; }
        public SubjectItem Subject { get; private set; }
        public CandidateItem Candidate { get; private set; }

        public EntryItem()
        {
            CreateDate = DateTime.Now;
        }

        public void AddCentreItem(int id, string name, string address)
        {
            if (id == 0 || 
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address)) 
            {
                throw new ArgumentException();
            }

            Centre = new CentreItem
            {
                Id = id,
                Name = name,
                Address = address
            };
        }

        public void AddSessionItem(int id, string name)
        {
            if (id == 0 || 
                string.IsNullOrWhiteSpace(name)) 
            {
                throw new ArgumentException();
            }

            Session = new SessionItem
            {
                Id = id,
                Name= name
            };
        }

        public void AddSubjectItem(int id, string name, string subjectTypeName)
        {
            SubjectType type;

            if (id == 0 || 
                string.IsNullOrWhiteSpace(name) ||
                !Enum.TryParse<SubjectType>(subjectTypeName, out type)) 
            {
                throw new ArgumentException();
            }

            Subject = new SubjectItem
            {
                Id = id,
                Name = name,
                Type = type
            };
        }

        public void AddCandidateItem(int id, string name)
        {
            if (id == 0 || 
                string.IsNullOrWhiteSpace(name)) 
            {
                throw new ArgumentException();
            }

            Candidate = new CandidateItem
            {
                Id = id,
                Name= name
            };
        }
    }
}