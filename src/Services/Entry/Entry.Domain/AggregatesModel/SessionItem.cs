using System;

namespace MicroservicePoc.Service.Entry.Domain
{
    public class SessionItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public SessionItem()
        {
            
        }

        public SessionItem(int sessionId, string sessionName)
        {
            if (sessionId == 0 ||
                string.IsNullOrWhiteSpace(sessionName))
            {
                throw new ArgumentException();
            }

            Id = sessionId;
            Name = sessionName;
        }
    }
}