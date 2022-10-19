using CodeQL.Entities.Entities;


namespace CodeQL.Data.Interfaces
{
    public interface ISampleRepository : IGetById<Sample>, IGetAll<Sample>, ISave<Sample>, IUpdate<Sample>, IDelete<int>
    {
    }
}
