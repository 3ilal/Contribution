using Data;
using DTOs;
namespace Queries
{
    public class Query
    {
        [UseProjection]
        public IQueryable<MyAggregate> GetMyAggregate([Service] DataContext context) => context.Aggregates;
        [UseProjection]
        public IQueryable<MyAggregateDTO> GetMyAggreateDTo([Service] DataContext context) => context.Aggregates.Select(x => new MyAggregateDTO
        {
            Id = x.Id,
            Total = x.Total,
            Discount = x.Discount,
            GrossTotal = x.GrossTotal,
        });
    }
}