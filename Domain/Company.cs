using ApiDotNetCore.Domain;

namespace ApiDotNetCore
{
    public class Company : EntityBase
    {
        public string Name {get;set;}

        public string Document {get;set;}

        public bool Status {get;set;}
    }
}