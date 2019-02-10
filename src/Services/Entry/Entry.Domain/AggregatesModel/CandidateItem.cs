using System;

namespace MicroservicePoc.Service.Entry.Domain
{
    public class CandidateItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CandidateItem()
        {
            
        }

        public CandidateItem(int candidateId, string candidateName)
        {
            if (candidateId == 0 ||
                string.IsNullOrWhiteSpace(candidateName))
            {
                throw new ArgumentException();
            }

            Id = candidateId;
            Name = candidateName;
        }
    }
}