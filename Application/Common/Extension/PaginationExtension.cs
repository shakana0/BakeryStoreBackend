using Application.Common.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Extension
{
	public static class PaginationExtension
	{
		public static async Task<PagedResponseViewModel<T>> GetPagedAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken) where T : class
		{
			if (pageNumber < 1) pageNumber = 1;
			if (pageSize < 1) pageSize = 1;

			var result = new PagedResponseViewModel<T>(query.Count(), pageNumber, pageSize);
			var skip = (result.CurrentPage - 1) * result.PageSize;
			result.Results = await query.Skip(skip).Take(pageSize).ToListAsync<T>(cancellationToken);

			return result;
		}
	}
}
