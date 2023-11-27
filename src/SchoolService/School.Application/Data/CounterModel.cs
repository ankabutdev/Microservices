using MongoDB.Bson.Serialization.Attributes;

namespace School.Application.Data;

public class CounterModel
{
    [BsonId]
    public string Id { get; set; }

    public int Value { get; set; }
}
