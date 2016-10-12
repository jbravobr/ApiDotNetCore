using MongoDB.Bson.Serialization.Attributes;

namespace ApiDotNetCore.Domain
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public Address Address {get;set;}

        public bool Status { get; set; }

        public decimal LastOrderAmout { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}