using System;

namespace MicroservicePoc.Service.Entry.Domain
{
    public class CentreItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public CentreItem()
        {
            
        }

        public CentreItem(int centreId, string centreName, string centreAddress)
        {
            if ((centreId == 0) ||
                string.IsNullOrWhiteSpace(centreName) ||
                string.IsNullOrWhiteSpace(centreAddress))
            {
                throw new ArgumentException();
            }

            Id = centreId;
            Name = centreName;
            Address = centreAddress;
        }
    }
}