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
            
        }

        public EntryItem(int entryId, int centreId, string centreName, string centreAddress,
            int sessionId, string sessionName, int subjectId, string subjectName, string subjectTypeName,
            int candidateId, string candidateName)
        {
            if (entryId == 0)
            {
                throw new ArgumentException();
            }

            Id = entryId;
            CreateDate = DateTime.Now;

            Centre = new CentreItem(centreId, centreName, centreAddress);
            Session = new SessionItem(sessionId, sessionName);            
            Subject = new SubjectItem(subjectId, subjectName, subjectTypeName);
            Candidate = new CandidateItem(candidateId, candidateName);
        }        
    }
}