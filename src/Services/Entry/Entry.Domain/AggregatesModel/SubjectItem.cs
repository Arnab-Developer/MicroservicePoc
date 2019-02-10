using System;

namespace MicroservicePoc.Service.Entry.Domain
{
    public class SubjectItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public SubjectType Type { get; private set; }

        public SubjectItem()
        {
            
        }

        public SubjectItem(int subjectId, string subjectName, string subjectTypeName)
        {
            SubjectType type;

            if (subjectId == 0 ||
                string.IsNullOrWhiteSpace(subjectName) ||
                !Enum.TryParse<SubjectType>(subjectTypeName, out type))
            {
                throw new ArgumentException();
            }

            Id = subjectId;
            Name = subjectName;
            Type = type;
        }
    }
}