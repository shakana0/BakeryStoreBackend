using Application.Common.ViewModel;
using MediatR;

namespace Application.Common
{
	public abstract class SearchQuery<T> : IRequest<PagedResponseViewModel<T>> where T : class
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
