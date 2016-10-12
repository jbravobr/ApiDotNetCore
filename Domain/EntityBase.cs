using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiDotNetCore.Domain
{
    public class EntityBase
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CreationDate { get; set; }

        public EntityBase()
        {
            if (!CreationDate.HasValue)
                CreationDate = DateTime.Now;
        }
    }
}