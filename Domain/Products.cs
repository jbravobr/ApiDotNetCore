using ApiDotNetCore;
using ApiDotNetCore.Domain;

namespace ApiDotNetcore
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Status { get; set; }

        public Company Company { get; set; }
    }
}