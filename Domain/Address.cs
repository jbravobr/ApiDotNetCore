namespace ApiDotNetCore.Domain
{
    public class Address : EntityBase
    {
        public int Number { get; set; }

        public string ZipCode { get; set; }

        public string StreetName { get; set; }

        public string Burgh { get; set; }
    }
}