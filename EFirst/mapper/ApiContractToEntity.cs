using EFirst.models;
using EFirst.Request;

namespace EFirst.mapper;

public class ApiContractToEntity
{
    public static Tag ToNewTag(TagRequest tagRequest)
    {
        return new Tag
        {
            Name = tagRequest.Name,
            CreatedAt = DateTime.Now
        };
    }
}