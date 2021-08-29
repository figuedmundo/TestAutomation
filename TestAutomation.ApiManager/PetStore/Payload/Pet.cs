using System.Collections.Generic;

namespace TestAutomation.ApiManager.PetStore.Payload
{
    public class Pet
    {
        public long Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tag> Tags { get; set; }
        public string Status { get; set; }
    }

    public struct Status
    {
        public const string Available = "available";
        public const string Pending = "pending";
        public const string Sold = "sold";
    }
}
