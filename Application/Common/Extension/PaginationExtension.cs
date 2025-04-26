using Application.Common.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Extension
{
	public static class PaginationExtension
	{
		public static async Task<PagedResponseViewModel<T>> GetPagedAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken) where T : class
		{
			//Ensure valid page numbers
			pageNumber = Math.Max(pageNumber, 1);
			pageSize = Math.Max(pageSize, 10); // Default to 10 if invalid

			//Efficiently count records
			var totalRecords = await query.CountAsync(cancellationToken);

			//Calculate pagination
			var skip = (pageNumber - 1) * pageSize;
			var items = await query.Skip(skip).Take(pageSize).ToListAsync(cancellationToken);

			//Return paginated result
			return new PagedResponseViewModel<T>(totalRecords, pageNumber, pageSize, items);
		}
	}
}

