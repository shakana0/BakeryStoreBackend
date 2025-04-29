using AutoMapper;
using Persistence;
using Xunit;

namespace Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public BakeryStoreDbContext Context { get; }
        public IMapper Mapper { get; private set; }
        public QueryTestFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}