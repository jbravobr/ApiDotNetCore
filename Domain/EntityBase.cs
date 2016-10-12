using System;
using MongoDB.Bson;

namespace ApiDotNetCore.Domain
{
    public class EntityBase
    {
        public ObjectId _id { get; set; }

        public DateTime? CreationDate { get; set; }

        public EntityBase()
        {
            if (!CreationDate.HasValue)
                CreationDate = DateTime.Now;
        }
    }
}