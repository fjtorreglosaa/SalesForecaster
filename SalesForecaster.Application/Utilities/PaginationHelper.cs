namespace SalesForecaster.Application.Utilities
{
    public static class PaginationHelper
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> collection, PaginationDTO paginationDto)
        {
            return collection
                .Skip((paginationDto.Page - 1) * paginationDto.RecordsPerPage)
                .Take(paginationDto.RecordsPerPage);
        }
    }
}
